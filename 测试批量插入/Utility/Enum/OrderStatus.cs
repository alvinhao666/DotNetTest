using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Hf.EtcService
{
    public enum OrderStatus
    {
        /// <summary>
        /// 缺省值
        /// </summary>
        None,
        /// <summary>
        /// 派车中
        /// </summary>
        ITC,
        /// <summary>
        /// 退回下单
        /// </summary>
        RTTO,
        /// <summary>
        /// 已派车
        /// </summary>
        HSC,
        /// <summary>
        /// 退回派车
        /// </summary>
        BTS,
        /// <summary>
        /// 待发货
        /// </summary>
        WFTD,
        /// <summary>
        /// 已发货
        /// </summary>
        SHIP,
        /// <summary>
        /// 货已送达
        /// </summary>
        TCHBD,
        /// <summary>
        /// 订单终结
        /// </summary>
        OEND,
        /// <summary>
        /// 已到场
        /// </summary>
        SHOWUP,
        /// <summary>
        /// 待复审
        /// </summary>
        WTR
    }
}
