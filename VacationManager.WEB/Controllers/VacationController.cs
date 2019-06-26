using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VacationManager.BLL.Contracts;

namespace VacationManager.WEB.Controllers
{
    public class VacationController : Controller
    {
        private IUserService _userService;
        private IVacationService _vacationService;

        public VacationController(IUserService userService, IVacationService vacationService)
        {
            this._userService = userService;
            this._vacationService = vacationService;
        }
        // GET: Vacation
        [HttpGet]
        public async Task<ActionResult> GetAllVacationJSON()
        {
            return Json(await _vacationService.GetAllVacationAsync(), JsonRequestBehavior.AllowGet);
        }
    }
}