using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationManager.BLL.Contracts;

namespace VacationManager.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        //[Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Super Admin"))
                ViewBag.test = userService.GetRole("Super Admin");
            else
                ViewBag.test = "You not admin";
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
    }
}