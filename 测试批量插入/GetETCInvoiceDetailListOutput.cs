using Sino.Application.Services.Dto;
using Sino.Hf.EtcService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.TMSystem.AppService.Order
{
    public class GetETCInvoiceDetailListOutput : IOutputDto, IPagedResult<ETCInvoiceDetailDto>
    {
        public IReadOnlyList<ETCInvoiceDetailDto> Items { get; set; }

        public int TotalCount { get; set; }

        #region 运单信息
        public string OrderCode { get; set; }

        public string CarCode { get; set; }

        public CarPlateColor? CarPlateColor { get; set; }

        public DateTime? RealDeliveryTime { get; set; }

        public string OrginAddress { get; set; }

        public string DestinationAddress { get; set; }

        public DateTime ArrivalTime { get; set; }

        public decimal TotalPrice { get; set; }

        public string RealDestinationAddress { get; set; }

        public DateTime? RealArriavlTime { get; set; }
        #endregion


        #region 发票信息
        /// <summary>
        /// 车牌号
        /// </summary>
        public string PlateNum { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public ETCVehicleType? VehicleType { get; set; }

        /// <summary>
        /// 运单编号
        /// </summary>
        public string WaybillNum { get; set; }

        /// <summary>
        /// 运单状态
        /// </summary>
        public ETCWayBillStatus? WaybillStatus { get; set; }

        /// <summary>
        /// 运单开始时间
        /// </summary>
        public DateTime? WaybillStartTime { get; set; }

        /// <summary>
        /// 运单结束时间
        /// </summary>
        public DateTime? WaybillEndTime { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime? ReceiveTime { get; set; }

        /// <summary>
        /// 接收
        /// </summary>
        public string ReceiveInfo { get; set; }
        #endregion

    }

    public class ETCInvoiceDetailDto : EntityDto<Guid>
    {
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
        public DateTime InvoiceMakeTime { get; set; }

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
        public DateTime ExTime { get; set; }

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
        public ETCVehicleType? VehicleType { get; set; }

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
        public DateTime WaybillStartTime { get; set; }

        /// <summary>
        /// 运单结束时间
        /// </summary>
        public DateTime WaybillEndTime { get; set; }

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

    }
}
