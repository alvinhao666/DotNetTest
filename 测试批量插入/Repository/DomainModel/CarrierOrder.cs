using Sino.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Hf.EtcService
{
    /// <summary>
    /// 承运单
    /// </summary>
    public class CarrierOrder : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 物流公司编号
        /// </summary>
        public Guid LogisticsId { get; set; }

        /// <summary>
        /// 开户银行
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 持卡人
        /// </summary>
        public string Holder { get; set; }

        /// <summary>
        /// 账户信息
        /// </summary>
        public Guid? BankId { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarCode { get; set; }

        /// <summary>
        /// 车辆编号
        /// </summary>
        public Guid CarId { get; set; }

        ///// <summary>
        ///// 车长
        ///// </summary>
        //public CarLength CarLength { get; set; }

        /// <summary>
        /// 承运商名称
        /// </summary>
        public string Carrier { get; set; }

        /// <summary>
        /// 承运商编号
        /// </summary>
        public Guid CarrierId { get; set; }

        /// <summary>
        /// 结算方号码
        /// </summary>
        public string CarrierPhone { get; set; }

        ///// <summary>
        ///// 承运商类型
        ///// </summary>
        //public CarrierType CarrierType { get; set; }

        ///// <summary>
        ///// 车型
        ///// </summary>
        //public VehicleType VehicleType { get; set; }

        /// <summary>
        /// 驾驶员身份证号
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// 合同信息
        /// </summary>
        public virtual Contract Contract { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public Guid? ContractId { get; set; }

        /// <summary>
        /// 驾驶员姓名
        /// </summary>
        public string Driver { get; set; }

        /// <summary>
        /// 驾驶员号码
        /// </summary>
        public string DriverPhone { get; set; }

        /// <summary>
        /// 订单总单列表
        /// </summary>
        public virtual IList<Order> OrderList { get; set; }

        /// <summary>
        /// 应付单价
        /// </summary>
        public decimal PayablePrice { get; set; }

        ///// <summary>
        ///// 应付单价单位
        ///// </summary>
        //public PriceUnit PayablePriceUnit { get; set; }

        /// <summary>
        /// 应付单价说明
        /// </summary>
        public string PayableSummary { get; set; }

        /// <summary>
        /// 回单款账户编号
        /// </summary>
        public Guid? ReceiptBankId { get; set; }

        /// <summary>
        /// 回单款开户银行
        /// </summary>
        public string ReceiptBankName { get; set; }

        /// <summary>
        /// 回单款银行卡号
        /// </summary>
        public string ReceiptBankCode { get; set; }

        /// <summary>
        /// 回单款持卡人
        /// </summary>
        public string ReceiptHolder { get; set; }

        /// <summary>
        /// 回单款
        /// </summary>
        public decimal? ReceiptPrice { get; set; }

        ///// <summary>
        ///// 回单款付款方式
        ///// </summary>
        //public PaymentMethod? ReceiptPriceUnit { get; set; }

        /// <summary>
        /// 承运单备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 临时客服专员
        /// </summary>
        public string TempCustomerService { get; set; }

        /// <summary>
        /// 临时客服专员编号
        /// </summary>
        public long TempCustomerServiceId { get; set; }

        /// <summary>
        /// 定位状态
        /// </summary>
        public bool LocationStatus { get; set; }

        /// <summary>
        /// 道路运输许可证号
        /// </summary>
        public string PermitNumber { get; set; }

        /// <summary>
        /// 所属辖区(省)
        /// </summary>
        public string CountrySubdivisionProvinceCode { get; set; }

        /// <summary>
        /// 所属辖区(市)
        /// </summary>
        public string CountrySubdivisionCityCode { get; set; }

        /// <summary>
        /// 所属辖区(区)
        /// </summary>
        public string CountrySubdivisionCountryCode { get; set; }

        /// <summary>
        /// 道路运输证字号
        /// </summary>
        public string RoadTransportCertificateNumber { get; set; }

        /// <summary>
        /// 无车承运人是否同步
        /// </summary>
        public bool IsSync { get; set; }

        /// <summary>
        /// 等货费
        /// </summary>
        public decimal? WaitingGoodsFee { get; set; }

        /// <summary>
        /// 超限费
        /// </summary>
        public decimal? BeyondLimitFee { get; set; }

        /// <summary>
        /// 多装多卸费
        /// </summary>
        public decimal? LoadingMoreFee { get; set; }

        /// <summary>
        /// 车辆吨位
        /// </summary>
        public string CarTonnage { get; set; }

        /// <summary>
        /// 发证机关代码
        /// </summary>
        public string SendCardOrganCode { get; set; }

        /// <summary>
        /// 发证机关名称
        /// </summary>
        public string SendCardOrganName { get; set; }

        /// <summary>
        /// 银行网点
        /// </summary>
        public string BankNetwork { get; set; }

        ///// <summary>
        ///// 人物属性
        ///// </summary>
        //public DrvierType PersonAttribute { get; set; }


        /// <summary>
        /// 可识别的运单编号
        /// </summary>
        public string CarrierOrderCode { get; set; }

        /// <summary>
        /// 是否所有费用已付款
        /// </summary>
        public bool IsAllPaid { get; set; }

        ///// <summary>
        ///// 是否已开票审核
        ///// </summary>
        //public InvoiceCheckedStatus InvoiceCheckedStatus { get; set; }

        /// <summary>
        /// 定位手机号
        /// </summary>
        public string LocationPhone { get; set; }

        /// <summary>
        /// 合伙人Id
        /// </summary>
        public long? PartnerId { get; set; }

        /// <summary>
        /// 合伙人
        /// </summary>
        public string PartnerName { get; set; }

        ///// <summary>
        ///// 数据来源(飓风,合伙人)
        ///// </summary>
        //public DataSourceType DataSourceType { get; set; }

        /// <summary>
        /// 从业资格信息证号
        /// </summary>
        public string Qualificationcertificatenumber { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// 实际货已送达时间
        /// </summary>
        public DateTime? RealArrivalTime { get; set; }

        /// <summary>
        /// 是否客服已确认
        /// </summary>
        public bool IsConfirm { get; set; }


        #region 线路基准价
        /// <summary>
        /// 运价下限
        /// </summary>
        public decimal? LowerLimitPrice { get; set; }

        /// <summary>
        /// 运价平均值
        /// </summary>
        public decimal? AvgLimitPrice { get; set; }

        /// <summary>
        /// 运价上限
        /// </summary>
        public decimal? UpLimitPrice { get; set; }
        #endregion
        /// <summary>
        /// 比价过程
        /// </summary>
        public string ParityProcess { get; set; }


        /// <summary>
        /// 应付报价
        /// </summary>
        public string PayableQuotation { get; set; }

        /// <summary>
        /// 应付报价说明
        /// </summary>
        public string PayableQuotationSummary { get; set; }

        /// <summary>
        /// 应付报价2
        /// </summary>
        public string PayableQuotationSecond { get; set; }

        /// <summary>
        /// 应付报价说明2
        /// </summary>
        public string PayableQuotationSummarySecond { get; set; }

        /// <summary>
        /// 应付报价3
        /// </summary>
        public string PayableQuotationThird { get; set; }

        /// <summary>
        /// 应付报价说明3
        /// </summary>
        public string PayableQuotationSummaryThird { get; set; }

        /// <summary>
        /// 报价信息Id
        /// </summary>
        public Guid? QuotationId { get; set; }


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
    }
}
