using Autofac;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 属性注入
{
    public class DefaultModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();

            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes().Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();

            builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired(); //允许属性注入

        }
    }
}
