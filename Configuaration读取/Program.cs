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
                                                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) //热加载，\bin\Debug\netcoreapp2.2\appsettings.json
                                                                    .Build();


            while(true)
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
