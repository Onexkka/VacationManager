using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Data.Entities.Base;

namespace VacationManager.Data.Entities
{
    public class Vacation : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
    }
}
