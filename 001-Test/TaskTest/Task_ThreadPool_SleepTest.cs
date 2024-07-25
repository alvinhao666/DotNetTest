using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTest
{
    public class Task_ThreadPool_SleepTest
    {
        public static void TestTask()
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

        public static void TestThreadPool()
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


        public static void TestThreadPool2()
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
                //    }
                //});

                //ThreadPool.QueueUserWorkItem(callback =>
                //{
                //    Console.WriteLine($"ThreadPool Task {taskId} completed.");
                //    while (true)
                //    {
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
