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


            services.AddDapper("Data Source=119.27.173.241;Database=haohaoPlay;User ID=root;Password=Mimashi@7758258;CharSet=utf8;port=3306;sslmode=none", "Data Source=119.27.173.241;Database=haohaoPlay;User ID=root;Password=Mimashi@7758258;CharSet=utf8;port=3306;sslmode=none");

            //注入
            //services.AddTransient<IIdentifyProvider, IdentifyProvider>();

            //services.AddTransient<IETCInvoiceDetailRepository, ETCInvoiceDetailRepository>();

            services.AutoDependency(typeof(IIdentifyProvider));
            services.AutoDependency(typeof(IETCInvoiceDetailRepository));

            AutofacContainer.Build(services);
            var rep = AutofacContainer.Resolve<IETCInvoiceDetailRepository>();

            var list = new List<ETCInvoiceDetail>();

            list.Add(new ETCInvoiceDetail()
            {
                Id = Guid.NewGuid(),
                BriefId = Guid.NewGuid(),
                CarrierOrderId = Guid.NewGuid(),
                InvoiceNum = "1111",
                InvoiceCode = "2222",
                InvoiceMakeTime = DateTime.Now.ToString(),
                InvoiceUrl = "HTTP://WWW.BAIDU.COM",
                InvoiceHtmlUrl = "HTTP://WWW.BAIDU.COM",
                EnStation = "上海",
                ExStation = "北京",
                ExTime = DateTime.Now.ToString(),
                Fee = 8888,
                TotalTaxAmount = 222,
                PlateNum = "苏l0l937",
                VehicleType = (ETCVehicleType)1,
                SellerName = "国浩公司",
                SellerTaxpayerCode = "121212",
                WaybillNum = "12131",
                WaybillStatus = (ETCWayBillStatus)3,
                WaybillStartTime =DateTime.Now.ToString(),
                WaybillEndTime = DateTime.Now.ToString(),
                TotalAmount = 1111,
                TaxRate = 2.2,
                InvoiceType = "sdfsf",
                Amount = 1111,
                TransactionId ="123",
                ReceiveInfo = "成功",
                ReceiveTime = DateTime.Now.ToString(),
                CreatorUserId = -1,
                CreationTime = DateTime.Now
            });

            list.Add(new ETCInvoiceDetail()
            {
                Id = Guid.NewGuid(),
                BriefId = Guid.NewGuid(),
                CarrierOrderId = Guid.NewGuid(),
                InvoiceNum = "1111",
                InvoiceCode = "2222",
                InvoiceMakeTime = DateTime.Now.ToString(),
                InvoiceUrl = "HTTP://WWW.BAIDU.COM",
                InvoiceHtmlUrl = "HTTP://WWW.BAIDU.COM",
                EnStation = "上海",
                ExStation = "北京",
                ExTime = DateTime.Now.ToString(),
                Fee = 8888,
                TotalTaxAmount = 222,
                PlateNum = "苏l0l937",
                VehicleType = (ETCVehicleType)1,
                SellerName = "国浩公司",
                SellerTaxpayerCode = "121212",
                WaybillNum = "12131",
                WaybillStatus = (ETCWayBillStatus)3,
                WaybillStartTime = DateTime.Now.ToString(),
                WaybillEndTime = DateTime.Now.ToString(),
                TotalAmount = 1111,
                TaxRate = 2.2,
                InvoiceType = "sdfsf",
                Amount = 1111,
                TransactionId = "123",
                ReceiveInfo = "成功",
                ReceiveTime = DateTime.Now.ToString(),
                CreatorUserId = -1,
                CreationTime = DateTime.Now
            });

            await rep.InsertList(list);

            Console.WriteLine("成功");
            Console.ReadKey();
        }
    }
}
