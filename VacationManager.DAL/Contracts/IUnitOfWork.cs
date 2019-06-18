using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Data.Contracts;

namespace VacationManager.DAL.Contracts
{
    public interface IUnitOfWork
    {
        IBaseRepository<T> GetRepository<T>() where T : class;
        Task<int> CommitAsync();
        int Commit();
        bool AutoDetectChanges { get; set; }
        List<T> ExecuteStoredProcedure<T>(string procedureName);
    }
}
