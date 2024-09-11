using APPICHI.Models.Home;
using Plugin.Maui.Calendar.Models;

namespace APPICHI.Views.Home;

public partial class CalendarView : ContentPage
{
    public EventCollection Events { get; set; }

    public CalendarView(List<DayPlanModel> dayPlanModels)
	{
		InitializeComponent();

        Events = new EventCollection();

        foreach (DayPlanModel dayPlanModel in dayPlanModels )
        {
            List<EventModel> eventModels = new List<EventModel>();
            
            if (dayPlanModel.foods is not null)
            {
                foreach (FoodModel foodModel in dayPlanModel.foods)
                {
                    string isMealText = (foodModel.IsMeal) ? "Comida" : "Cena";
                    eventModels.Add(new EventModel { FirstDish = foodModel.FirstDish, SecondDish = foodModel.SecondDish,
                    Dessert = foodModel.Dessert, IsMeal = isMealText});
                }
            }

            try
            {
                Events.Add(dayPlanModel.day, eventModels);
            }
            catch (Exception ex)
            {

            }
            
        }

        BindingContext = this;
    }
}

internal class EventModel
{
    public string FirstDish { get; set; }
    public string SecondDish { get; set; }
    public string Dessert { get; set; }
    public string IsMeal { get; set; }
}