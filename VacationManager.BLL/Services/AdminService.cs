using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class AdminService : BaseService, IAdminService
    {
        public AdminService(IUnitOfWork uow): base(uow)
        {
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await UnitOfWork.GetRepository<User>().AllIncluding(u => u.Roles).ToArrayAsync();
            
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }
    }
}
