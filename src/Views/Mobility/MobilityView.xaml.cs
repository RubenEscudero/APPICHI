using APPICHI.Clients;
using APPICHI.Models.Mobility;
using System.Text.Json;
using CommunityToolkit.Maui.Core.Platform;

namespace APPICHI.Views.Mobility;

public partial class MobilityView : ContentPage
{
	public MobilityView()
	{
		InitializeComponent();
	}

	/// <summary>
	/// Llamada a la API del ayuntamiento para obtener los datos de tiempo de espera
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	async void GoToZgzTimeResultView(object sender, EventArgs args)
	{
        await PostNumber.HideKeyboardAsync();
        if (String.IsNullOrEmpty(PostNumber.Text))
		{
			await Application.Current.MainPage.DisplayAlert("Error", "Se ha producido un error, vuelve a intentarlo.", "OK");
		}
		else
		{
			//LLAMAR A LA API DEL AYUNATEMIENTO Y PASAR EL MODELO DE ZGZTIMERESULTMODEL
			String jsonZgzTimeResultModel = await ZgzMobilityClient.GetTimeByMarqueeId(PostNumber.Text);
			if (String.IsNullOrEmpty(jsonZgzTimeResultModel))
			{
                await Application.Current.MainPage.DisplayAlert("Error", "Se ha producido un error, vuelve a intentarlo.", "OK");
            }
			else
			{
                ZgzTimeResultModel model = JsonSerializer.Deserialize<ZgzTimeResultModel>(jsonZgzTimeResultModel);
				await Navigation.PushAsync(new ZgzTimeResultView(model));
            }
        }
		
	}
}