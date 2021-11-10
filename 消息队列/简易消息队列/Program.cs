﻿using System;
using System.Threading.Tasks;

namespace 简易消息队列
{
    class Program
    {
        static void  Main(string[] args)
        {
            Task.Factory.StartNew(() =>
            {
                //从队列中取元素。
                while (!DemoQueueBlock<DemoMessage>.IsComleted())
                {
                    try
                    {
                        var m = DemoQueueBlock<DemoMessage>.Take();
                        Console.WriteLine("已消费:" + m.BusinessId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            });
            //添加元素
            while (true)
            {
                Console.WriteLine("请输入队列");
                var read = Console.ReadLine();
                if (read == "exit")
                {
                    return;
                }

                DemoQueueBlock<DemoMessage>.Add(new DemoMessage() { BusinessId = read });
            }
        }
    }
}
