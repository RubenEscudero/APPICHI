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

        private SQLiteAsyncConnection connAsync;
        private SQLiteConnection conn;

        private async Task InitAsync()
        {
            if (connAsync != null)
                return;

            connAsync = new SQLiteAsyncConnection(_dbPath);
            await connAsync.CreateTableAsync<FoodModel>();
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<FoodModel>();
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
                await InitAsync();

                //TODO
                //Add validations

                result = await connAsync.InsertAsync(new FoodModel { IsMeal = true, FirstDish = "PRIMER PLATO", SecondDish = "SEGUNDO PLATO",
                    Dessert = "POSTRE", DayPlanId = 1 });

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, "PRIMER PLATO");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", "PRIMER PLATO", ex.Message);
            }
        }

        public async Task<List<FoodModel>> GetFoodModelsByDayPlanAsync(int dayPlanId)
        {
            try
            {
                await InitAsync();
                return await connAsync.Table<FoodModel>().Where(i => i.DayPlanId == dayPlanId).OrderByDescending(m => m.IsMeal).ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<FoodModel>();
        }

        public List<FoodModel> GetFoodModelsByDayPlan(int dayPlanId)
        {
            try
            {
                Init();
                return conn.Table<FoodModel>().Where(i => i.DayPlanId == dayPlanId).OrderByDescending(m => m.IsMeal).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<FoodModel>();
        }

        public async Task<List<FoodModel>> GetAllFood()
        {
            try
            {
                await InitAsync();
                return await connAsync.Table<FoodModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<FoodModel>();
        }
    }
}
