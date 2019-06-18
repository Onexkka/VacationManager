using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Data.Entities;
using VacationManager.Data.Identity;

namespace VacationManager.BLL.Identity
{
    public class VacationManagerUserStore : UserStore<User, Role, Guid, AspnetUserLogin, AspnetUserRole, AspnetUserClaim>
    {
        public VacationManagerUserStore(DbContext context) : base(context)
        {
        }
    }
}
