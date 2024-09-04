using APPICHI.Models.Home;

namespace APPICHI.Views.Home;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
	}

	public async void InsertDayPlanTest(object sender, EventArgs e)
	{
		await App.DayPlanRepo.AddNewDayPlan();
        await Application.Current.MainPage.DisplayAlert("Resultado", App.FoodRepo.StatusMessage, "OK");
    }

	public async void GetDayPlanTest(object sender, EventArgs e)
	{
		List<DayPlanModel> dayPlanModels = await App.DayPlanRepo.GetAllDayPlan();
        await Application.Current.MainPage.DisplayAlert("Resultado", dayPlanModels.ToString(), "OK");
    }
}