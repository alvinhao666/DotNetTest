using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore
{
    //既然针对当前请求的所有输入和输出都通过HttpContext来表示，那么HttpHandler就可以表示成一个Action<HttpContext>对象。
    //那么HttpHandler在ASP.NET Core中是通过Action<HttpContext>来表示的吗？其实不是的，原因很简单：Action<HttpContext>只能表示针对请求的 “同步” 处理操作，但是针对HTTP请求既可以是同步的，也可以是异步的，更多地其实是异步的。

    //那么在.NET Core的世界中如何来表示一个同步或者异步操作呢？你应该想得到，那就是Task对象，那么HttpHandler自然就可以表示为一个Func<HttpContext，Task> 对象。由于这个委托对象实在太重要了，所以我们将它定义成一个独立的类型。
    public delegate Task RequestDelegate(HttpContext context);
}
