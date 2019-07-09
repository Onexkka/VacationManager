using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            return await UnitOfWork.GetRepository<Vacation>().All().ProjectTo<VacationDTO>().ToArrayAsync();
        }

        public async Task<IEnumerable<VacationDTO>> GetVacationAsync(DateTime dateStart, DateTime dateEnd)
        {
            var vacation =  await UnitOfWork.GetRepository<Vacation>()
                .Where(v => v.DateStart.Month >= dateStart.Month || v.DateEnd.Month <= dateEnd.Month)
                .ProjectTo<VacationDTO>()
                .ToArrayAsync();
            return vacation;
        }

        public async Task<bool> TakeVacation(VacationDTO vacationDto, Guid userId)
        {
            var count = await UnitOfWork.GetRepository<Vacation>()
                .Where(v =>
                    vacationDto.DateStart >= v.DateStart && vacationDto.DateStart <= v.DateEnd
                    || vacationDto.DateEnd >= v.DateStart && vacationDto.DateEnd <= v.DateEnd).CountAsync();

            if (count < 3)
            {
                var item = Mapper.Map<VacationDTO, Vacation>(vacationDto);
                item.UserId = userId;
                UnitOfWork.GetRepository<Vacation>().Add(item);
                await UnitOfWork.CommitAsync();
                return true;
            }

            return false;
        }
    }
}
