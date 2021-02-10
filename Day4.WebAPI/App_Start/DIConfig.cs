using Autofac;
using Autofac.Integration.WebApi;
using Day4.Repository;
using Day4.Repository.Common;
using Day4.Service;
using Day4.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Day4.WebAPI.App_Start
{
    public class DIConfig
    {
        public static void Configure() {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<EmployeeServiceModule>();
            builder.RegisterModule<EmployeeRepositoryModule>();
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}