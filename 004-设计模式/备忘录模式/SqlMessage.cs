using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 备忘录模式
{
    /// <summary>
    /// Sql方式操作Message（Originator）
    /// </summary>
    public class SqlMessage
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishTime { get; set; }

        /// <summary>
        /// 插入Message
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public bool insert(MessageModel mm)
        {
            if (mm.PublishTime.Value.Second % 5 == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 保存Memento
        /// </summary>
        /// <returns></returns>
        public MessageModel SaveMemento()
        {
            return new MessageModel() { Message = Message, PublishTime = PublishTime };
        }

        /// <summary>
        /// 恢复Memento
        /// </summary>
        public void RestoreMemento(MessageModel mm)
        {
            this.Message = mm.Message;
            this.PublishTime = mm.PublishTime;
        }
    }
}
