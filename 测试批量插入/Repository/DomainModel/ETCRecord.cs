using Sino.Domain.Entities;
using Sino.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Hf.EtcService
{
    public class ETCRecord : CreationAuditedEntity<Guid>
    {
        /// <summary>
        /// 输入参数
        /// </summary>
        public string InputParam { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public string ReturnResult { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// etc接口名称
        /// </summary>
        public string ETCSdkMethod { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime ReceiveTime { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Info { get; set; }

        public Guid CarrierOrderId { get; set; }


        public string OrderCode { get; set; }

    }
}
