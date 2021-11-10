using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetCore
{
    //在对服务器和它与HttpContext的适配原理具有清晰的认识之后，我们来尝试着自己定义一个服务器。
    //在前面的Hello World实例中，我们利用WebHostBuilder的扩展方法UseHttpListener注册了一个HttpListenerServer，我们现在就来看看这个采用HttpListener作为监听器的服务器类型是如何实现的。
    public class MyServer : IServer
    {
        private readonly HttpListener _httpListener;
        private readonly string[] _urls;
        public MyServer(params string[] urls)
        {
            _httpListener = new HttpListener();
            _urls = urls.Any() ? urls : new string[] { "http://localhost:5000/" };
        }

        public async Task StartAsync(RequestDelegate handler)
        {
            Array.ForEach(_urls, url => _httpListener.Prefixes.Add(url));
            _httpListener.Start();
            Console.WriteLine("Server started and is listening on: {0}", string.Join(';', _urls));
            while (true)
            {
                var listenerContext = await _httpListener.GetContextAsync();
                var feature = new HttpListenerFeature(listenerContext);
                var features = new FeatureCollection()
                    .Set<IHttpRequestFeature>(feature)
                    .Set<IHttpResponseFeature>(feature);
                var httpContext = new HttpContext(features);
                await handler(httpContext);
                listenerContext.Response.Close();
            }
        }
    }

    public static partial class Extensions
    {
        public static IWebHostBuilder UseMyServer(this IWebHostBuilder builder, params string[] urls)
        => builder.UseServer(new MyServer(urls));
    }
}
