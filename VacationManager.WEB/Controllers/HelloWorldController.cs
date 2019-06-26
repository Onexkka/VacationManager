using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PerpetuumSoft.Knockout;
using VacationManager.BLL.Contracts;
using VacationManager.WEB.Models;

namespace VacationManager.WEB.Controllers
{
    public class HelloWorldController : KnockoutController
    {
        private readonly IAdminService _adminMenuService;

        public HelloWorldController(IAdminService adminMenuService)
        {
            this._adminMenuService = adminMenuService;
        }

        // GET: AdminMenu
        public async Task<ActionResult> Index()
        {
            ViewBag.user = User.Identity;
            var u = User.Identity;
            var users = await _adminMenuService.GetAllUsersAsync();
            return View(users);
        }
    }
}