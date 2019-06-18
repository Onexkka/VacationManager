using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VacationManager.Data.Identity
{
    public class AspnetUserRole : IdentityUserRole<Guid>
    {
        public virtual Role Role { get; set; }
    }
}
