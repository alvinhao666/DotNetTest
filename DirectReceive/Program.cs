using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace DirectReceive
{
    class Program
    {
        //2个发送 3个接收

        //启动  dotnet DirectClient.dll route1

        //启动  dotnet DirectClient.dll route2

        //接收  dotnet DirectReceive.dll route1

        //接收  dotnet DirectReceive.dll route2   这两个同时消费 route2的数据
        //接收  dotnet DirectReceive.dll route2

        //生产者按routing key发送消息，不同的消费者端按不同的routing key接收消息。 可以有
        static void Main(string[] args)
        {
            if (args.Length == 0) throw new ArgumentException("args");
            //创建一个随机数,以创建不同的消息队列
            int random = new Random().Next(1, 1000);
            Console.WriteLine("Start" + random.ToString());
            IConnectionFactory connFactory = new ConnectionFactory//创建连接工厂对象
            {
                HostName = "127.0.0.1",//IP地址
                Port = 5672,//端口号
                UserName = "admin",//用户账号
                Password = "admin"//用户密码
            };
            using (IConnection conn = connFactory.CreateConnection())
            {
                using (IModel channel = conn.CreateModel())
                {
                    //交换机名称
                    String exchangeName = "exchange2";
                    //声明交换机
                    channel.ExchangeDeclare(exchange: exchangeName, type: "direct");
                    //消息队列名称
                    String queueName = exchangeName + "_" + random.ToString();
                    //声明队列
                    channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                    //将队列与交换机进行绑定
                    foreach (var routeKey in args)
                    {//匹配多个路由
                        channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: routeKey);
                    }
                    //声明为手动确认
                    channel.BasicQos(0, 1, false);
                    //定义消费者
                    var consumer = new EventingBasicConsumer(channel);
                    //接收事件
                    consumer.Received += (model, ea) =>
                    {
                        byte[] message = ea.Body;//接收到的消息
                        Console.WriteLine("接收到信息为:" + Encoding.UTF8.GetString(message));
                        //返回消息确认
                        channel.BasicAck(ea.DeliveryTag, true);
                    };
                    //开启监听
                    channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
                    Console.ReadKey();
                }
            }
        }
    }
}
