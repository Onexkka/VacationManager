using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationManager.BLL.Contracts;

namespace VacationManager.WEB.Controllers
{
    public class AdminMenuController : Controller
    {
        IAdminMenuService adminMenuService;

        public AdminMenuController(IAdminMenuService adminMenuService)
        {
            this.adminMenuService = adminMenuService;
        }

        // GET: AdminMenu
        public ActionResult Index()
        {
            var users = adminMenuService.GetAllUsers();
            return View(users);
        }
    }
}