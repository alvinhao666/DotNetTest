using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TaskTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Tasks have started...");

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++) //for循环太快，启动线程太慢
            {
                var m = i;
                //Console.WriteLine(i.ToString());
                //tasks.Add(Task.Factory.StartNew(async () => { await Test(m); }));


                tasks.Add(Test(m));
            }
            Task.WaitAll(tasks.ToArray());
       
            Console.ReadKey();
        }


        public static async Task Test(int num)
        {
            Console.WriteLine(num.ToString());

            await Task.Factory.StartNew(() => { Console.WriteLine($"{num * 20}"); });
        }

    }
}

