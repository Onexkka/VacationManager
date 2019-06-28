using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VacationManager.BLL.Contracts;
using VacationManager.Data.Entities;
using VacationManager.WEB.Models;

namespace VacationManager.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IVacationService _vacationService;

        public HomeController(IUserService userService, IVacationService vacationService)
        {
            this._userService = userService;
            this._vacationService = vacationService;
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
    }
}