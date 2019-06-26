using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using VacationManager.BLL.Mappings;
using VacationManager.WEB.Mappings;

namespace VacationManager.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        [Obsolete] // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        protected void Application_Start()
        {
            try
            {
                UpdateDatabase();

                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                Mapper.Initialize(cfg =>
                {
                    cfg.AddProfile(typeof(UserDTOMap));
                    cfg.AddProfile(typeof(RoleDTOMap));
                    cfg.AddProfile(typeof(VacationDTOMap));
                    cfg.AddProfile(typeof(VacationVMMap));
                    cfg.AddProfile(typeof(UserVMMap));
                    cfg.AddProfile(typeof(RoleVMMap));
                });
            }
            catch (Exception ex)
            {
                var exSource = ex.Source;
                throw;
            }

        }

        private void UpdateDatabase()
        {
            var migrationConfig = new VacationManager.DAL.Migrations.Configuration();
            var migrator = new DbMigrator(migrationConfig);
            migrator.Update();
        }
    }
}
