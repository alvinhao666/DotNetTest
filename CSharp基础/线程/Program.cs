using System;
using System.Threading;

namespace 线程
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(OneTest);
            thread.Name = "Test";
            thread.Start();
            Console.ReadKey();

        }

        public static void OneTest()
        {
            Thread thisTHread = Thread.CurrentThread;
            Console.WriteLine("线程标识：" + thisTHread.Name);
            Console.WriteLine("当前地域：" + thisTHread.CurrentCulture.Name);  // 当前地域
            Console.WriteLine("线程执行状态：" + thisTHread.IsAlive);
            Console.WriteLine("是否为后台线程：" + thisTHread.IsBackground);
            Console.WriteLine("是否为线程池线程：" + thisTHread.IsThreadPoolThread);

            //线程标识：Test
            //当前地域：zh - CN
            //线程执行状态：True
            //是否为后台线程：False
            //是否为线程池线程False
        }
    }
}
