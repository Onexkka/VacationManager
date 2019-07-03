using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.BLL.DataModels;
using VacationManager.Data.Entities;

namespace VacationManager.BLL.Contracts
{
    public interface IVacationService
    {
        Task<IEnumerable<VacationDTO>> GetAllVacationAsync();
        Task<IEnumerable<VacationDTO>> GetVacationAsync(DateTime dateStart, DateTime dateEnd);
        Task<string> TakeVacation(VacationDTO vacationDto, Guid userId);
    }
}
