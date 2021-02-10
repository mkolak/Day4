using Autofac;
using Day4.Repository.Common;
using System;

namespace Day4.Repository
{
    public class EmployeeRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EmployeeRepository()).As<IEmployeeRepository>();
        }
    }
}
