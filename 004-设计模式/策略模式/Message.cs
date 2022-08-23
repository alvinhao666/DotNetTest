using System.Collections.Generic;

namespace _2策略模式
{
    public class Message
    {
        private IMessageStrategy _strategy;

        public Message(IMessageStrategy strategy)
        {
            this._strategy = strategy;
        }

        public List<MessageModel> Get()
        {
            return _strategy.Get();
        }


        public bool Insert(MessageModel mm)
        {
            return _strategy.Insert(mm);
        }
    }
}
