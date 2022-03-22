
using System;
using System.Collections.Generic;

/*
 * TMS v1.0.0 (http://vip56.cn)
 * Copyright 2011-2016 Sino, Inc.
 * Author: h-q-w
 * Time: 16.3.28
 */
namespace Sino.TMSystem.DomainModel.Order
{
    /// <summary>
    /// 订单总单
    /// </summary>
    public class Order 
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 承运单编号
        /// </summary>
        public Guid? CarrierOrderId { get; set; }



        /// <summary>
        /// Csp订单编号
        /// </summary>
        public Guid? CspOrderId { get; set; }

        /// <summary>
        /// 服务模式
        /// </summary>
        public int? ServiceMode { get; set; }

        /// <summary>
		/// 预计划订单Id
		/// </summary>
		public Guid? PreOrderId { get; set; }




        /// <summary>
        /// 所需车长
        /// </summary>
        public int CarLength { get; set; }

        /// <summary>
        /// 承运方式
        /// </summary>
        public int? CarriageWay { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public int VehicleType { get; set; }

        /// <summary>
        /// 装车效果
        /// </summary>
        public string LoadingEffect { get; set; }

        /// <summary>
        /// 提箱港区
        /// </summary>
        public int? SuitcasePortArea { get; set; }

        /// <summary>
        /// 提单号
        /// </summary>
        public string BillOfLadingNo { get; set; }


        /// <summary>
        /// 客户单位名称
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 客户单位编号
        /// </summary>
        public Guid ClientId { get; set; }


        /// <summary>
        /// 发货计划人编号
        /// </summary>
        public Guid ConsignorId { get; set; }

        /// <summary>
        /// 发货内容
        /// </summary>
        public string Content { get; set; }


        /// <summary>
        /// 客服专员名称
        /// </summary>
        public string CustomerServiceName { get; set; }

        /// <summary>
        /// 客服专员编号
        /// </summary>
        public long CustomerServiceId { get; set; }

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

        /// <summary>
        /// 计划专员编号
        /// </summary>
        public long PlannerId { get; set; }

        /// <summary>
        /// 计划专员名称
        /// </summary>
        public string PlannerName { get; set; }

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
        /// 规定回复时间
        /// </summary>
        public long ResponseTime { get; set; }

        /// <summary>
		/// 紧急程度单位
		/// </summary>
		public int? UrgencyUnit { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
		/// 终结订单原因
		/// </summary>
		public int? EndOrderReason { get; set; }

        /// <summary>
		/// 终结订单备注
		/// </summary>
		public string EndOrderRemarks { get; set; }

        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime DeliveryTime { get; set; }

        /// <summary>
        /// 到货时间
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// 原预计发货时间
        /// </summary>
        public DateTime? OldDeliveryTime { get; set; }

        /// <summary>
        /// 原预计到货时间
        /// </summary>
        public DateTime? OldArrivalTime { get; set; }

        /// <summary>
        /// 实际发货时间
        /// </summary>
        public DateTime? RealDeliveryTime { get; set; }

        /// <summary>
        /// 录入实际发货时间
        /// </summary>
        public DateTime? EnterRealDeliveryTime { get; set; }

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

        /// <summary>
        /// 货物数量单位
        /// </summary>
        public int GoodsUnit { get; set; }

        /// <summary>
        /// 货物数量2
        /// </summary>
        public decimal? QuantityOfGoodsTwo { get; set; }

        /// <summary>
        /// 货物数量2单位
        /// </summary>
        public int? GoodsUnitTwo { get; set; }

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

        /// <summary>
        /// 回单状态
        /// </summary>
        public int ReceiptStatus { get; set; }

        /// <summary>
        /// 结算单据状态
        /// </summary>
        public int SettlementStatus { get; set; }

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


        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 派车方式
        /// </summary>
        public int? SendVehicleType { get; set; }

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
        public string PartnerName { get; set; }

        /// <summary>
        /// 数据来源(飓风,合伙人)
        /// </summary>
        public int DataSourceType { get; set; }

        /// <summary>
        /// 剩余时间
        /// </summary>
        public float? RemainTime { get; set; }

        /// <summary>
        /// 线路类型
        /// </summary>
        public int LineType { get; set; }


        /// <summary>
        /// 货物毛重
        /// </summary>
        public double? GoodsRoughWeight { get; set; }


        /// <summary>
        /// 货物毛重单位                                                      
        /// </summary>
        public int? RoughWeightUnit { get; set; }

        /// <summary>
        /// 货物体积
        /// </summary>
        public double? GoodsVolume { get; set; }


        /// <summary>
        /// 货物毛重单位                                                      
        /// </summary>
        public int? VolumeUnit { get; set; }

        /// <summary>
        /// 诺得运单编号
        /// </summary>
        public Guid? NuoDeCarrierOrderId { get; set; }

        /// <summary>
        /// 诺得订单可识别编号
        /// </summary>
        public string NuoDeOrderCode { get; set; }

        /// <summary>
        /// 企业机构信息
        /// </summary>
        public string EnterpriseCode { get; set; }

        /// <summary>
        /// 货物重量
        /// </summary>
        public decimal? ItemgrossWeight { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public int? BusinessType { get; set; }

        /// <summary>
        /// 是否运单终结
        /// </summary>
        public bool IsCarrierOrderEnd { get; set; }

        /// <summary>
        /// 终结运单原因
        /// </summary>
        public int? EndCarrierOrderReason { get; set; }

        /// <summary>
        /// 发货现场打卡图片地址
        /// </summary>
        public string DeliverySiteImageUrl { get; set; }

        /// <summary>
        /// 发货现场打卡时间 （装货完成时间）
        /// </summary>
        public DateTime? UploadDeliveryImageTime { get; set; }

        /// <summary>
        /// 到货现场打卡图片地址
        /// </summary>
        public string ArrivalSiteImageUrl { get; set; }

        /// <summary>
        /// 送货现场打卡时间 （到达送货现场时间）
        /// </summary>
        public DateTime? UploadArrivalImageTime { get; set; }

        /// <summary>
        /// 发货地定位是否采集
        /// </summary>
        public bool HasDeliveryLocate { get; set; }

        /// <summary>
        /// 送货地定位是否采集
        /// </summary>
        public bool HasArrivalLocate { get; set; }

        /// <summary>
        /// 发货地采集时间 （到达发货现场时间）
        /// </summary>
        public DateTime? DeliveryLocateTime { get; set; }

        /// <summary>
        /// 送货地采集时间 （到达送货现场时间）
        /// </summary>
        public DateTime? ArrivalLocateTime { get; set; }

        /// <summary>
        /// 海运订单编号
        /// </summary>
        public Guid? H_OrderId { get; set; }

        /// <summary>
        /// 箱型
        /// </summary>
        public int? BoxType { get; set; }

        /// <summary>
        /// 整体箱门照片
        /// </summary>
        public string AllBoxDoorImageUrl { get; set; }

        /// <summary>
        /// 箱号照片
        /// </summary>
        public string BoxCodeImageUrl { get; set; }

        /// <summary>
        /// 箱号
        /// </summary>
        public string BoxCode { get; set; }

        /// <summary>
        /// 铅封号图片地址
        /// </summary>
        public string SealNoImageUrl { get; set; }

        /// <summary>
        /// 铅封号
        /// </summary>
        public string SealNo { get; set; }

        /// <summary>
        /// 箱重
        /// </summary>
        public decimal? BoxWeight { get; set; }

        /// <summary>
        /// 复审审核通过时间
        /// </summary>
        public DateTime? SecondAuditedTime { get; set; }
        /// <summary>
        /// 复审审核人Id
        /// </summary>
        public long? SecondAuditorId { get; set; }
        /// <summary>
        /// 复审审核人
        /// </summary>
        public string SecondAuditor { get; set; }

        /// <summary>
        /// 实际客户单位
        /// </summary>
        public string RealClient { get; set; }


        /// <summary>
        /// 实际客户单位id
        /// </summary>
        public Guid? RealClientId { get; set; }

        /// <summary>
        /// 实际客户单位机构代码
        /// </summary>
        public string RealClientCode { get; set; }

        /// <summary>
        /// 实际客户单位地址
        /// </summary>
        public string RealClientAddress { get; set; }

        /// <summary>
        /// 实际发货人
        /// </summary>
        public string RealConsignor { get; set; }

        /// <summary>
        /// 实际发货人身份证号码
        /// </summary>
        public string RealConsignorIdentity { get; set; }

        /// <summary>
        /// 实际发货人地址
        /// </summary>
        public string RealConsignorAddress { get; set; }

        /// <summary>
        /// 发货现场实际发货地址
        /// </summary>
        public string RealDeliveryAddress { get; set; }

        /// <summary>
        /// 发货现场实际发货地经度
        /// </summary>
        public string RealDeliveryLongitude { get; set; }

        /// <summary>
        /// 发货现场实际发货地纬度
        /// </summary>
        public string RealDeliveryLatitude { get; set; }

        /// <summary>
        /// 到货现场实际到货地址
        /// </summary>
        public string RealArrivalAddress { get; set; }

        /// <summary>
        /// 到货现场实际到货地经度
        /// </summary>
        public string RealArrivalLongitude { get; set; }

        /// <summary>
        /// 到货现场实际到货地纬度
        /// </summary>
        public string RealArrivalLatitude { get; set; }

        /// <summary>
		/// 大区Id
		/// </summary>
		public int? RegionId { get; set; }

        /// <summary>
        /// 大区名称
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// 指导价格
        /// </summary>
        public decimal? GuidePrice { get; set; }

        /// <summary>
        /// 指导价格单位
        /// </summary>
        public int? GuidePriceUnit { get; set; }

        /// <summary>
        /// 车辆信息是否完整
        /// </summary>
        public bool IsCarComplete { get; set; }

        /// <summary>
        /// 是否沃得结算
        /// </summary>
        public bool? IsWoDeSettle { get; set; }

        /// <summary>
        /// 到厂时间
        /// </summary>
        public DateTime? ArrivalFactoryTime { get; set; }

        /// <summary>
		/// 退单原因
		/// </summary>
		public string ReturnOrderReason { get; set; }

        /// <summary>
        /// 退单备注
        /// </summary>
        public string ReturnOrderRemark { get; set; }

        /// <summary>
        /// 退单时间
        /// </summary>
        public DateTime? ReturnOrderTime { get; set; }

        /// <summary>
        /// 退单人Id
        /// </summary>
        public long? ReturnOperatorId { get; set; }

        /// <summary>
        /// 退单人
        /// </summary>
        public string ReturnOperator { get; set; }

        /// <summary>
        /// 微信支付二维码地址
        /// </summary>
        public string PayQRCodeUrl { get; set; }

        /// <summary>
        /// 是否缺车
        /// </summary>
        public bool IsNeedCar { get; set; }


        /// <summary>
        /// 托运合同号
        /// </summary>
        public string ShipContractNo { get; set; }

        /// <summary>
        /// 托运合同有效日期
        /// </summary>
        public DateTime? ShipContractEffectStartTime { get; set; }

        /// <summary>
        /// 托运合同有效期
        /// </summary>
        public DateTime? ShipContractEffectEndTime { get; set; }

        /// <summary>
        /// 托运合同金额
        /// </summary>
        public decimal? ShipContractAmount { get; set; }

        /// <summary>
        /// 托运合同文件
        /// </summary>
        public string ShipContractFileUrl { get; set; }

        /// <summary>
        /// 托运合同文件名
        /// </summary>
        public string ShipContractFileName { get; set; }
    }
}

