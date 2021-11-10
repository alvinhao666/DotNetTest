using System;
using System.Collections.Generic;
using System.Text;

namespace _2策略模式
{
    public class XmlMessage : IMessageStrategy
    {
        public List<MessageModel> Get()
        {
            List<MessageModel> list = new List<MessageModel>();
            list.Add(new MessageModel() { Message = "XML方式获取Message", PublishTime = DateTime.Now });
            return list;
        }

        public bool Insert(MessageModel mm)
        {
            return true;
        }
    }
}
