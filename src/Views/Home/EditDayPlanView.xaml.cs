using APPICHI.ViewModels.Home;

namespace APPICHI.Views.Home;

public partial class EditDayPlanView : ContentPage
{
	public EditDayPlanView()
	{
		InitializeComponent();

		BindingContext = new EditDayPlanViewModel();
	}

	public async void SaveEditDayPlan(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new HomeView());
	}
}