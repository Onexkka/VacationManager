using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacationManager.WEB.Models
{
    public class DayViewModel
    {
        public DateTime Date { get; set; }
        public bool IsNotCurrentMonth { get; set; }
        public bool IsWeekendOrHoliday { get; set; }
        public int Level { get; set; }
    }
}