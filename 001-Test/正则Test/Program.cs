using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace 正则Test
{
    class Program
    {
        private static AsyncLocal<Dictionary<string, string>> Params_Str_AsyncLocal = new AsyncLocal<Dictionary<string, string>>();

        //public static Dictionary<string, string> Params_Str => Params_Str_AsyncLocal.Value ?? (Params_Str_AsyncLocal.Value = new Dictionary<string, string>());

        static async Task Main(string[] args)
        {
            //Console.WriteLine(Regex.IsMatch("s21312", "^[a-zA-Z]+$"));

            //Console.WriteLine(Regex.IsMatch("ssdf", "^[a-zA-Z0-9]+$"));

            //int q = -1;

            //var value = (ushort)q;  //65535

            ////var value2 = (ushort)(-1);

            //var array = BitConverter.GetBytes(value);

            //var a = BitConverter.ToUInt16(array,0);

            //var B = short.MaxValue;

            //var C = ushort.MaxValue;

            //Console.WriteLine(array);

            Params_Str_AsyncLocal.Value = new Dictionary<string, string>();

            Params_Str_AsyncLocal.Value.Add("1", "1");

            await Task.Run(async () =>
            {

                Params_Str_AsyncLocal.Value.Add("2", "2");

                Params_Str_AsyncLocal.Value.Add("3", "3");

                Console.WriteLine("第一次输出" + Thread.CurrentThread.ManagedThreadId.ToString());
                foreach (var kvp in Params_Str_AsyncLocal.Value)
                {
                    Console.WriteLine(kvp.Key);
                }

                await Task.Run(() =>
                {

                    Params_Str_AsyncLocal.Value.Add("111", "2");

                    Params_Str_AsyncLocal.Value.Add("222", "3");

                });

            });

            await Task.Run(async() =>
            {
                Params_Str_AsyncLocal.Value = new Dictionary<string, string>();

                Params_Str_AsyncLocal.Value.Add("4", "4");
                Params_Str_AsyncLocal.Value.Add("5", "5");


                await Task.Run(() =>
                {
                    Params_Str_AsyncLocal.Value = new Dictionary<string, string>();

                    Params_Str_AsyncLocal.Value.Add("6", "6");
                    Params_Str_AsyncLocal.Value.Add("7", "7");

                    Console.WriteLine("第二次输出" + Thread.CurrentThread.ManagedThreadId.ToString());
                    foreach (var kvp in Params_Str_AsyncLocal.Value)
                    {
                        Console.WriteLine(kvp.Key);
                    }
                });

                Params_Str_AsyncLocal.Value.Add("8", "8");
                Console.WriteLine("第三次输出" + Thread.CurrentThread.ManagedThreadId.ToString());
                foreach (var kvp in Params_Str_AsyncLocal.Value)
                {
                    Console.WriteLine(kvp.Key);
                }
            });



            Console.WriteLine("最后输出" + Thread.CurrentThread.ManagedThreadId.ToString());
            foreach (var kvp in Params_Str_AsyncLocal.Value)
            {
                Console.WriteLine(kvp.Key);
            }

            Console.ReadKey();
        }
    }
}
