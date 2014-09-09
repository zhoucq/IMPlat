using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Imp.Core.Data;
using Imp.Core.Domain.Users;
using Imp.Data;
using Imp.Services.Users;

namespace Imp.Admin
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // autofac di
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType(typeof(UserService)).AsImplementedInterfaces();
            //builder.RegisterType(typeof(EfRepository<User>)).AsImplementedInterfaces();
            //builder.RegisterType(typeof(EfRepository<Role>)).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>));
            // builder.RegisterType(typeof(ImpObjectContext)).AsImplementedInterfaces();

            builder.Register<IDbContext>(c => new ImpObjectContext("data source=(local);initial catalog=ImpDev;user id=sa;password=P@ssword")).InstancePerLifetimeScope();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}