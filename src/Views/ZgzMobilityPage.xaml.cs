using APPICHI.Clients;
using APPICHI.Models;
using Newtonsoft.Json;

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
        else
        {
            ZgzTimeResultModel zgzTimeResult = JsonConvert.DeserializeObject<ZgzTimeResultModel>(TimeResult);
            string FormatResult = "";
            foreach (var destino in zgzTimeResult.Features[0].Properties.Destinos)
            {
                FormatResult = FormatResult + $"Linea: {destino.linea}, Destino: {destino.destino}," +
                    $" Primero: {destino.primero}, Segundo: {destino.segundo} \n";
            }
            Result.Text = FormatResult;

        }
    }
}