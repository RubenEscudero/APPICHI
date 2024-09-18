using APPICHI.Models.Home;

namespace APPICHI.Views.Home;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();

		DayPlanModel dayPlanModel = App.DayPlanRepo.GetTodayDayPlan().GetAwaiter().GetResult();

        BindingContext = this;
    }

	public async void ViewCalendar(object sender, EventArgs e)
	{
		//Obtener dayplan con comidas y pasarlo al calendario
		List<DayPlanModel> dayPlanModels = await App.DayPlanRepo.GetAllDayPlan();
        await Navigation.PushAsync(new CalendarView(dayPlanModels));
    }
}