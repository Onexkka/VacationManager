namespace VacationManager.DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VacationManager.Data.Entities;
    using VacationManager.Data.Enums;
    using VacationManager.Data.Identity;

    public sealed class Configuration : DbMigrationsConfiguration<VacationManagerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VacationManagerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Create roles of application
            var roleStore = new RoleStore<Role, Guid, AspnetUserRole>(context);
            var roleManager = new RoleManager<Role, Guid>(roleStore);

            if (!roleManager.RoleExists(UserRoles.SuperAdmin))
            {
                roleManager.Create(new Role { Id = new Guid("0791A1C6-6598-45C7-B7DB-000000000000"), Name = UserRoles.SuperAdmin });
                roleManager.Create(new Role { Id = new Guid("0791A1C6-6598-45C7-B7DB-111111111111"), Name = UserRoles.User });
            }

            var userStore = new UserStore<User, Role, Guid, AspnetUserLogin, AspnetUserRole, AspnetUserClaim>(context);
            var userManager = new UserManager<User, Guid>(userStore);

            if (!context.Users.Any(x => x.Email == "service@admin.com"))
            {
                var superAdmin = new User()
                {
                    FirstName = "Service",
                    LastName = "Admin",
                    Email = "service@admin.com",
                    UserName = "service@admin.com",
                    CreatedAt = DateTime.UtcNow,
                    LastModifiedAt = DateTime.UtcNow
                };

                userManager.Create(superAdmin, "Qq!123");
                userManager.AddToRole(superAdmin.Id, UserRoles.SuperAdmin);
            }

            var defaultUsers = new List<User>();

            if (!context.Users.Any(x => x.Email == "user1@mail.com") && !context.Users.Any(x => x.Email == "user2@mail.com"))
            {
                for(int i = 1; i < 3; ++i)
                {
                    var user = new User()
                    {
                        FirstName = "User" + i,
                        Email = "user" + i + "@mail.com",
                        UserName = "user" + i + "@mail.com",
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow
                    };

                    defaultUsers.Add(user);

                    userManager.Create(user, "Qq!123");
                    userManager.AddToRole(user.Id, UserRoles.User);
                }
            }

            //var defaultVacation = new List<Vacation>
            //{
            //    new Vacation()
            //    {
            //        UserId = defaultUsers[0].Id,
            //        User = defaultUsers[0],
            //        DateStart = new DateTime(2019, 6, 10),
            //        DateEnd = new DateTime(2019, 6, 20),
            //        CreatedAt = DateTime.UtcNow
            //    },
            //    new Vacation()
            //    {
            //        UserId = defaultUsers[1].Id,
            //        User = defaultUsers[1],
            //        DateStart = new DateTime(2019, 6, 12),
            //        DateEnd = new DateTime(2019, 6, 25),
            //        CreatedAt = DateTime.UtcNow
            //    },
            //    new Vacation()
            //    {
            //        UserId = defaultUsers[1].Id,
            //        User = defaultUsers[1],
            //        DateStart = new DateTime(2019, 7, 12),
            //        DateEnd = new DateTime(2019, 7, 25),
            //        CreatedAt = DateTime.UtcNow
            //    }
            //};

            //context.Vacations.AddRange(defaultVacation);
            context.SaveChanges();
        }
    }
}
