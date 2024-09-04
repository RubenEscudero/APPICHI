using APPICHI.Repositories.Home;

namespace APPICHI
{
    public partial class App : Application
    {
        public static FoodRepository FoodRepo { get; set; }
        public static DayPlanRepository DayPlanRepo { get; set; }
        public App(FoodRepository foodRepo, DayPlanRepository dayPlanRepo)
        {
            InitializeComponent();

            MainPage = new AppShell();

            FoodRepo = foodRepo;

            DayPlanRepo = dayPlanRepo;
        }
    }
}
