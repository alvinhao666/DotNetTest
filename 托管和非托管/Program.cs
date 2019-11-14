using System;

namespace 托管和非托管
{
    //在.NET 平台上资源分为托管资源和非托管资源，托管资源是由.NET 框架直接提供对其资源在内存中的管理，例如声明的变量；
    //非托管资源则不能直接由.NET 框架对其管理，需要使用代码来释放资源，例如数据库资源、操作系统资源等。例如SqlConnection 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
