using APPICHI.Repositories.Home;
using System.Globalization;

namespace APPICHI
{
    public partial class App : Application
    {
        public static FoodRepository FoodRepo { get; set; }
        public static DayPlanRepository DayPlanRepo { get; set; }
        public App(FoodRepository foodRepo, DayPlanRepository dayPlanRepo)
        {
            InitializeComponent();

            var culture = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;

            MainPage = new AppShell();

            FoodRepo = foodRepo;

            DayPlanRepo = dayPlanRepo;
        }
    }
}
