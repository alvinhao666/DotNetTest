using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.IO;
using System.Linq;

namespace AopDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            IConfiguration conf = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                                                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) //热加载，\bin\Debug\netcoreapp2.2\appsettings.json
                                                        .Build();

            services.AddLogging(a => a.AddConfiguration(conf.GetSection("Logging")).AddConsole());


            var builder = new ContainerBuilder();
            builder.Populate(services);//Autofac.Extensions.DependencyInjection


            //注册服务
            builder.Register(c => new AOPTest());

            //一定要在你注入的服务后面加上EnableInterfaceInterceptors来开启你的拦截
            builder.RegisterType<TestService1>().As<ITestService1>().PropertiesAutowired().EnableInterfaceInterceptors(); //可现实aop
            builder.RegisterType<TestService2>().As<ITestService2>().PropertiesAutowired().EnableInterfaceInterceptors().InterceptedBy(typeof(AOPTest)); //可现实aop
            builder.RegisterType<TestService3>().As<ITestService3>().PropertiesAutowired();

            builder.RegisterType<AOPTest>().PropertiesAutowired();

            //一定要在你注入的服务后面加上EnableInterfaceInterceptors来开启你的拦截
            var container = builder.Build();
            var service1 = container.Resolve<ITestService1>();
            var service2 = container.Resolve<ITestService2>();
            var service3 = container.Resolve<ITestService3>();


            service1.GetString();
            service2.GetString();
            service3.GetString();


            Console.Read();
        }
    }


}
