using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace 简易消息队列
{
    public class DemoQueueBlock<T> where T:class
    {
        //BlockingCollection集合是一个拥有阻塞功能的集合，它就是完成了经典生产者消费者的算法功能。一般情况下，我们可以基于 生产者 - 消费者模式来实现并发。BlockingCollection<T> 类是最好的解决方案
        private static BlockingCollection<T> Colls = new BlockingCollection<T>(); //一个支持界限和阻塞的容器（线程安全集合）


        public static bool IsComleted()
        {
            if (Colls.IsCompleted)
            {
                return true;
            }
            return false;
        }
        public static bool HasEle()
        {
            if (Colls.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static bool Add(T msg)
        {
            Colls.Add(msg);
            return true;
        }
        public static T Take()
        {
            return Colls.Take();
        }
    }

    /// <summary>
    /// 消息体
    /// </summary>
    public class DemoMessage
    {
        public string BusinessType { get; set; }
        public string BusinessId { get; set; }
        public string Body { get; set; }
    }
}
