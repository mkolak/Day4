using System;
using Day4.Service.Common;
using Autofac;
using Day4.Repository.Common;

namespace Day4.Service
{
    public class EmployeeServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EmployeeService(c.Resolve<IEmployeeRepository>())).As<IEmployeeService>().InstancePerDependency();
        }
    }
}
