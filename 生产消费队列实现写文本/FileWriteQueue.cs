using System;
using System.Collections.Generic;
using System.Text;

namespace 生产消费队列实现写文本
{
    public class FileWriteQueue
    {
        private static readonly Dictionary<string, WriteItem> Dictionary = new Dictionary<string, WriteItem>();

        public static void AddOrUpdate(string key, WriteItem item)
        {
            if (Dictionary.ContainsKey(key))
            {
                Dictionary[key].Dispose();
                Dictionary[key] = item;
            }
            else
            {
                Dictionary.Add(key, item);
            }
        }

        public static WriteItem Get(string key)
        {
            return Dictionary[key];
        }
    }
}
