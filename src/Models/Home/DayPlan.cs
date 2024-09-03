using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPICHI.Models.Home
{
    class DayPlan
    {
        [PrimaryKey, AutoIncrement]
        public int DayPlanId { get; set; }
        [Unique]
        public DateTime day { get; set; }
        public List<Food>? foods { get; set; }
        public string? notes { get; set; }

    }
}
