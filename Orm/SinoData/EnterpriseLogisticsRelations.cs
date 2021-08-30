using System;
using System.Collections.Generic;
using System.Text;

namespace SinoData
{
    public class EnterpriseLogisticsRelations
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        public Guid EnterpriseCompanyId { get; set; }

        ///// <summary>
        ///// 企业客户
        ///// </summary>
        //public EnterpriseCompany EnterpriseCompany { get; set; }

        public Guid LogisticsCompanyId { get; set; }

        /// <summary>
        /// 企业名称（最长200字符）
        /// </summary>
        public string Name { get; set; }

        ///// <summary>
        ///// 物流企业
        ///// </summary>
        //public LogisticsCompany LogisticsCompany { get; set; }

        /// <summary>
        /// 商务专员编号
        /// </summary>
        public long BusinessOfficerId { get; set; }

        ///// <summary>
        ///// 商务专员
        ///// </summary>
        //public virtual User BusinessOfficer { get; set; }

        ///// <summary>
        ///// 客服专员
        ///// </summary>
        //public virtual User ClientServiceOfficer { get; set; }

        /// <summary>
        /// 客服专员编号
        /// </summary>
        public long ClientServiceOfficerId { get; set; }

        /// <summary>
        /// 财务审核专员编号
        /// </summary>
        public long? FinanceAuditorId { get; set; }

        /// <summary>
        /// 现金占比（最长200字符）
        /// </summary>
        public string PaidWay { get; set; }

        /// <summary>
        /// 产品包装方式（最长200字符）
        /// </summary>
        public string ProductPack { get; set; }

        /// <summary>
        /// 产品（最长200字符）
        /// </summary>
        public string Products { get; set; }

        /// <summary>
        /// 详细地址（最长200字符）
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 所属省编码
        /// </summary>
        public string ProvinceCode { get; set; }

        /// <summary>
        /// 所属市编码
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// 所属区编码
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
		/// 地址详情（最长200字符）
		/// </summary>
        public string AddressDetails { get; set; }

        ///// <summary>
        ///// 合同编号（最长200字符）（弃用）
        ///// </summary>
        //public string ContractNumber { get; set; }

        /// <summary>
        /// 无车承运人是否同步
        /// </summary>
        public bool IsSync { get; set; }

        /// <summary>
        /// 备注（最长5000字符）
        /// </summary>
        public string Remarks { get; set; }

        ///// <summary>
        ///// 客户类型
        ///// </summary>
        //public ClientType? ClientType { get; set; }

        ///// <summary>
        ///// 对账周期
        ///// </summary>
        //public int? AccountCycle { get; set; }

        ///// <summary>
        ///// 对账周期单位
        ///// </summary>
        //public CycleUnit? AccountCycleUnit { get; set; }

        ///// <summary>
        ///// 回款周期
        ///// </summary>
        //public int? BackMoneyCycle { get; set; }

        ///// <summary>
        ///// 回款周期单位
        ///// </summary>
        //public CycleUnit? BackMoneyCycleUnit { get; set; }

        /// <summary>
        /// 企业机构信息
        /// </summary>
        public string EnterpriseCode { get; set; }

        ///// <summary>
        ///// 托运合同
        ///// </summary>
        //public virtual List<Contract> ShipContractList { get; set; }

        /// <summary>
        /// 是否开启应收自动填写
        /// </summary>
        public bool IsAutomatic { get; set; }

        /// <summary>
        /// 是否开启结算单位指标
        /// </summary>
        public bool IsSettlementUnit { get; set; }

        /// <summary>
        /// 是否开启公里数指标
        /// </summary>
        public bool IsKilometres { get; set; }

        /// <summary>
        /// 是否开启车长指标
        /// </summary>
        public bool IsCarLength { get; set; }

        /// <summary>
        /// 是否开启车型指标
        /// </summary>
        public bool IsVehicleType { get; set; }

        /// <summary>
        /// 是否开启货物名称指标
        /// </summary>
        public bool IsGoodsName { get; set; }

        /// <summary>
        /// 是否开启装载方式指标
        /// </summary>
        public bool IsStowage { get; set; }

        /// <summary>
        /// 是否开启货物数量指标
        /// </summary>
        public bool IsGoodsNum { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal? CashDeposit { get; set; }

        /// <summary>
        /// 是否开启排队叫号
        /// </summary>
        public bool? IsOpenCallNumber { get; set; }

        /// <summary>
        /// 管理员账号
        /// </summary>
        public string AdminUserName { get; set; }

        /// <summary>
        /// 管理员手机号
        /// </summary>
        public string AdminPhoneNumber { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// 联系人手机号
        /// </summary>
        public string ContactPhone { get; set; }

        ///// <summary>
        ///// 大区列表
        ///// </summary>
        //public virtual List<ClientRegionRelation> RegionList { get; set; }

        /// <summary>
        /// 是否开启自动定位
        /// </summary>
        public bool? IsOpenAutoLocation { get; set; }

        /// <summary>
        /// 状态（0：禁用 1：启用）
        /// </summary>
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// 服务模式
        /// </summary>
        public string ServiceMode { get; set; }

        /// <summary>
        /// 是否应收自动计算
        /// </summary>
        public bool? IsAutoReceive { get; set; }

        ///// <summary>
        ///// 应收计算公式 1表示应收=应付/（1-费率%） 2表示应收=应付*（1+费率%）
        ///// </summary>
        //public int? ReceiveExpression { get; set; }

        /// <summary>
        /// 应收费率
        /// </summary>
        public decimal? ReceiveRate { get; set; }

        /// <summary>
        /// 是否显示支付码（1显示（沃得）  0不显示）
        /// </summary>
        public bool? IsShowPayQRCode { get; set; }



        #region 托运人字段


        /// <summary>
        /// 一级会员编码
        /// </summary>
        public string LevelOneMemberCode { get; set; }

        /// <summary>
        /// 平台公司Id
        /// </summary>
        public Guid? PlatformCompanyId { get; set; }

        /// <summary>
        /// 平台公司
        /// </summary>
        public string PlatformCompanyName { get; set; }

        /// <summary>
        /// 平台公司编码
        /// </summary>
        public string PlatformCompanyCode { get; set; }


        /// <summary>
        /// 法人
        /// </summary>
        public string LegalPerson { get; set; }

        /// <summary>
        /// 法人身份证
        /// </summary>
        public string LegalPersonIdentity { get; set; }

        ///// <summary>
        ///// 托运人类型
        ///// </summary>
        //public ShipperType? ShipperType { get; set; }



        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? RegistrationTime { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? AuditTime { get; set; }


        ///// <summary>
        ///// 托运人审核状态
        ///// </summary>
        //public ShipperAuditStatus? ShipperAuditStatus { get; set; }


        /// <summary>
        /// 审核意见
        /// </summary>
        public string AuditOpinion { get; set; }


        ///// <summary>
        ///// 托运人会员状态
        ///// </summary>
        //public ShipperMemberStatus? ShipperMemberStatus { get; set; }
        #endregion

    }
}
