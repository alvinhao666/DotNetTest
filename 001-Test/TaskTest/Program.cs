using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTest
{
    class Program
    {
        static async Task Main(string[] args)
        {


            //await MoreTaskTestAsync();

            await TaskException.MissHandling();
            Console.ReadKey();
        }


        public static async Task Test(int num) //没有await
        {
            Console.WriteLine(num.ToString());

            //await Task.Factory.StartNew(() => { Console.WriteLine($"{num * 20}"); });
        }

        private static List<int> data = Enumerable.Range(1, 1000).ToList();

        public static async Task MoreTaskTestAsync()
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                var tempi = i;  //线程变量：tempData，每个线程只访问自己的，互不影响，运行结果
                //写多线程的时候需要注意，变量的作用域，否则程序运行出来的结果将不会是想要的结果，注意，注意变量作用域。   //闭包
                var t = Task.Run(() =>
                {
                    List<int> tempData = new List<int>();
                    foreach (var d in data)
                    {
                        tempData.Add(d);
                    }
                    Console.WriteLine($"i:{tempi},合计:{data.Sum()},是否相等：{data.Sum() == tempData.Sum()}");
                });
                tasks.Add(t);
            }

            await Task.WhenAll(tasks); //或者Task.WaitAll(tasks.ToArray());
            Console.WriteLine("多线程运行结束");
        }


        public static async Task TestExpection()
        {
            throw new Exception("SDFDSF");
        }




        static void TestTask()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            Task[] tasks = new Task[10000];
            for (int i = 0; i < tasks.Length; i++)
            {
                int taskId = i;
                tasks[i] = Task.Run(async () =>
                {
                    // 模拟一些工作  
                    await Task.Delay(100);
                    Console.WriteLine($"Task {taskId} completed.");
                });
            }

            Task.WaitAll(tasks);

            stopwatch.Stop();

            Console.WriteLine($"Task execution time: {stopwatch.ElapsedMilliseconds} ms.");
        }

        static void TestThreadPool()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var countdownEvent = new CountdownEvent(10000);
            for (int i = 0; i < 10000; i++)
            {
                int taskId = i;
                ThreadPool.QueueUserWorkItem(async callback =>
                {
                    // 模拟一些工作  
                    await Task.Delay(100);
                    Console.WriteLine($"ThreadPool Task {taskId} completed.");
                    countdownEvent.Signal();// 表示一个任务已经完成 
                });
            }
            // 等待所有任务完成  
            countdownEvent.Wait();
            stopwatch.Stop();
            Console.WriteLine($"ThreadPool execution time: {stopwatch.ElapsedMilliseconds} ms.");
        }


        static void TestThreadPool2()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                int taskId = i;
                //ThreadPool.QueueUserWorkItem(callback =>
                //{
                //    Console.WriteLine($"ThreadPool Task {taskId} completed.");
                //    while (true)
                //    {
                //        Thread.Sleep(100); //阻塞方式 不行
                //        Task.Delay(100).Wait(); //阻塞方式 不行
                //    }
                //});

                ThreadPool.QueueUserWorkItem(async callback =>
                {
                    Console.WriteLine($"ThreadPool Task {taskId} completed.");
                    while (true)
                    {
                        await Task.Delay(100);
                    }
                });
            }

            ThreadPool.QueueUserWorkItem(callback =>
            {
                //如果采用阻塞方式  这边执行不到
                Console.WriteLine($"ThreadPool Task completed.");
            });

            stopwatch.Stop();
            Console.WriteLine($"ThreadPool execution time: {stopwatch.ElapsedMilliseconds} ms.");
        }

    }
}

