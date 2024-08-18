using APPICHI.Clients;
using APPICHI.Models;
using System.Text.Json;

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
			ErrorMessageAction();
		}
		else
		{
			//LLAMAR A LA API DEL AYUNATEMIENTO Y PASAR EL MODELO DE ZGZTIMERESULTMODEL
			String jsonZgzTimeResultModel = await ZgzMobilityClient.GetTimeByMarqueeId(PostNumber.Text);
			if (String.IsNullOrEmpty(jsonZgzTimeResultModel))
			{
				ErrorMessageAction();
            }
			else
			{
                ZgzTimeResultModel model = JsonSerializer.Deserialize<ZgzTimeResultModel>(jsonZgzTimeResultModel);
				await Navigation.PushAsync(new ZgzTimeResultView(model));
            }
        }
		
	}

	//TODO
	//Crear función general de control de errores
	private void ErrorMessageAction()
	{
        ErrorMessage.Text = "Se ha producido un error, vuelve a intentarlo.";
        ErrorMessage.BackgroundColor = Colors.DarkRed;
    }
}