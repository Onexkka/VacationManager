using System;
using System.Web.Mvc;
using VacationManager.WEB.Models;

namespace VacationManager.WEB.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult _Calendar()
        {
            DayViewModel[,] days = new DayViewModel[6, 7];
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            int offset = (int)date.DayOfWeek;

            if (offset == 0)
                offset = 7;

            offset--;
            date = date.AddDays(offset * -1);

            for (int i = 0; i != 6; i++)
            {
                for (int j = 0; j != 7; j++)
                {
                    days[i, j] = new DayViewModel()
                    {
                        Date = date,
                        IsNotCurrentMonth = date.Month != DateTime.Now.Month,
                        IsWeekendOrHoliday = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday,
                        IsToday = date.Date == DateTime.Now.Date
                    };
                    date = date.AddDays(1);
                }
            }

            CalendarViewModel calendar = new CalendarViewModel()
            {
                Date = DateTime.Now,
                Days = days
            };
            return PartialView(calendar);
        }
    }
}