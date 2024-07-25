using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace TopicReceive
{
    class Program
    {
        //生产者端不只按固定的routing key发送消息，而是按字符串“匹配”发送，消费者端同样如此。
        //与之前的路由模式相比，它将信息的传输类型的key更加细化，以“key1.key2.keyN…”的模式来指定信息传输的key的大类型和大类型下面的小类型，让消费者端可以更加精细的确认自己想要获取的信息类型。而在消费者端，不用精确的指定具体到哪一个大类型下的小类型的key，而是可以使用类似正则表达式(但与正则表达式规则完全不同)的通配符在指定一定范围或符合某一个字符串匹配规则的key，来获取想要的信息。“通配符交换机”（Topic Exchange）将路由键和某模式进行匹配。此时队列需要绑定在一个模式上。符号“#”匹配一个或多个词，符号“*”仅匹配一个词。

        //交换机exchange的type为topic
        //发送消息的routing key不是固定的单词，而是匹配字符串，如"china.#"，*匹配一个单词，#匹配0个或多个单词。因此如“china.#”能够匹配到“china.news.info”，但是“china.* ”只会匹配到“china.news”


        //多个相同的消费者可以同时接收
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
                    String exchangeName = "exchange3";
                    //声明交换机    通配符类型为topic
                    channel.ExchangeDeclare(exchange: exchangeName, type: "topic");
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
                        var message = ea.Body;//接收到的消息
                        Console.WriteLine("接收到信息为:" + Encoding.UTF8.GetString(message.Span));
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
