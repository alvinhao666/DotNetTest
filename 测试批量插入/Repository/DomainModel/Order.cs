using Sino.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Hf.EtcService
{
    /// <summary>
    /// 订单总单
    /// </summary>
    public class Order : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 承运单编号
        /// </summary>
        public Guid? CarrierOrderId { get; set; }

        /// <summary>
        /// Csp订单编号
        /// </summary>
        public Guid? CspOrderId { get; set; }

        /// <summary>
        /// 承运单
        /// </summary>
        public virtual CarrierOrder CarrierOrder { get; set; }

        ///// <summary>
        ///// 订单子单列表
        ///// </summary>
        //public virtual IList<OrderChild> ChildList { get; set; }

        ///// <summary>
        ///// 所需车长
        ///// </summary>
        //public CarLength CarLength { get; set; }

        ///// <summary>
        ///// 承运方式
        ///// </summary>
        //public CarriageWay CarriageWay { get; set; }

        ///// <summary>
        ///// 车型
        ///// </summary>
        //public VehicleType VehicleType { get; set; }

        /// <summary>
        /// 装车效果
        /// </summary>
        public string LoadingEffect { get; set; }

        ///// <summary>
        ///// 客户单位
        ///// </summary>
        //public virtual EnterpriseLogisticsRelations Client { get; set; }

        /// <summary>
        /// 客户单位名称
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 客户单位编号
        /// </summary>
        public Guid ClientId { get; set; }

        ///// <summary>
        ///// 发货计划人
        ///// </summary>
        //public virtual CustomerRepresentative Consignor { get; set; }

        /// <summary>
        /// 发货计划人编号
        /// </summary>
        public Guid ConsignorId { get; set; }

        /// <summary>
        /// 发货内容
        /// </summary>
        public string Content { get; set; }

        ///// <summary>
        ///// 客服专员
        ///// </summary>
        //public virtual User CustomerService { get; set; }

        /// <summary>
        /// 客服专员名称
        /// </summary>
        public string CustomerServiceName { get; set; }

        /// <summary>
        /// 客服专员编号
        /// </summary>
        public long CustomerServiceId { get; set; }

        ///// <summary>
        ///// 调度专员
        ///// </summary>
        //public virtual User Dispatcher { get; set; }

        /// <summary>
        /// 调度专员编号
        /// </summary>
        public long DispatcherId { get; set; }

        /// <summary>
        /// 调度专员名称
        /// </summary>
        public string DispatcherName { get; set; }

        /// <summary>
        /// 调度专员号码
        /// </summary>
        public string DispatcherPhoneNumber { get; set; }

        /// <summary>
        /// 物流公司编号
        /// </summary>
        public Guid LogisticsId { get; set; }

        /// <summary>
        /// 可识别的订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 客户订单编号
        /// </summary>
        public string ClientOrderId { get; set; }

        /// <summary>
        /// 子询价单Id
        /// </summary>
        public Guid? InquiryChildRealId { get; set; }

        /// <summary>
        /// 子询价单编号
        /// </summary>
        public string InquiryChildId { get; set; }

        ///// <summary>
        ///// 计划专员
        ///// </summary>
        //public virtual User Planner { get; set; }

        /// <summary>
        /// 计划专员编号
        /// </summary>
        public long PlannerId { get; set; }

        /// <summary>
        /// 计划专员名称
        /// </summary>
        public string PlannerName { get; set; }

        ///// <summary>
        ///// 商务专员
        ///// </summary>
        //public virtual User BusinessAffairs { get; set; }

        /// <summary>
        /// 商务专员编号
        /// </summary>
        public long BusinessAffairsId { get; set; }

        /// <summary>
        /// 商务专员名称
        /// </summary>
        public string BusinessAffairsName { get; set; }

        /// <summary>
        /// 订单备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 规定回复时间（分钟）
        /// </summary>
        public long ResponseTime { get; set; }

        ///// <summary>
        ///// 应收信息列表
        ///// </summary>
        //public virtual IList<Receivable> ReceivableList { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime DeliveryTime { get; set; }

        /// <summary>
        /// 到货时间
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// 实际发货时间
        /// </summary>
        public DateTime? RealDeliveryTime { get; set; }

        /// <summary>
        /// 实际到货时间
        /// </summary>
        public DateTime? RealArrivalTime { get; set; }

        /// <summary>
        /// 货物编号
        /// </summary>
        public Guid GoodsId { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 货物类型编号
        /// </summary>
        public Guid GoodsTypeId { get; set; }

        /// <summary>
        /// 货物类型名称
        /// </summary>
        public string GoodsTypeName { get; set; }

        /// <summary>
        /// 货物数量
        /// </summary>
        public decimal QuantityOfGoods { get; set; }

        /// <summary>
        /// 实际货物数量
        /// </summary>
        public decimal RealQuantityOfGoods { get; set; }

        ///// <summary>
        ///// 货物数量单位
        ///// </summary>
        //public GoodsUnit GoodsUnit { get; set; }

        /// <summary>
        /// 货物数量2
        /// </summary>
        public decimal? QuantityOfGoodsTwo { get; set; }

        ///// <summary>
        ///// 货物数量2单位
        ///// </summary>
        //public GoodsUnit? GoodsUnitTwo { get; set; }

        /// <summary>
        /// 里程数
        /// </summary>
        public float? Mileage { get; set; }

        /// <summary>
        /// 目的地省
        /// </summary>
        public string DestinationProvince { get; set; }

        /// <summary>
        /// 目的地市
        /// </summary>
        public string DestinationCity { get; set; }

        /// <summary>
        /// 目的地区
        /// </summary>
        public string DestinationCounty { get; set; }

        /// <summary>
        /// 目的地详情
        /// </summary>
        public string DestinationDetails { get; set; }

        /// <summary>
        /// 起始地省
        /// </summary>
        public string OriginProvince { get; set; }

        /// <summary>
        /// 起始地市
        /// </summary>
        public string OriginCity { get; set; }

        /// <summary>
        /// 起始地区
        /// </summary>
        public string OriginCounty { get; set; }

        /// <summary>
        /// 起始地详情
        /// </summary>
        public string OriginDetails { get; set; }

        /// <summary>
        /// 起始地名称
        /// </summary>
        public string OriginAddress { get; set; }

        /// <summary>
        /// 目的地名称
        /// </summary>
        public string DestinationAddress { get; set; }

        /// <summary>
        /// 目的地经度
        /// </summary>
        public float? DestinationLongitude { get; set; }

        /// <summary>
        /// 起始地经度
        /// </summary>
        public float? OriginLongitude { get; set; }

        /// <summary>
        /// 目的地纬度
        /// </summary>
        public float? DestinationLatitude { get; set; }

        /// <summary>
        /// 起始地纬度
        /// </summary>
        public float? OriginLatitude { get; set; }

        /// <summary>
        /// 途经卸货地列表(列表查询)
        /// </summary>
        public string ViaList { get; set; }


        /// <summary>
        /// 途经卸货地列表(前端显示)
        /// </summary>
        public string ViaAddressList { get; set; }

        /// <summary>
        /// 附件备注说明
        /// </summary>
        public string AttachmentRemarks { get; set; }

        /// <summary>
        /// 吨位范围
        /// </summary>
        public string TonnageRange { get; set; }

        /// <summary>
        /// 审核通过时间
        /// </summary>
        public DateTime? AuditedTime { get; set; }
        /// <summary>
        /// 审核人Id
        /// </summary>
        public long? AuditorId { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string Auditor { get; set; }

        ///// <summary>
        ///// 回单状态
        ///// </summary>
        //public ReceiptStatus ReceiptStatus { get; set; }

        ///// <summary>
        ///// 结算单据状态
        ///// </summary>
        //public SettlementStatus SettlementStatus { get; set; }

        /// <summary>
        /// 回单签收时间
        /// </summary>
        public DateTime? ReceiptTime { get; set; }

        /// <summary>
        /// 是否确认应收
        /// </summary>
        public bool IsCheckReceivable { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        /// 无车承运人是否同步
        /// </summary>
        public bool IsSync { get; set; }

        /// <summary>
        /// 货已送达点击按钮时间
        /// </summary>
        public DateTime? ClickTime { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public string DocumentNo { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        public string TrackingNo { get; set; }
        /// <summary>
        /// 所有应收是否已对账
        /// </summary>
        public bool ReceivableIsAllChecked { get; set; }

        /// <summary>
        /// 预计情况
        /// </summary>
        public string ExpectedSituation { get; set; }

        /// <summary>
        /// 原预计划状态
        /// </summary>
        public bool IsBeforehandOld { get; set; }

        /// <summary>
        /// 当前预计划状态
        /// </summary>
        public bool IsBeforehandNow { get; set; }

        /// <summary>
        /// 是否自动终结
        /// </summary>
        public bool IsAutoEnd { get; set; }

        ///// <summary>
        ///// 回单附件对象
        ///// </summary>
        //public virtual GetInvoiceManagementAttachmentsResult ReceiptAttachments { get; set; }

        public DateTime? LastModificationTime { get; set; }

        ///// <summary>
        ///// 派车方式
        ///// </summary>
        //public SendVehicleType? SendVehicleType { get; set; }

        /// <summary>
        /// 合伙人Id
        /// </summary>
        public long? PartnerId { get; set; }

        /// <summary>
        /// 合伙人 是否发布至CCP
        /// </summary>
        public bool IsPartnerPublishToCCP { get; set; }

        /// <summary>
        /// 合伙人
        /// </summary>
        //public string PartnerName { get; set; }

        ///// <summary>
        ///// 数据来源(飓风,合伙人)
        ///// </summary>
        //public DataSourceType DataSourceType { get; set; }

        /// <summary>
        /// 剩余时间
        /// </summary>
        public float? RemainTime { get; set; }

        ///// <summary>
        ///// 线路类型
        ///// </summary>
        //public LineType LineType { get; set; }

    }
}
