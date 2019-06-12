using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Hf.EtcService
{
    public enum ETCWayBillStatus
    {
        /// <summary>
        /// 未结束
        /// </summary>
        NoEnd = 1,

        /// <summary>
        /// 开票中
        /// </summary>
        Invoicing,

        /// <summary>
        /// 开票完成
        /// </summary>
        Invoiced,
    }
}
