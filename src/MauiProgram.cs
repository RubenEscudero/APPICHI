using APPICHI.Repositories.Home;
using CommunityToolkit.Maui.Core;
using MauiIcons.Cupertino;
using MauiIcons.FontAwesome;
using Microsoft.Extensions.Logging;

namespace APPICHI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseFontAwesomeMauiIcons()
                .UseCupertinoMauiIcons()
                .UseMauiCommunityToolkitCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "homeDayPlan.db3");
            builder.Services.AddSingleton<DayPlanRepository>(s => ActivatorUtilities.CreateInstance<DayPlanRepository>(s, dbPath));
            builder.Services.AddSingleton<FoodRepository>(s => ActivatorUtilities.CreateInstance<FoodRepository>(s, dbPath));
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
