using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using VacationManager.WEB.Mappings;
using WebGrease.Css.Extensions;
using VacationManager.BLL.Mappings;
using VacationManager.BLL.Mappings.Helpers;
using VacationManager.DAL.Mapping;
using VacationManager.DAL.Mapping.Helpers;

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

                //string mapBLL = "VacationManager.BLL.Mappings";
                //string mapDAL = "VacationManager.DAL.Mapping";

                //var dal = MapHelperDAL.GetTypesForMapping(mapDAL).ToList();
                //var bll = MapHelperBLL.GetTypesForMapping(mapBLL).ToList();

                Mapper.Initialize(cfg =>
                {
                    //foreach (var ty in dal)
                    //{
                    //    dynamic tt = Activator.CreateInstance(ty);
                    //    cfg.AddProfile(tt.GetType());
                    //}
                    //bll.ToList().ForEach(t => cfg.AddProfile(t.BaseType));

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

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["lang"];
            if (cookie?.Value != null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
            }
        }
    }
}
