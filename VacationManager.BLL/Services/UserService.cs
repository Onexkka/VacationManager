using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VacationManager.BLL.Contracts;
using VacationManager.BLL.DataModels;
using VacationManager.Data.Entities;
using VacationManager.DAL.Contracts;

namespace VacationManager.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork uow) : base(uow)
        {
        }

        //public RoleDTO GetRole(string name)
        //{
        //    var role = UnitOfWork.GetRepository<Role>().All().First(x => x.Name == name);
        //    return Mapper.Map<Role, RoleDTO>(role);
        //}

        public async Task<UserDTO> GetUserAsync(Guid id)
        {
            var user = UnitOfWork.GetRepository<User>().First(u => u.Id == id);
            return Mapper.Map<User, UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await UnitOfWork.GetRepository<User>().AllIncluding(u => u.Roles).ToArrayAsync();

            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public void UpdateUserAsync(UserDTO userDto)
        {
            var user = Mapper.Map<UserDTO, User>(userDto);
            UnitOfWork.GetRepository<User>().Update(user);
        }
    }
}
