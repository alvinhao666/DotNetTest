using Sino.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.TMSystem.AppService.Order
{
    public class GetETCInoviceListOutput : IOutputDto, IPagedResult<ETCInoviceDto>
    {
        public IReadOnlyList<ETCInoviceDto> Items { get; set; }

        public int TotalCount { get; set; }
    }

    public class ETCInoviceDto : EntityDto<Guid>, IPageResultIndex
    {
        public int Index { get ; set ; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarCode { get; set; }

        /// <summary>
        /// 实际发货时间
        /// </summary>
        public DateTime? RealDeliveryTime { get; set; }

        /// <summary>
        /// 实际到货时间
        /// </summary>
        public DateTime? RealArrivalTime { get; set; }

        /// <summary>
        /// 订单车辆数据是否上传
        /// </summary>
        public bool? OrderCarDataIsUpload { get; set; }

        /// <summary>
        /// 订单开始数据是否上传
        /// </summary>
        public bool? OrderStartDataIsUpload { get; set; }

        /// <summary>
        /// 订单结束数据是否上传
        /// </summary>
        public bool? OrderEndDataIsUpload { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? EtcUpdateTime { get; set; }

        /// <summary>
        /// 是否开票
        /// </summary>
        public bool? EtcIsInvoice { get; set; }
    }
}
