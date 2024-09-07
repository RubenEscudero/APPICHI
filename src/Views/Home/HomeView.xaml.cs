using APPICHI.Models.Home;

namespace APPICHI.Views.Home;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
	}

	public async void ViewCalendar(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new CalendarView());
    }
}