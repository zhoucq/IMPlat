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
using AutoMapper;
using Imp.Admin.Infrastructure;
using Imp.Admin.Models.Users;
using Imp.Core.Data;
using Imp.Core.Domain.Users;
using Imp.Data;
using Imp.Services.Files;
using Imp.Services.Security;
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
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UserService)).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType(typeof(FileService)).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType(typeof(PermissionService)).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType(typeof(FormsAuthenticationService))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            // builder.Register<IAuthenticationService>(m => new FormsAuthenticationService()).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();


            builder.Register<IDbContext>(c =>
                new ImpObjectContext("data source=(local);initial catalog=ImpDev;user id=sa;password=P@ssword"))
                .InstancePerLifetimeScope();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AutoMapperStartup.Execute();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
