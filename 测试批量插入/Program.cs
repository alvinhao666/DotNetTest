using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sino.Dapper;
using Microsoft.Extensions.DependencyInjection;
using Sino.Hf.EtcService;
using 爬取电影天堂;
using System.Linq;
using Sino.TMSystem.AppService.Order;
using CSRedis;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Caching.Distributed;

namespace 测试批量插入
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();


            //services.AddDapper("Data Source=rm-bp1sxihspw88jl9fp2o.mysql.rds.aliyuncs.com;port=3306;user id=sino;password=sino5802486A;Initial Catalog=tmsystem;convertzerodatetime=True;AutoEnlist=false;Charset=utf8;", "Data Source=rm-bp1sxihspw88jl9fp2o.mysql.rds.aliyuncs.com;port=3306;user id=sino;password=sino5802486A;Initial Catalog=tmsystem;convertzerodatetime=True;AutoEnlist=false;Charset=utf8;");
            services.AddDapper("Data Source=47.96.143.165;port=3306;user id=root;password=5802486;Initial Catalog=tmsystem;convertzerodatetime=True;AutoEnlist=false;Charset=utf8;", "Data Source=47.96.143.165;port=3306;user id=root;password=5802486;Initial Catalog=tmsystem;convertzerodatetime=True;AutoEnlist=false;Charset=utf8;");

            //注入
            //services.AddTransient<IIdentifyProvider, IdentifyProvider>();

            //services.AddTransient<IETCInvoiceDetailRepository, ETCInvoiceDetailRepository>();

            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<IList<ETCInvoice>, GetETCInoviceListOutput>()
                   .ForMember(x => x.Items, a => a.MapFrom(i => i))
                   .ForMember(x => x.TotalCount, a => a.Ignore());

                cfg.CreateMap<ETCInvoice, ETCInoviceDto>();

                cfg.CreateMap<IList<ETCInvoiceDetail>, GetETCInvoiceDetailListOutput>()
                   .ForMember(x => x.Items, a => a.MapFrom(i => i))
                   .ForMember(x => x.TotalCount, a => a.Ignore());

                cfg.CreateMap<ETCInvoiceDetail, ETCInvoiceDetailDto>();
            });

            services.AutoDependency(typeof(IIdentifyProvider));
            services.AutoDependency(typeof(IETCInvoiceDetailRepository));
            services.AutoDependency(typeof(IETCRepository));
            services.AutoDependency(typeof(IETCAppService));
            services.AddTransient<IETCAppService, ETCAppService>();
            

            var csredis = new CSRedisClient("127.0.0.1:6379,abortConnect=false,connectRetry=3,connectTimeout=3000,defaultDatabase=0,syncTimeout=3000,version=3.2.1,responseTimeout=3000");

            //初始化 RedisHelper

            RedisHelper.Initialization(csredis);

            services.AddSingleton<IDistributedCache>(new CSRedisCache(RedisHelper.Instance));

            AutofacContainer.Build(services);
            var rep = AutofacContainer.Resolve<IETCInvoiceDetailRepository>();
            var ETCRep = AutofacContainer.Resolve<IETCRepository>();
            var ser = AutofacContainer.Resolve<IETCAppService>();

            var cache = AutofacContainer.Resolve<IDistributedCache>();

            RedisHelper.Set("rongguohao", 5555);
            RedisHelper.Set("rongguohao2", new ETCCar() { Id=Guid.NewGuid()});
            RedisHelper.Set("rongguohao3", 11111);
            var value = await RedisHelper.GetAsync("rongguohao");
            RedisHelper.Expire("rongguohao", 0);
            value = await RedisHelper.GetAsync("rongguohao");
            var aaa = RedisHelper.Get<ETCCar>("rongguohao2");
            var bbb = RedisHelper.Keys("rongguohao*");

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

            //var item = await rep.GetCarrierOrderDetail(Guid.Parse("7dd9599f-b309-43e4-8952-1c825c94426c"));


            var ids = await ETCRep.GetETCInvoiceList(new ETCInvoiceQueryInput()
            {

                OrderCode = "01812310193",
                CarCode = null,
                RealDeliveryStartTime = null,
                RealDeliveryEndTime = null,
                RealArrivalStartTime = null,
                RealArrivalEndTime = null,
                OrderCarDataIsUpload = true,
                OrderStartDataIsUpload = true,
                OrderEndDataIsUpload = true,
                Count = -1,
                Skip = 0,
                LogisticsId = Guid.Parse("7f062263-c0e0-47c8-9886-67eca77aaf3e")
            });

            //var order = item.OrderList.OrderBy(a => a.OrderId).FirstOrDefault();
            //var num = item.CarrierOrderCode;//运单编号
            //    var plateNum = item.CarCode;
            //    var plateColor = (int)CarPlateColor.Yellow;
            //    var startTime = order.RealDeliveryTime.Value.ToString();//运单开始时间
            //    var sourceAddr = order.OriginAddress;//运单开始地址
            //    var destAddr = order.DestinationAddress;//运单目的地址
            //    var predictEndTime = order.ArrivalTime.ToString();//运单预计完成时间
            //    var fee = Convert.ToInt64(item.Contract.TotalPrice * 100);//大于0的整数，单位：分
            //    var titleType = 1;

            //if (ids != null && ids.Count > 0)
            //{
            //    var listGroup = await HandleList(ids);

            //    foreach (var item in listGroup)
            //    {
            //        //BackgroundJob.Enqueue<IETCService>(x => x.SearchInvoice(item, userId));
            //    }
            //}

            //var sss = await ser.ViewDetail(Guid.Parse("6970f114-5fd9-4f92-b7fb-9c9a286abcba"));

            Console.WriteLine("成功");
            Console.ReadKey();
        }


        private static async Task<List<List<Guid>>> HandleList(List<Guid> ids)
        {
            List<List<Guid>> listGroup = new List<List<Guid>>();
            int j = 100;
            for (int i = 0; i < ids.Count; i += 100)
            {
                List<Guid> cList = new List<Guid>();
                cList = ids.Take(j).Skip(i).ToList();
                j += 100;
                listGroup.Add(cList);
            }
            return listGroup;
        }
    }
}
