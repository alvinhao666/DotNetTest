using System.Collections.Generic;

namespace _2策略模式
{
    public interface IMessageStrategy
    {
        /// <summary>
        /// 获取Message
        /// </summary>
        /// <returns></returns>
        List<MessageModel> Get();

        /// <summary>
        /// 插入message
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        bool Insert(MessageModel mm);
    }
}
