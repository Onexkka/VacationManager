using VacationManager.Data.Entities;
using VacationManager.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;

namespace VacationManager.BLL.Identity
{
    public class VacationManagerUserManager : UserManager<User, Guid>
    {
        public VacationManagerUserManager(IUserStore<User, Guid> store) : base(store)
        {
        }

        public static VacationManagerUserManager Create(IdentityFactoryOptions<VacationManagerUserManager> options,
            IOwinContext context)
        {
            var manager = new VacationManagerUserManager(new VacationManagerUserStore(context.Get<VacationManagerDbContext>()));
            var provider = new DpapiDataProtectionProvider("Sample");
            manager.UserTokenProvider = new DataProtectorTokenProvider<User, Guid>(provider.Create("EmailConfirmation"));
            return manager;
        }
    }
}
