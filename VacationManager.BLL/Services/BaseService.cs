using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.DAL.Contracts;
using VacationManager.Data.Entities;

namespace VacationManager.BLL.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork UnitOfWork;
        //protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public BaseService(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }
    }
}
