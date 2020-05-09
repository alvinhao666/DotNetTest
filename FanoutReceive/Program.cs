using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace FanoutReceive
{
    class Program
    {
        //首先是声明交换机(同上面一样，为了防止异常)


        //然后声明消息队列并对交换机进行绑定，在这里使用了随机数，目的是声明不重复的消息队列，如果是同一个消息队列，则就变成worker模式，
        //也就是说对于发布订阅模式有多少接收者就有多少个消息队列，而这些消息队列共同从一个交换机中获取数据
        static void Main(string[] args)
        {
            //创建一个随机数,以创建不同的消息队列
            int random = new Random().Next(1, 1000);
            Console.WriteLine("Start" + random.ToString());
            IConnectionFactory connFactory = new ConnectionFactory//创建连接工厂对象
            {
                HostName = "127.0.0.1",//IP地址
                Port = 5672,//端口号d
                UserName = "admin",//用户账号
                Password = "admin"//用户密码
            };
            using (IConnection conn = connFactory.CreateConnection())
            {
                using (IModel channel = conn.CreateModel())
                {
                    //交换机名称
                    var exchangeName = "exchange1";

                    //声明交换机
                    channel.ExchangeDeclare(exchange: exchangeName, type: "fanout");
                    //消息队列名称
                    var queueName = exchangeName + "_" + random.ToString();
                    //声明队列
                    channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                    //将队列与交换机进行绑定
                    channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: "");
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
