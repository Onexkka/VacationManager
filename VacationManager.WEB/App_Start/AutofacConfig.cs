using System.Data.Entity;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using VacationManager.BLL.Services;
using VacationManager.Data.Contracts;
using VacationManager.DAL;
using VacationManager.DAL.Contracts;
using VacationManager.DAL.Repositories;
using Owin;

namespace VacationManager.WEB.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterComponents(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            //builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            //builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            //builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Set the dependency resolver to be Autofac
            builder.RegisterType<VacationManagerDbContext>().As<DbContext>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IBaseRepository<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Register the Autofac middleware FIRST, then the Autofac MVC middleware.
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

        }
    }
}