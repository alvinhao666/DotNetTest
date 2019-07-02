using System;
using System.IO;
using System.Text;

namespace 生产消费队列实现写文本
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWriteQueue.AddOrUpdate("success", new WriteItem(Path.Combine("结果", "成功"), Encoding.Default, true, true));
            FileWriteQueue.AddOrUpdate("error", new WriteItem(Path.Combine("结果", "失败"), Encoding.Default, true, true));
            for (int i = 0; i < 1000; i++)
            {
                FileWriteQueue.Get("success").WriteLine(i.ToString());
            }
            Console.ReadKey();
        }
    }
}
