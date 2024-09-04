using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace APPICHI.Models.Home
{
    [Table("FoodModel")]
    public class FoodModel
    {
        [PrimaryKey, AutoIncrement]
        public int FoodId { get; set; }
        public bool IsMeal { get; set; }
        [MaxLength(250)]
        public string? FirstDish { get; set; }
        [MaxLength(250)]
        public string? SecondDish { get; set; }
        [MaxLength(250)]
        public string? Dessert { get; set; }
        public int DayPlanId { get; set; }
        public DayPlanModel DayPlan { get; set; }
    }
}
