using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using AutoMapper;
using VacationManager.BLL.Contracts;
using VacationManager.BLL.DataModels;
using VacationManager.WEB.Models;

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

        [HttpPost]
        public async Task<ActionResult> TakeVacation(VacationViewModel vacation, Guid userId)
        {
            var d = vacation.DateStart;
            var vacDto = Mapper.Map<VacationViewModel, VacationDTO>(vacation);
            if (ModelState.IsValid)
            {
                var result = await _vacationService.TakeVacation(vacDto, userId);
                if (result > 2)
                    return Content("Can take vac");
                return Content("Success take vac");
            }
            return Content("Error");
        }
    }
}