using APPICHI.Clients;

namespace APPICHI.Views;

public partial class ZgzMobilityPage : ContentPage
{
	public ZgzMobilityPage()
	{
		InitializeComponent();
	}

	async void GetBusByMarqueeId(object sender, EventArgs args)
	{
		string TimeResult = await ZgzMobilityClient.GetTimeByMarqueeId(MarqueeId.Text);
		if (string.IsNullOrEmpty(TimeResult))
		{
			Result.Text = "No se ha podido encontrar el poste";
		}

		Result.Text = TimeResult;


	}
}