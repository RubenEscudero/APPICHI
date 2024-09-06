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
		await App.FoodRepo.AddNewFood();
        await Application.Current.MainPage.DisplayAlert("Resultado", App.FoodRepo.StatusMessage, "OK");
    }

	public async void GetDayPlanTest(object sender, EventArgs e)
	{
		List<FoodModel> foodModels = await App.FoodRepo.GetAllFood();
        await Application.Current.MainPage.DisplayAlert("Resultado", foodModels.ToString(), "OK");
    }
}