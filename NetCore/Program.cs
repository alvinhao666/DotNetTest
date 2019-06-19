using System;
using System.Threading.Tasks;

namespace NetCore
{
    //第一个对象：HttpContext,请求在服务器与中间件之间，以及在中间件之间的分发是通过共享上下文的方式实现的。
    //第二个对象：RequestDelegate,从命名可以看出这是一个委托（Delegate）对象，和上面介绍的HttpContext一样，我们也只有从管道的角度才能充分理解这个委托对象的本质。
    //第三个对象：Middleware,对于管道的中的某一个中间件来说，由后续中间件组成的管道体现为一个RequestDelegate对象，由于当前中间件在完成了自身的请求处理任务之后，往往需要将请求分发给后续中间件进行处理，所有它它需要将由后续中间件构成的RequestDelegate作为输入。
    //第四个对象：ApplicationBuilder
    //第五个对象：Server
    //第六个对象：WebHost
    //第七个对象：WebHostBuilder,就是创建作为应用宿主的WebHost。由于在创建WebHost的时候需要提供注册的服务器和由所有注册中间件构建而成的RequestDelegate，所以在对应接口IWebHostBuilder中，我们为它定义了三个核心方法。
    class Program
    {
        public static async Task Main()
        {
            await new WebHostBuilder()
                .UseHttpListener()
                .Configure(app => app
                    .Use(FooMiddleware)
                    .Use(BarMiddleware)
                    .Use(BazMiddleware))
                .Build()
                .StartAsync();
        }

        public static RequestDelegate FooMiddleware(RequestDelegate next)
        => async context => {
            await context.Response.WriteAsync("Foo=>");
            await next(context);
        };

        public static RequestDelegate BarMiddleware(RequestDelegate next)
        => async context => {
            await context.Response.WriteAsync("Bar=>");
            await next(context);
        };

        public static RequestDelegate BazMiddleware(RequestDelegate next)
        => context => context.Response.WriteAsync("Baz");
    }
}
