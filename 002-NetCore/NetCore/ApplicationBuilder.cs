using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore
{
    //既然Pipeline = Server + HttpHandler，那么用来处理请求的HttpHandler不就承载了当前应用的所有职责吗？
    //那么HttpHandler就等于Application，由于HttpHandler通过RequestDelegate表示，那么由ApplicationBuilder构建的Application就是一个RequestDelegate对象
    public interface IApplicationBuilder
    {
        //Use方法用来注册提供的中间件，Build方法则将注册的中间件构建成一个RequestDelegate对象
        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware);
        RequestDelegate Build();
    }
    public class ApplicationBuilder : IApplicationBuilder
    {
        private readonly List<Func<RequestDelegate, RequestDelegate>> _middlewares = new List<Func<RequestDelegate, RequestDelegate>>();
        public RequestDelegate Build()
        {
            _middlewares.Reverse();
            return httpContext =>
            {
                RequestDelegate next = _ => { _.Response.StatusCode = 404; return Task.CompletedTask; };

                foreach (var middleware in _middlewares)
                {
                    next = middleware(next);
                }
                return next(httpContext);
            };
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }
    }
}
