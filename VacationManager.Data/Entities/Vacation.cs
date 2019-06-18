using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationSystem.Data.Entities.Base;

namespace VacationSystem.Data.Entities
{
    public class Vacation : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
