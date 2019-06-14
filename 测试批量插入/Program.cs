using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sino.Dapper;
using Microsoft.Extensions.DependencyInjection;
using Sino.Hf.EtcService;
using 爬取电影天堂;
using System.Linq;

namespace 测试批量插入
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();


            services.AddDapper("Data Source=rm-bp1sxihspw88jl9fp2o.mysql.rds.aliyuncs.com;port=3306;user id=sino;password=sino5802486A;Initial Catalog=tmsystem;convertzerodatetime=True;AutoEnlist=false;Charset=utf8;", "Data Source=rm-bp1sxihspw88jl9fp2o.mysql.rds.aliyuncs.com;port=3306;user id=sino;password=sino5802486A;Initial Catalog=tmsystem;convertzerodatetime=True;AutoEnlist=false;Charset=utf8;");

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

            //await rep.InsertList(list);

            var item = await rep.GetCarrierOrderDetail(Guid.Parse("7dd9599f-b309-43e4-8952-1c825c94426c"));

            var order = item.OrderList.OrderBy(a => a.OrderId).FirstOrDefault();
            var num = item.CarrierOrderCode;//运单编号
                var plateNum = item.CarCode;
                var plateColor = (int)CarPlateColor.Yellow;
                var startTime = order.RealDeliveryTime.Value.ToString();//运单开始时间
                var sourceAddr = order.OriginAddress;//运单开始地址
                var destAddr = order.DestinationAddress;//运单目的地址
                var predictEndTime = order.ArrivalTime.ToString();//运单预计完成时间
                var fee = Convert.ToInt64(item.Contract.TotalPrice * 100);//大于0的整数，单位：分
                var titleType = 1;


            Console.WriteLine("成功");
            Console.ReadKey();
        }
    }
}
