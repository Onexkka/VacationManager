using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationSystem.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VacationSystem.Data.Identity
{
    public class AspnetUserRole : IdentityUserRole<Guid>
    {
        public virtual Role Role { get; set; }
    }
}
