using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zhongqian
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
            //// Wait for all tasks to complete.
            Task.WaitAll(tasks.ToArray());
            //when Queue<Book> is empty,reload data...

            //when Cur>=Max,break the while loop
            Console.WriteLine(HMACSHA256("jmsexxw"));


            //string[] text = { "Albert was here", "Burke slept late", "Connor is happy" };
            //var tokens = text.Select(s => s.Split(" "));
            //foreach (string[] line in tokens)
            //    foreach (string token in line)
            //        Console.Write("{0}.", token);


            string no = "061407";
            Console.WriteLine(no.Substring(0, 2));
            Console.WriteLine(no.Substring(2, 2));
            Console.WriteLine(no.Substring(4, 2));

            //string[] text = { "Albert was here", "Burke slept late", "Connor is happy" };
            //var tokens = text.SelectMany(s => s.Split(' '));
            //foreach (string token in tokens)
            //    Console.Write("{0}.", token);

            Console.ReadKey();
        }


        public static async Task Test(int num)
        {
            Console.WriteLine(num.ToString());

            await Task.Factory.StartNew(() => { Console.WriteLine($"{num * 20}"); });
        }

        public static string HMACSHA256(string srcString, string key = "Es6E3Fg/58kEOPKyi0X3+w==")
        {
            byte[] secrectKey = Encoding.UTF8.GetBytes(key);
            using (HMACSHA256 hmac = new HMACSHA256(secrectKey))
            {
                hmac.Initialize();

                byte[] bytes_hmac_in = Encoding.UTF8.GetBytes(srcString);
                byte[] bytes_hamc_out = hmac.ComputeHash(bytes_hmac_in);

                string str_hamc_out = BitConverter.ToString(bytes_hamc_out);
                str_hamc_out = str_hamc_out.Replace("-", "");

                return str_hamc_out;
            }
        }

    }
}

