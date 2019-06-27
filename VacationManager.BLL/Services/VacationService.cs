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

        public async Task<int> TakeVacation(VacationDTO vacationDto, Guid userId)
        {
            var vacation = await UnitOfWork.GetRepository<Vacation>()
                .Where(v =>
                    v.DateStart.Month == vacationDto.DateStart.Month
                    || v.DateStart.Month == vacationDto.DateEnd.Month
                    || v.DateEnd.Month == vacationDto.DateStart.Month
                    || v.DateEnd.Month == vacationDto.DateEnd.Month).ToArrayAsync();

            int count = 0;
            foreach (var vac in vacation)
            {
                bool v1 = vacationDto.DateStart >= vac.DateStart && vacationDto.DateStart <= vac.DateEnd;
                bool v2 = vacationDto.DateEnd >= vac.DateStart && vacationDto.DateEnd <= vac.DateEnd;
                if (v1 || v2)
                    count++;
            }

            if (count < 3)
            {
                var item = Mapper.Map<VacationDTO, Vacation>(vacationDto);
                item.UserId = userId;
                item.CreatedAt = DateTime.Now;
                UnitOfWork.GetRepository<Vacation>().Add(item);
                int c = await UnitOfWork.CommitAsync();
                if (c == 0)
                    count += 10;
            }

            return count;
        }
    }
}
