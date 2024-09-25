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

        private SQLiteAsyncConnection connAsync;
        private SQLiteConnection conn;

        private async Task InitAsync()
        {
            if (connAsync != null)
                return;

            connAsync = new SQLiteAsyncConnection(_dbPath);
            await connAsync.CreateTableAsync<DayPlanModel>();
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<DayPlanModel>();
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
                await InitAsync();

                //TODO
                //Add validations
                //Validar que no existe ya hoy un día planificado

                result = await connAsync.InsertAsync(new DayPlanModel
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
                await InitAsync();
                List<DayPlanModel> dayPlanModels = await connAsync.Table<DayPlanModel>().ToListAsync();
                
                for (int i = 0; i < dayPlanModels.Count; i++)
                {
                    List<FoodModel> foodModels = await App.FoodRepo.GetFoodModelsByDayPlanAsync(dayPlanModels[i].DayPlanId);

                    if (foodModels.Count > 0)
                    {
                        dayPlanModels[i].foods = foodModels;
                    }
                }

                return dayPlanModels;
                
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<DayPlanModel>();
        }

        public async Task<DayPlanModel> GetTodayDayPlanAsync()
        {
            try
            {
                await InitAsync();
                DayPlanModel dayPlanModel = await connAsync.Table<DayPlanModel>().Where(p => p.day == DateTime.Today).FirstOrDefaultAsync();

                List<FoodModel> foodModels = await App.FoodRepo.GetFoodModelsByDayPlanAsync(dayPlanModel.DayPlanId);

                if (foodModels.Count > 0)
                {
                    dayPlanModel.foods = foodModels;
                }

                return dayPlanModel;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new DayPlanModel();
        }

        public DayPlanModel GetTodayDayPlan()
        {
            try
            {
                Init();
                DayPlanModel dayPlanModel = conn.Table<DayPlanModel>().Where(p => p.day == DateTime.Today).FirstOrDefault();

                if (dayPlanModel != null)
                {
                    List<FoodModel> foodModels = App.FoodRepo.GetFoodModelsByDayPlan(dayPlanModel.DayPlanId);

                    if (foodModels.Count > 0)
                    {
                        dayPlanModel.foods = foodModels;
                    }
                }

                return dayPlanModel;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new DayPlanModel();
        }
    }

    
}
