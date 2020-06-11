using Hao.Snowflake;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace 雪花id测试
{
    class Program
    {
        private static int N = 2000000;
        private static HashSet<long> set = new HashSet<long>();
        private static IdWorker worker = new IdWorker(1, 1);
        private static int taskCount = 0;

        static void Main(string[] args)
        {
            Console.WriteLine(ConvertLongToDateTime(1288834974657L).ToString("yyyy-MM-dd HH:mm:ss"));

            Task.Run(() => GetID());
            Task.Run(() => GetID());
            Task.Run(() => GetID());

            Task.Run(() => Printf());
            //set.Add(1);
            //set.Add(1);
            //set.Add(2);  
            //Console.WriteLine(set.Count); //2
            Console.ReadKey();
        }

        private static void Printf()
        {
            while (taskCount != 3)
            {
                Console.WriteLine("...");
                Thread.Sleep(1000);
            }
            Console.WriteLine(set.Count == N * taskCount);
        }

        private static object o = new object();
        private static void GetID()
        {
            for (var i = 0; i < N; i++)
            {
                var id = worker.NextId();

                lock (o)
                {
                    if (set.Contains(id))
                    {
                        Console.WriteLine("发现重复项 : {0}", id);
                    }
                    else
                    {
                        set.Add(id);
                    }
                }

            }
            Console.WriteLine($"任务{++taskCount}完成");
        }

        public static DateTime ConvertLongToDateTime(long d)
        {
            DateTime startTime = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            long mTime = long.Parse($"{d}0000");
            TimeSpan toNow = new TimeSpan(mTime);
            var time = startTime.Add(toNow);
            return time;
        }
    }
}
