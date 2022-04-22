using System;
using System.Threading;

namespace 控制台动画
{
    internal class Program
    {
        static bool isEnd = false;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Thread thread = new Thread(new ThreadStart(Flashing));
            thread.Start();
            //Thread.Sleep(10000);
            // 非 net 5.0 用 Abort
            //thread.Abort();
            // net 5.0 用 Interrupt
            thread.Interrupt();

            Console.Write('\u0008');
            Console.WriteLine("程序运行结束");
            Console.ReadLine();

        }
        public static void Flashing()
        {
            try
            {
                string loading = "-";
                while (isEnd)
                {
                    Console.Write('\u0008');
                    switch (loading)
                    {
                        case "\\": loading = "|"; break;
                        case "|": loading = "/"; break;
                        case "/": loading = "-"; break;
                        case "-": loading = "\\"; break;
                    }
                    Console.Write(loading);
                    Thread.Sleep(100);
                }
            }
            catch (Exception) { }
        }
    }
}
