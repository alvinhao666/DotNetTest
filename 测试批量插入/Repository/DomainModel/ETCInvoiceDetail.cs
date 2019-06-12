using Sino.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Hf.EtcService
{
    public class ETCInvoiceDetail : CreationAuditedEntity<Guid>
    {

        /// <summary>
        /// CarrierOrderId
        /// </summary>
        public Guid CarrierOrderId { get; set; }

        public Guid BriefId { get; set; }
        /// <summary>
        /// 发票号码
        /// </summary>
        public string InvoiceNum { get; set; }

        /// <summary>
        /// 发票代码
        /// </summary>
        public string InvoiceCode { get; set; }

        /// <summary>
        /// 开票时间
        /// </summary>
        public string InvoiceMakeTime { get; set; }

        /// <summary>
        /// 发票url
        /// </summary>
        public string InvoiceUrl { get; set; }

        /// <summary>
        /// 发票板式文件url
        /// </summary>
        public string InvoiceHtmlUrl { get; set; }

        /// <summary>
        /// 入口收费站
        /// </summary>
        public string EnStation { get; set; }

        /// <summary>
        /// 出口收费站
        /// </summary>
        public string ExStation { get; set; }

        /// <summary>
        /// 交易时间
        /// </summary>
        public string ExTime { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public int Fee { get; set; }

        /// <summary>
        /// 税额（可抵扣金额）
        /// </summary>
        public int TotalTaxAmount { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string PlateNum { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public ETCVehicleType VehicleType { get; set; }

        /// <summary>
        /// 销方名称
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// 销方税号
        /// </summary>
        public string SellerTaxpayerCode { get; set; }

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
        /// 价税合计
        /// </summary>
        public int TotalAmount { get; set; }

        /// <summary>
        /// 税率
        /// </summary>
        public double TaxRate { get; set; }

        /// <summary>
        /// 发票种类
        /// </summary>
        public string InvoiceType { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 交易id
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        public string ReceiveTime { get; set; }

        /// <summary>
        /// 接收
        /// </summary>
        public string ReceiveInfo { get; set; }
    }
}

