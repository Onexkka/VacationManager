using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Data.Entities;

namespace VacationManager.BLL.Contracts
{
    public interface IUserService
    {
        Role GetRole(string name);
    }
}
