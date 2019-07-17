using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AopDemo2
{
    public class AOPTest : IInterceptor
    {
        public ILogger<AOPTest> _logger { get; set; } //属性注入

        //public ILogger<AOPTest> _logger = new LoggerFactory().CreateLogger<AOPTest>();

        //内置的服务容器旨在满足框架和大多数消费者应用的需求。 我们建议使用内置容器，除非你需要的特定功能不受它支持。 内置容器中找不到第三方容器支持的某些功能：
        //属性注入
        //基于名称的注入
        //子容器
        //自定义生存期管理
        //对迟缓初始化的 Func<T> 支持

        public void Intercept(IInvocation invocation)
        {
            _logger.LogInformation("你正在调用方法{0} ", invocation.Method.Name, string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));
            //在被拦截的方法执行完毕后 继续执行           
            invocation.Proceed();

            _logger.LogInformation("方法执行完毕，返回结果：{0}", invocation.ReturnValue);
        }
    }
}
