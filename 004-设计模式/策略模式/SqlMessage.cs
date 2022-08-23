using System;
using System.Collections.Generic;

namespace _2策略模式
{
    public class SqlMessage : IMessageStrategy
    {
        public List<MessageModel> Get()
        {
            List<MessageModel> list = new List<MessageModel>();
            list.Add(new MessageModel() { Message = "SQL方式获取Message", PublishTime = DateTime.Now });
            return list;
        }

        public bool Insert(MessageModel mm)
        {
            return true;
        }
    }
}
