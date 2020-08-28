using RabbitMQ.Client;
using System;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 简单队列模式,一个消息生产者,一个消息消费者,一个队列
            //IConnectionFactory conFactory = new ConnectionFactory//创建连接工厂对象
            //{
            //    HostName = "127.0.0.1",//IP地址
            //    Port = 5672,//端口号
            //    UserName = "admin",//用户账号
            //    Password = "admin"//用户密码
            //};
            //using (var con = conFactory.CreateConnection())
            //{
            //    using (var channel = con.CreateModel())
            //    {

            //        //声明一个队列
            //        channel.QueueDeclare(
            //          queue: "queue1",//消息队列名称
            //          durable: false,//是否缓存
            //          exclusive: false,
            //          autoDelete: false,
            //          arguments: null
            //           );

            //        while (true)
            //        {
            //            Console.WriteLine("消息内容:");
            //            String message = Console.ReadLine();
            //            //消息内容
            //            byte[] body = Encoding.UTF8.GetBytes(message);
            //            //发送消息
            //            channel.BasicPublish(exchange: "", routingKey: "queue1", basicProperties: null, body: body);
            //            Console.WriteLine("成功发送消息:" + message);
            //        }

            //    }
            //}
            #endregion

            
            #region 竞争消费模式 worker模式 一个消息生产者,多个消息消费者,一个队列
            IConnectionFactory conFactory = new ConnectionFactory//创建连接工厂对象
            {
                HostName = "127.0.0.1",//IP地址
                Port = 5672,//端口号
                UserName = "admin",//用户账号
                Password = "admin"//用户密码
            };
            using (var con = conFactory.CreateConnection())
            {
                using (var channel = con.CreateModel())
                {

                    //声明一个队列
                    channel.QueueDeclare(
                      queue: "queue1",//消息队列名称
                      durable: false,//是否缓存
                      exclusive: false,
                      autoDelete: false,
                      arguments: null
                       );

                    while (true)
                    {
                        Console.WriteLine("消息内容:");
                        String message = Console.ReadLine();
                        //消息内容
                        byte[] body = Encoding.UTF8.GetBytes(message);
                        //发送消息
                        channel.BasicPublish(exchange: "", routingKey: "queue1", basicProperties: null, body: body);
                        Console.WriteLine("成功发送消息:" + message);
                    }

                }
            }
            #endregion

        }
    }
}
