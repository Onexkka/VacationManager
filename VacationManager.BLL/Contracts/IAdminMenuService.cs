using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.BLL.DataModels;

namespace VacationManager.BLL.Contracts
{
    public interface IAdminMenuService
    {
        IEnumerable<UserDTO> GetAllUsers();
    }
}
