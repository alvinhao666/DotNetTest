using Sino.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Hf.EtcService
{
    public class ETCInvoiceBrief : CreationAuditedEntity<Guid>
    {
        /// <summary>
        /// CarrierOrderId
        /// </summary>
        public Guid CarrierOrderId { get; set; }


        /// <summary>
        /// 车牌
        /// </summary>
        public string PlateNum { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public ETCVehicleType VehicleType { get; set; }

        /// <summary>
        /// 运单编号
        /// </summary>
        public string WaybillNum { get; set; }

        /// <summary>
        /// 运单状态
        /// </summary>
        public ETCWayBillStatus WaybillStatus { get; set; }

        /// <summary>
        /// 运单开始时间
        /// </summary>
        public string WaybillStartTime { get; set; }

        /// <summary>
        /// 运单结束时间
        /// </summary>
        public string WaybillEndTime { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        public string ReceiveTime { get; set; }
    }
}
