using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.BLL.DataModels;
using VacationManager.Data.Entities;

namespace VacationManager.BLL.Contracts
{
    public interface IUserService
    {
        // RoleDTO GetRole(string name);
        Task<UserDTO>GetUserAsync(Guid id); // UserDTO GetUser(Guid? id, string email);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        void UpdateUserAsync(UserDTO userDto);
    }
}
