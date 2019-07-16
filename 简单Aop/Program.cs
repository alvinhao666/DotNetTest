using AspectCore.Configuration;
using AspectCore.DynamicProxy;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AopDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IMysqlDriver, MysqlDriver>();
            IServiceProvider serviceProvider = services.BuildAspectInjectorProvider();

            var mysql=serviceProvider.GetService<IMysqlDriver>();

            mysql.GetData(1);
            Console.ReadKey();
        }
    }


    public class MysqlInterceptorAttribute : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            Console.WriteLine("开始查数据");
            await next(context);
            Console.WriteLine("结束");
        }
    }

    public interface IMysqlDriver
    {
        [MysqlInterceptor]
        void GetData(int id);
    }


    public class MysqlDriver : IMysqlDriver
    {
        public void GetData(int id)
        {
            Console.WriteLine($"数据为{id}");
        }
    }
}
