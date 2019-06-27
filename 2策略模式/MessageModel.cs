using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2策略模式
{
    /// <summary>
    ///  Message实体类（Memento）
    /// </summary>
    public class MessageModel
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishTime { get; set; }
    }
}
