using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace 简易消息队列
{
    public class DemoQueueBlock<T> where T:class
    {
        private static BlockingCollection<T> Colls; //一个支持界限和阻塞的容器（线程安全集合）

        public DemoQueueBlock()
        {

        }
        public static bool IsComleted()
        {
            if (Colls != null && Colls.IsCompleted)
            {
                return true;
            }
            return false;
        }
        public static bool HasEle()
        {
            if (Colls != null && Colls.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static bool Add(T msg)
        {
            if (Colls == null)
            {
                Colls = new BlockingCollection<T>();
            }
            Colls.Add(msg);
            return true;
        }
        public static T Take()
        {
            if (Colls == null)
            {
                Colls = new BlockingCollection<T>();
            }
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
