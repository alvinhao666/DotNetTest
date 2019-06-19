using Sino.Domain.Entities;
using Sino.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Hf.EtcService
{
    public class ETCCar : Entity<Guid>
    {
        /// <summary>
        /// 车牌
        /// </summary>
        public string CarCode { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 接受时间
        /// </summary>
        public string ReceiveTime { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Info { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
