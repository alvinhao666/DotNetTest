using Sino.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Hf.EtcService
{
    /// <summary>
    /// 合同信息
    /// </summary>
    public class Contract : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 承运单编号
        /// </summary>
        public Guid CarrierOrderId { get; set; }

        /// <summary>
        /// 物流公司编号
        /// </summary>
        public Guid LogisticsId { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; }

        /// <summary>
        /// 收货人号码
        /// </summary>
        public string ConsigneePhone { get; set; }

        /// <summary>
        /// 备用电话
        /// </summary>
        public string AltermatePhone { get; set; }

        /// <summary>
        /// 辅助工具
        /// </summary>
        public string AuxiliaryTool { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNumber { get; set; }

        ///// <summary>
        ///// 合同状态
        ///// </summary>
        //public ContractStatus ContractStatus { get; set; }

        /// <summary>
        /// 驾驶证号
        /// </summary>
        public string DriverLicenseNumber { get; set; }

        /// <summary>
        /// 发动机号
        /// </summary>
        public string EngineNumber { get; set; }

        /// <summary>
        /// 车架号
        /// </summary>
        public string FrameNumber { get; set; }

        ///// <summary>
        ///// 合同货物数量单位
        ///// </summary>
        //public GoodsUnit GoodsUnit { get; set; }

        /// <summary>
        /// 油卡卡号
        /// </summary>
        public string OilCardNumber { get; set; }

        ///// <summary>
        ///// 油卡状态
        ///// </summary>
        //public OilCardStatus OilCardStatus { get; set; }

        /// <summary>
        /// 合同货物数量
        /// </summary>
        public decimal QuantityOfGoods { get; set; }

        /// <summary>
        /// 挂车车架号
        /// </summary>
        public string TrailerFrameNumber { get; set; }

        /// <summary>
        /// 挂车号
        /// </summary>
        public string TrailerNumber { get; set; }

        /// <summary>
        /// 合同日期
        /// </summary>
        public DateTime ContractTime { get; set; }

        /// <summary>
        /// 无车承运人是否同步
        /// </summary>
        public bool IsSync { get; set; }

        /// <summary>
        /// 运费总价
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 电子合同编号
        /// </summary>
        public string ElectronicContractNumber { get; set; }

        ///// <summary>
        ///// 电子合同状态
        ///// </summary>
        //public ElectronicContractStatus? ElectronicContractStatus { get; set; }

        /// <summary>
        /// 补充协议合同编号
        /// </summary>
        public string AgreementContractNumber { get; set; }

        ///// <summary>
        ///// 补充协议合同状态
        ///// </summary>
        //public ElectronicContractStatus? AgreementContractStatus { get; set; }

        /// <summary>
        /// 送货单号
        /// </summary>
        public string DeliveryNumber { get; set; }

        /// <summary>
        /// 收货单位企业机构代码
        /// </summary>
        public string ConsigneeEnterpriseCode { get; set; }

        ///// <summary>
        ///// 收货人类型
        ///// </summary>
        //public ConsigneeType ConsigneeType { get; set; }

        /// <summary>
        /// 收货人身份证号
        /// </summary>
        public string ConsigneeIDNumber { get; set; }

        ///// <summary>
        ///// 托运合同有效期类型
        ///// </summary>
        //public ContractDurationType? ContractDurationType { get; set; }

        ///// <summary>
        ///// 合同类型
        ///// </summary>
        //public ContractType? ContractType { get; set; }

        /// <summary>
        /// 有效期开始时间
        /// </summary>
        public DateTime? StartExpiryDate { get; set; }

        /// <summary>
        /// 有效期截止时间
        /// </summary>
        public DateTime? EndExpiryDate { get; set; }

        ///// <summary>
        ///// 附件
        ///// </summary>
        //public virtual Attachment Attachment { get; set; }

        /// <summary>
        /// 客户单位Id
        /// </summary>
        public Guid? ClientId { get; set; }

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
    }
}
