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
        Task<int> TakeVacation(VacationDTO vacationDto, Guid userId);
    }
}
