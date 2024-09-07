using APPICHI.Models.Home;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPICHI.Repositories.Home
{
    public class DayPlanRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        private SQLiteAsyncConnection conn;

        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<DayPlanModel>();
        }

        public DayPlanRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewDayPlan()
        {
            int result = 0;
            try
            {
                await Init();

                //TODO
                //Add validations
                //Validar que no existe ya hoy un día planificado

                result = await conn.InsertAsync(new DayPlanModel
                {
                    day = DateTime.Now,
                    notes = "Nota"
                });

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, "Prueba dia");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", "Prueba dia", ex.Message);
            }
        }

        public async Task<List<DayPlanModel>> GetAllDayPlan()
        {
            try
            {
                await Init();
                return await conn.Table<DayPlanModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<DayPlanModel>();
        }
    }
}
