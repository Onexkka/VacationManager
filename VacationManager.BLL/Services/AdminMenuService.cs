using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VacationManager.BLL.Contracts;
using VacationManager.BLL.DataModels;
using VacationManager.BLL.Mappings;
using VacationManager.DAL;
using VacationManager.DAL.Contracts;
using VacationManager.Data.Entities;

namespace VacationManager.BLL.Services
{
    public class AdminMenuService : BaseService, IAdminMenuService
    {
        public AdminMenuService(IUnitOfWork uow)
            : base(uow)
        {
        }
        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = UnitOfWork.GetRepository<User>().AllIncluding(u => u.Roles);

            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }
    }
}
