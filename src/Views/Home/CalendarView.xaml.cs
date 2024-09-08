using APPICHI.Models.Home;
using Plugin.Maui.Calendar.Models;

namespace APPICHI.Views.Home;

public partial class CalendarView : ContentPage
{
    public EventCollection Events { get; set; }

    public CalendarView(List<DayPlanModel> dayPlanModels)
	{
		InitializeComponent();

        Events = new EventCollection
        {
            [DateTime.Now] = new List<EventModel>
            {
                new EventModel { Name = "Cool event1", Description = "This is Cool event1's description!" },
                new EventModel { Name = "Cool event2", Description = "This is Cool event2's description!" }
            }
        };

        foreach (DayPlanModel dayPlanModel in dayPlanModels )
        {
            List<EventModel> eventModels = new List<EventModel>();
            if (!dayPlanModel.foods.Any())
            {
                foreach (FoodModel foodModel in dayPlanModel.foods)
                {
                    eventModels.Add(new EventModel { Name = foodModel.FirstDish, Description = foodModel.SecondDish });
                }
            }

            Events.Add(dayPlanModel.day, eventModels);
        }

        BindingContext = this;
    }
}

internal class EventModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}