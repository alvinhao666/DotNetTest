using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper_Vs_Mapster
{
    public class MapsterTest
    {
        public static void Test()
        {
            List<Order> list = new List<Order> 
            { 
                new Order { OrderNo = "111", Meter = 111, CutCount = 111, OrderNo_D = "222", Meter_D = 222, CutCount_D = 222 },
                new Order { OrderNo = "666", Meter = 666, CutCount = 666 }
            };

            List<OrderDto> newList = new List<OrderDto>();

            var config = new TypeAdapterConfig();

            config.NewConfig<Order, OrderDto>().Map(a => a.OrderNo, b => b.OrderNo_D)
                                    .Map(a => a.Meter, b => b.Meter_D)
                                    .Map(a => a.CutCount, b => b.CutCount_D);
//.NameMatchingStrategy(NameMatchingStrategy.ConvertDestinationMemberName(name => name.Replace("_D", "")));
//.IgnoreMember((member, side) => !member.Type.Name.EndsWith("_D"));
            foreach (var item in list)
            {
                var newItem = item.Adapt<OrderDto>();

                newList.Add(newItem);

                if (!string.IsNullOrWhiteSpace(item.OrderNo_D))
                {
                    newItem = item.Adapt<OrderDto>(config);

                    newList.Add(newItem);
                }

            }

        }


        class OrderDto
        {
            public string OrderNo { get; set; }


            public decimal Meter { get; set; }


            public int CutCount { get; set; }

        }


        class Order
        {
            public string OrderNo { get; set; }


            public decimal Meter { get; set; }


            public int CutCount { get; set; }


            public string OrderNo_D { get; set; }


            public decimal Meter_D { get; set; }


            public int CutCount_D { get; set; }
        }
    }
}
