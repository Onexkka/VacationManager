using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VacationManager.BLL.Contracts;
using VacationManager.BLL.DataModels;
using VacationManager.DAL.Contracts;
using VacationManager.Data.Entities;

namespace VacationManager.BLL.Services
{
    public class VacationService : BaseService, IVacationService
    {
        public VacationService (IUnitOfWork uow) : base(uow)
        {
        }
        public async Task<IEnumerable<VacationDTO>> GetAllVacationAsync()
        {
            var vacations = await UnitOfWork.GetRepository<Vacation>().All().ToArrayAsync();

            return Mapper.Map<IEnumerable<Vacation>, IEnumerable<VacationDTO>>(vacations);
        }
    }
}
