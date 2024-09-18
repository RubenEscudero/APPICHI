using APPICHI.Models.Home;
using APPICHI.ViewModels.Home;

namespace APPICHI.Views.Home;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();

		//DayPlanModel dayPlanModel = App.DayPlanRepo.GetTodayDayPlan().GetAwaiter().GetResult();

		BindingContext = new HomeViewModel();
    }

	public async void ViewCalendar(object sender, EventArgs e)
	{
		//Obtener dayplan con comidas y pasarlo al calendario
		List<DayPlanModel> dayPlanModels = await App.DayPlanRepo.GetAllDayPlan();
        await Navigation.PushAsync(new CalendarView(dayPlanModels));
    }
}