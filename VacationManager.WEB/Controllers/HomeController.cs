using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationManager.BLL.Contracts;
using VacationManager.WEB.Models;

namespace VacationManager.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUserService _userService;

        public HomeController(IUserService userService)
        {
            this._userService = userService;
        }

        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult _Calendar(int? month)
        {
            MonthViewModel[] calendar = new MonthViewModel[3];
            month = month ?? DateTime.Now.Month;
            DateTime date = new DateTime(DateTime.Now.Year, month.Value, 1);
            date = date.AddMonths(-1);
            month = date.Month;
            for (int m = 0; m < 3; m++)
            {
                DayViewModel[,] days = new DayViewModel[7, 6];

                int offset = (int) date.DayOfWeek;
                if (offset == 0)
                    offset = 7;
                offset--;
                date = date.AddDays(offset * -1);

                Random rnd = new Random(); // test

                for (int i = 0; i != 6; i++)
                {
                    for (int j = 0; j != 7; j++)
                    {
                        days[j, i] = new DayViewModel()
                        {
                            Date = date,
                            IsNotCurrentMonth = date.Month != month,
                            IsWeekendOrHoliday = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday,
                            Level = rnd.Next(4) // test
                        };
                        date = date.AddDays(1);
                    }
                }

                calendar[m] = new MonthViewModel()
                {
                    Date = date.AddMonths(-1),
                    Days = days
                };

                date = new DateTime(date.Year, date.Month, 1);
                month = date.Month;
            }

            return PartialView(calendar);
        }
    }
}