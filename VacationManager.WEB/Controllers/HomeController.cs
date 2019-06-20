﻿using System;
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

        public ActionResult _Calendar()
        {
            DayViewModel[,] days = new DayViewModel[7, 6];
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            int offset = (int)date.DayOfWeek;

            if (offset == 0)
                offset = 7;

            offset--;
            date = date.AddDays(offset * -1);

            Random rnd = new Random();
            for (int i = 0; i != 6; i++)
            {
                for (int j = 0; j != 7; j++)
                {
                    days[j, i] = new DayViewModel()
                    {
                        Date = date,
                        IsNotCurrentMonth = date.Month != DateTime.Now.Month,
                        IsWeekendOrHoliday = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday,
                        IsToday = date.Date == DateTime.Now.Date,
                        Level = rnd.Next(4)
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