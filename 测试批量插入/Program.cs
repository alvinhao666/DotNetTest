using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sino.Dapper;
using Microsoft.Extensions.DependencyInjection;
using Sino.Hf.EtcService;
using 爬取电影天堂;

namespace 测试批量插入
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();




            //注入
            services.AddTransient<IETCInvoiceDetailRepository, ETCInvoiceDetailRepository>();

            AutofacContainer.Build(services);
            var rep = AutofacContainer.Resolve<IETCInvoiceDetailRepository>();

            services.AddDapper("Data Source=47.96.143.165;port=3306;user id=root;password=5802486;Initial Catalog=tmsystem;convertzerodatetime=True;AutoEnlist=false;Charset=utf8;", "Data Source=47.96.143.165;port=3306;user id=root;password=5802486;Initial Catalog=tmsystem;convertzerodatetime=True;AutoEnlist=false;Charset=utf8;");

            //rep.InsertList()

            Console.ReadKey();
        }
    }
}
