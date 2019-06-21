using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.BLL.Contracts;
using VacationManager.Data.Entities;
using VacationManager.DAL.Contracts;

namespace VacationManager.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork uow) : base(uow)
        {
        }

        public Role GetRole(string name)
        {
            return UnitOfWork.GetRepository<Role>().All().First(x => x.Name == name);
        }
    }
}
