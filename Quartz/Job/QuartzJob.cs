using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quartz
{
    public class QuartzJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var jobKey = context.JobDetail.Key;//获取job信息
            var triggerKey = context.Trigger.Key;//获取trigger信息


            Console.WriteLine($"{DateTime.Now} QuartzJob:==>>自动执行.{jobKey.Name}|{triggerKey.Name}");
            await Task.CompletedTask;
        }
    }
}
