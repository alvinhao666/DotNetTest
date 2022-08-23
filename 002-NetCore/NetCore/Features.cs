using System;
using System.Collections.Specialized;
using System.IO;

namespace NetCore
{
    //面向应用层的HttpContext对象是对请求和响应的封装，但是请求最初来源于服务器，针对HttpContext的任何响应操作也必需作用于当前的服务器才能真正起作用。
    //现在问题来了，所有的ASP.NET Core应用使用的都是同一个HttpContext类型，但是却可以注册不同类型的服务器，我们必需解决两者之间的适配问题。
    //计算机领域有一句非常经典的话：“任何问题都可以通过添加一个抽象层的方式来解决，如果解决不了，那就再加一层”。
    //同一个HttpContext类型与不同服务器类型之间的适配问题也可可以通过添加一个抽象层来解决，我们定义在该层的对象称为Feature。
    //如上图所示，我们可以定义一系列的Feature接口来为HttpContext提供上下文信息，其中最重要的就是提供请求的IRequestFeature和完成响应的IResponseFeature接口。
    //那么具体的服务器只需要实现这些Feature接口就可以了。
    public interface IHttpRequestFeature
    {
        Uri Url { get; }
        NameValueCollection Headers { get; }
        Stream Body { get; }
    }
    public interface IHttpResponseFeature
    {
        int StatusCode { get; set; }
        NameValueCollection Headers { get; }
        Stream Body { get; }
    }
}
