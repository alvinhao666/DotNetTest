using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NLog;
using Sino.AutoMapper;
using Sino.Hf.EtcService;
using Sino.TMSystem;
using Sino.Web.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.TMSystem.AppService.Order
{
    public class ETCAppService : IETCAppService
    {
        protected IAutoMapper Mapper;

        protected IETCRepository ETCRep;

        protected IETCInvoiceDetailRepository ETCDetailRep;

        protected IETCInvoiceBriefRepository ETCBriefRep;



        protected string CompanyNum;
        public ETCAppService(IAutoMapper mapper,IETCRepository etcRep ,IETCInvoiceDetailRepository etcDetailRep, IETCInvoiceBriefRepository etcBriefRep)
        {
            Mapper = mapper;
            ETCRep = etcRep;
            ETCDetailRep = etcDetailRep;
            ETCBriefRep = etcBriefRep;
        }



        /// <summary>
        /// 查看详情列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetETCInvoiceDetailListOutput> ViewDetail(Guid carrierOrderId)
        {
            var output = new GetETCInvoiceDetailListOutput();

            var co = await ETCRep.GetCarrierOrderDetail(carrierOrderId);

            if (co != null)
            {
                var order = co.OrderList.OrderBy(a => a.OrderId).FirstOrDefault();
                output.OrderCode = order.OrderId;
                output.CarCode = co.CarCode;
                //output.CarPlateColor = CarPlateColor.Yellow;
                output.RealDeliveryTime = order.RealDeliveryTime;
                output.OrginAddress = order.OriginAddress;
                output.DestinationAddress = order.DestinationAddress;
                output.ArrivalTime = order.ArrivalTime;
                output.TotalPrice = co.Contract.TotalPrice;
                output.RealDestinationAddress = order.DestinationAddress;
                output.RealArriavlTime = order.RealArrivalTime;
            }


            var brief = await ETCBriefRep.GetInvoiceBrief(carrierOrderId);

            var list = new List<ETCInvoiceDetail>();
            if(brief!=null)
            {
                list = await ETCDetailRep.GetInvoiceDetailList(carrierOrderId,brief.Id);
                output.PlateNum = brief.PlateNum;
                output.VehicleType = brief.VehicleType;
                output.WaybillNum = brief.WaybillNum;
                output.WaybillStatus = brief.WaybillStatus;
                output.WaybillStartTime = Convert.ToDateTime(brief.WaybillStartTime);
                output.WaybillEndTime = Convert.ToDateTime(brief.WaybillEndTime);
                output.ReceiveTime = Convert.ToDateTime(brief.ReceiveTime);
                //output.ReceiveInfo = brief.Info;
            }

            if (list != null && list.Count > 0) 
            {
                var resultList = Mapper.Map<List<ETCInvoiceDetailDto>>(list);
                output.Items = resultList;
            }

            return output;
        }

        
    }
}
