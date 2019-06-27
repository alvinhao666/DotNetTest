using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 备忘录模式
{
    /// <summary>
    /// Memento管理者（Caretaker）
    /// </summary>
    public class MessageModelCaretaker
    {
        /// <summary>
        /// Message实体对象（Memento）
        /// </summary>
        public MessageModel MessageModel { get; set; }
    }
}
