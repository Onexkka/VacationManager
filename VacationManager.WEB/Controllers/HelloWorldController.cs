using KnockoutMvcDemo.Controllers;
using PerpetuumSoft.Knockout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationManager.WEB.Models;

namespace VacationManager.WEB.Controllers
{
    public class HelloWorldController : KnockoutController
    {
        public ActionResult Index()
        {
            //InitializeViewBag("Hello world");
            return View(new HelloWorldModel
            {
                FirstName = "Steve",
                LastName = "Sanderson"
            });
        }
    }
}