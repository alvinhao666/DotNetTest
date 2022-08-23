using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RedisClient
{
    //https://www.cnblogs.com/whuanle/p/13956549.html
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress IP = IPAddress.Parse("127.0.0.1");
            IPEndPoint IPEndPoint = new IPEndPoint(IP, 6379);
            Socket client = new Socket(IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            client.ConnectAsync(IPEndPoint).GetAwaiter().GetResult();

            if (!client.Connected)
            {
                Console.WriteLine("连接 Redis 服务器失败！");
                Console.Read();
            }

            Console.WriteLine("恭喜恭喜，连接 Redis 服务器成功");


            // 后台接收消息
            new Thread(() =>
            {
                while (true)
                {
                    byte[] data = new byte[100];
                    int size = client.Receive(data);
                    Console.WriteLine();
                    Console.WriteLine(Encoding.UTF8.GetString(data));
                    Console.WriteLine();
                }
            }).Start();

            while (true)
            {
                Console.Write("$> ");
                string command = Console.ReadLine();
                // 发送的命令必须以 \r\n 结尾
                int size = client.Send(Encoding.UTF8.GetBytes(command + "\r\n"));
                Thread.Sleep(100);
            }
        }
    }
}
