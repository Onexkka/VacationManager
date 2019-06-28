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
            var vacations = await UnitOfWork.GetRepository<Vacation>().All().ProjectTo<VacationDTO>().ToArrayAsync();
            return vacations;
            // return Mapper.Map<IEnumerable<Vacation>, IEnumerable<VacationDTO>>(vacations);
        }

        public async Task<string> TakeVacation(VacationDTO vacationDto, Guid userId)
        {
            var count = await UnitOfWork.GetRepository<Vacation>()
                .Where(v =>
                    vacationDto.DateStart >= v.DateStart && vacationDto.DateStart <= v.DateEnd
                    || vacationDto.DateEnd >= v.DateStart && vacationDto.DateEnd <= v.DateEnd).CountAsync();

            if (count < 3)
            {
                var item = Mapper.Map<VacationDTO, Vacation>(vacationDto);
                item.UserId = userId;
                item.CreatedAt = DateTime.Now;
                UnitOfWork.GetRepository<Vacation>().Add(item);
                await UnitOfWork.CommitAsync();
                return ("Success take vacation");
            }

            return ("Fail take vacation");
        }
    }
}
