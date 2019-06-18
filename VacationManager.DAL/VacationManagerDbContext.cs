using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.DAL.Mapping;
using VacationManager.Data.Entities;
using VacationManager.Data.Identity;

namespace VacationManager.DAL
{
    public class VacationManagerDbContext : IdentityDbContext<User, Role, Guid, AspnetUserLogin, AspnetUserRole, AspnetUserClaim>
    {
        public VacationManagerDbContext() 
            : base("VacationManagerDbContext")
        {
        }

        public DbSet<Vacation> Vacations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new VacationMap());

            //modelBuilder.Configurations.Add(new InitiativeMap());
        }

        public static VacationManagerDbContext Create()
        {
            return new VacationManagerDbContext();
        }
    }
}
