using Microsoft.Extensions.Configuration;
using System;
using System.Threading;

namespace Configuration读取
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                                                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) //热加载，\bin\Debug\net6.0\appsettings.json
                                                                    .Build();



            //T data = new T();  //绑定到实体
            //configuration.Bind(data);

            while (true)
            {
                var info = configuration["username"];

                var ip = configuration["mysql:ip"];

                Console.WriteLine(info);

                Console.WriteLine(ip);

                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }
    }
}
