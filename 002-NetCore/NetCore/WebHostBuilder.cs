using System;
using System.Collections.Generic;

namespace NetCore
{
    //ebHostBuilder的使命非常明确：就是创建作为应用宿主的WebHost。
    //由于在创建WebHost的时候需要提供注册的服务器和由所有注册中间件构建而成的RequestDelegate，所以在对应接口IWebHostBuilder中，我们为它定义了三个核心方法
    //除了用来创建WebHost的Build方法之外，我们提供了用来注册服务器的UseServer方法和用来注册中间件的Configure方法。
    //Configure方法提供了一个类型为Action<IApplicationBuilder>的参数，意味着我们针对中间件的注册是利用上面介绍的IApplicationBuilder对象来完成的
    public interface IWebHostBuilder
    {
        IWebHostBuilder UseServer(IServer server);
        IWebHostBuilder Configure(Action<IApplicationBuilder> configure);
        IWebHost Build();
    }

    public class WebHostBuilder : IWebHostBuilder
    {
        private IServer _server;
        private readonly List<Action<IApplicationBuilder>> _configures = new List<Action<IApplicationBuilder>>();
        public IWebHostBuilder Configure(Action<IApplicationBuilder> configure)
        {
            _configures.Add(configure);
            return this;
        }
        public IWebHostBuilder UseServer(IServer server)
        {
            _server = server;
            return this;
        }
        public IWebHost Build()
        {
            var builder = new ApplicationBuilder();
            foreach (var configure in _configures)
            {
                configure(builder);
            }
            return new WebHost(_server, builder.Build());
        }
    }
}
