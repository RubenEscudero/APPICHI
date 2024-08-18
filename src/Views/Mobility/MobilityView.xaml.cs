namespace APPICHI.Views.Mobility;

public partial class MobilityView : ContentPage
{
	public MobilityView()
	{
		InitializeComponent();
	}

	async void GoToZgzTimeResultView(object sender, EventArgs args)
	{
		if (String.IsNullOrEmpty(PostNumber.Text))
		{
			ErrorMessage.Text = "Se ha producido un error, vuelve a intentarlo.";
		}
		else
		{
            await Navigation.PushAsync(new ZgzTimeResultView());
        }
		
	}
}