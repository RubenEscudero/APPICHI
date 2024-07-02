namespace APPICHI.Views;

public partial class Mobility : ContentPage
{
	public Mobility()
	{
		InitializeComponent();
	}

	async void GoToZgzMobilityPage(object sender, EventArgs args)
	{
		await Navigation.PushAsync(new ZgzMobilityPage());
	}
}