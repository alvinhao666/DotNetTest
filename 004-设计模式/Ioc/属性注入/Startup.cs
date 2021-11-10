using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace 属性注入
{
    //ASP.NET Core 的标准依赖注入容器不支持属性注入。但是你可以使用其他容器支持属性注入
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //当框架（通过一个命名为DefaultControllerActivator的服务）要创建一个控制器的实例时，它会解析IServiceProvider的所有构造函数依赖项.在上面的代码中，它会使用Autofac容器来解析产生类。

            //这样就能初步的达到我们替换IOC容器的的效果了..



            //但是，这个操作过程与asp.net MVC的不同之处在于.控制器本身不会从容器中解析出来，所以服务只能从它的构造器参数中解析出来。

            //所以.这个过程,让我们无法使用Autofac的一些更高级功能.比如属性注入(关于属性注入的好坏..属于仁者见仁智者见智的东西, 这里我们不讨论它是好还是坏.)

            //Replace代码的意思：使用ServiceBasedControllerActivator替换DefaultControllerActivator（意味着框架现在会尝试从IServiceProvider中解析控制器实例，也就是return new AutofacServiceProvider(Container);
            
            services.AddMvc();
            //替换控制器所有者,详见有道笔记
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());


            var builder = new ContainerBuilder();


            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();

            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes().Where(type => typeof(Controller).IsAssignableFrom(type)).ToArray();

            builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired(); //允许属性注入

            builder.Populate(services);


            var Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
