using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace APPICHI.Models.Home
{
    class Food
    {
        [PrimaryKey, AutoIncrement]
        public int FoodId { get; set; }
        public bool IsMeal { get; set; }
        public string? FirstDish { get; set; }
        public string? SecondDish { get; set; }
        public string? Dessert { get; set; }
        public int DayPlanId { get; set; }
        public DayPlan DayPlan { get; set; }
    }
}
