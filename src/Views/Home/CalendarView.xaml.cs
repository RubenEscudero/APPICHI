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
                    eventModels.Add(new EventModel { Name = foodModel.FirstDish, Description = foodModel.SecondDish });
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
    public string Name { get; set; }
    public string Description { get; set; }
}