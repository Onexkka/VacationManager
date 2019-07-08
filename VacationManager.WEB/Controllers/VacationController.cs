﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using AutoMapper;
using VacationManager.BLL.Contracts;
using VacationManager.BLL.DataModels;
using VacationManager.WEB.Extensions;
using VacationManager.WEB.Models;

namespace VacationManager.WEB.Controllers
{
    public class VacationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IVacationService _vacationService;

        public VacationController(IUserService userService, IVacationService vacationService)
        {
            _userService = userService;
            _vacationService = vacationService;
        }
        // GET: Vacation
        [HttpGet]
        public async Task<ActionResult> GetAllVacationJson(DateTime dateStart, DateTime dateEnd)
        {
            var vacationViewModel = Mapper.Map<IEnumerable<VacationDTO>, IEnumerable<VacationViewModel>>(await _vacationService.GetVacationAsync(dateStart, dateEnd));
            return Json(vacationViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> TakeVacation(VacationViewModel vacation)
        {
            // vacation.DateStart = Convert.ToDateTime(Request.Form["DateStart"]);
            var vacDto = Mapper.Map<VacationViewModel, VacationDTO>(vacation);
            if (ModelState.IsValid)
            {
                var message = await _vacationService.TakeVacation(vacDto, User.Identity.GetUserIdGuid());
                return Content(message);
            }
            return Content("Error");
        }
    }
}