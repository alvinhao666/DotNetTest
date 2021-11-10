using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace BlockingCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<string> blockingCollection = new BlockingCollection<string>();
            ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
            var t = new Task[50];
            for (int i = 0; i <= 49; i++)
            {
                t[i] = Task.Factory.StartNew((obj) =>
                {
                    Thread.Sleep(2500);
                    blockingCollection.Add(obj.ToString());
                    queue.Enqueue(obj.ToString());
                    Console.WriteLine("Task中的数据: {0}", obj.ToString());
                }, i + 1);
            }
            Console.ReadKey();
        }
    }
}
