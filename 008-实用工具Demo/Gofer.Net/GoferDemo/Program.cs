using Gofer.NET;
using System;
using System.Threading.Tasks;

namespace GoferDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var taskQueue = TaskQueue.Redis("127.0.0.1:6379");
            var taskClient = new TaskClient(taskQueue);

            // Print the Time every Five Minutes, using a TimeSpan interval
            await taskClient.TaskScheduler.AddRecurringTask(() => WriteDate(),
                TimeSpan.FromMinutes(1), "five-minute-timespan");

            //// Print the Time every Seven Minutes, using a Crontab interval
            //await taskClient.TaskScheduler.AddRecurringTask(() => WriteDate(),
            //    "0 */7 * * * *", "seven-minute-crontab");


            //每天凌晨2点 减8个时区
            //taskClient.TaskScheduler.AddRecurringTask(() => JobManager.AutoExpireNumber(),
            //"0 0 18 * * *", "AutoExpireNumber").Wait();

            await taskClient.Listen();

            Console.ReadKey();
        }

        private static void WriteDate()
        {
            Console.WriteLine(DateTime.UtcNow.ToString());
        }
    }
}
