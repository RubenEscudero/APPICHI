using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using APPICHI.Models.Home;
using System.Xml.Linq;

namespace APPICHI.Repositories.Home
{
    public class FoodRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        private SQLiteAsyncConnection conn;

        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<FoodModel>();
        }

        public FoodRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewFood()
        {
            int result = 0;
            try
            {
                await Init();

                //TODO
                //Add validations

                result = await conn.InsertAsync(new FoodModel { IsMeal = true, FirstDish = "PRIMER PLATO", SecondDish = "SEGUNDO PLATO",
                    Dessert = "POSTRE", DayPlanId = 1 });

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, "PRIMER PLATO");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", "PRIMER PLATO", ex.Message);
            }
        }

        public async Task<List<FoodModel>> GetAllFood()
        {
            try
            {
                await Init();
                return await conn.Table<FoodModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<FoodModel>();
        }
    }
}
