using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPICHI.Models.Home
{
    [Table("DayPlanModel")]
    public class DayPlanModel
    {
        [PrimaryKey, AutoIncrement]
        public int DayPlanId { get; set; }
        [Unique]
        public DateTime day { get; set; }
        public List<FoodModel>? foods { get; set; }
        [MaxLength(250)]
        public string? notes { get; set; }

    }
}
