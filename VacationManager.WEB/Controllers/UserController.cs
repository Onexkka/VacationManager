using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using VacationManager.BLL.Contracts;
using VacationManager.BLL.DataModels;
using VacationManager.WEB.Models;

namespace VacationManager.WEB.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        private IVacationService _vacationService;

        public UserController(IUserService userService, IVacationService vacationService)
        {
            this._userService = userService;
            this._vacationService = vacationService;
        }

        public async Task<ActionResult> Index()
        {
            var userDto = await _userService.GetAllUsersAsync();
            var user = Mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(userDto);
            return View(user);
        }

        // GET: User
        public async Task<ActionResult> Details(Guid id)
        {
            var userDto = await _userService.GetUserAsync(id);
            var userVM = Mapper.Map<UserDTO, UserViewModel>(userDto);
            return PartialView(userVM); 
        }
    }
}