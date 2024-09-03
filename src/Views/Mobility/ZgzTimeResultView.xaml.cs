using APPICHI.Clients;
using APPICHI.Models.Mobility;
using Newtonsoft.Json;

namespace APPICHI.Views.Mobility;

public partial class ZgzTimeResultView : ContentPage
{
	public ZgzTimeResultView(ZgzTimeResultModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}