using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TaskTest
{
    public class TaskException
    {
        public static async Task ThrowAfter(int timeout, Exception ex)
        {
            await Task.Delay(timeout);
            throw ex;
        }

        public static void PrintException(Exception ex)
        {
            Console.WriteLine("时间：{0}\n{1}\n======", stopWatch.Elapsed, ex);
        }

        private static readonly Stopwatch stopWatch = new Stopwatch();
        public static async Task MissHandling()
        {
            stopWatch.Start();
            var taskOne = ThrowAfter(1000, new NotSupportedException("Error 1"));
            var taskTwo = ThrowAfter(2000, new NotImplementedException("Error 2"));
            try
            {
                await taskOne;
                await taskTwo;
            }
            catch (NotSupportedException ex)
            {
                PrintException(ex);
            }
            catch (NotImplementedException ex)
            {
                PrintException(ex);
            }
            Console.ReadLine();
        }
    }
}
