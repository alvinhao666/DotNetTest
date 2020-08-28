using System;
using System.Diagnostics;
using System.Threading;

namespace 高并发限流
{
    class Program
    {
        static LimitService l = new LimitService(1000, 1);
        static void Main(string[] args)
        {
        
            int threadCount = 0;
            while (threadCount >= 0)
            {
                Thread t = new Thread(s =>
                {
                    Limit();
                });
                t.Start();
                threadCount--;

            }
            Console.ReadKey();
        }

        public static void Limit()
         {
             int i = 0;
             int okCount = 0;
             int noCount = 0;
             Stopwatch w = new Stopwatch();
             w.Start();
             while (i< 1000000)
             {
                 var ret = l.IsContinue();
                 if (ret)
                 {
                     okCount++;
                 }
                 else
                 {
                     noCount++;
                 }
                 i++;
             }
             w.Stop();
             Console.WriteLine($"共用{w.Elapsed.Milliseconds},允许：{okCount},  拦截：{noCount}");
         }
    }
}
