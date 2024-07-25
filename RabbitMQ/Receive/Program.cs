using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace Receive
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 简单队列
            //IConnectionFactory connFactory = new ConnectionFactory//创建连接工厂对象
            //{
            //    HostName = "127.0.0.1",//IP地址
            //    Port = 5672,//端口号
            //    UserName = "admin",//用户账号
            //    Password = "admin"//用户密码
            //};
            //using (IConnection conn = connFactory.CreateConnection())
            //{
            //    using (IModel channel = conn.CreateModel())
            //    {
            //        var queueName = "queue1";

            //        //声明一个队列
            //        channel.QueueDeclare(
            //          queue: queueName,//消息队列名称
            //          durable: false,//是否缓存
            //          exclusive: false,
            //          autoDelete: false,
            //          arguments: null
            //           );
            //        //创建消费者对象
            //        var consumer = new EventingBasicConsumer(channel);
            //        consumer.Received += (model, ea) =>
            //        {
            //            byte[] message = ea.Body;//接收到的消息
            //            Console.WriteLine("接收到信息为:" + Encoding.UTF8.GetString(message));
            //        };
            //        //消费者开启监听
            //        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
            //        Console.ReadKey();
            //    }
            //}
            #endregion


            #region 竞争消费模式 worker模式 一个消息生产者,多个消息消费者,一个队列

            //1.丢失数据:一旦其中一个宕机,那么另外接收者的无法接收原本这个接收者所要接收的数据
            //2.无法实现能者多劳:如果其中的接收者接收的较慢,那么便会极大的浪费性能,所以需要实现接收快的多接收
            //第二个接收者在接收数据途中宕机,第一个接收者也并没有去接收第二个接收者宕机后的数据
            //,有的时候我们会有当接收者宕机后,其余数据交给其它接收者进行消费,那么该怎么进行处理呢,解决这个问题得方法就是改变其消息确认模式

            //    在Rabbit中存在两种消息确认模式,

            //自动确认: 只要消息从队列获取,无论消费者获取到消息后是否成功消费,都认为是消息成功消费,也就是说上面第二个接收者其实已经消费了它所接收的数据

            //     手动确认:消费从队列中获取消息后,服务器会将该消息处于不可用状态,等待消费者反馈

            //     也就是说我们只要将消息确认模式改为手动即可, 改为手动确认方式只需改两处,1.开启监听时将autoAck参数改为false,2.消息消费成功后返回确认
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
                    var queueName = "queue1";

                    //声明一个队列
                    channel.QueueDeclare(
                      queue: queueName,//消息队列名称
                      durable: false,//是否缓存
                      exclusive: false,
                      autoDelete: false,
                      arguments: null
                       );
                    //告诉Rabbit每次只能向消费者发送一条信息,再消费者未确认之前,不再向他发送信息
                    channel.BasicQos(0, 1, false);
                    //创建消费者对象
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        //Thread.Sleep(3000); //等待3秒, ctrl+c执行宕机
                        Thread.Sleep((new Random().Next(1, 6)) * 1000);//随机等待,实现能者多劳,
                        var message = ea.Body;//接收到的消息
                        Console.WriteLine("接收到信息为:" + Encoding.UTF8.GetString(message.Span));
                        //返回消息确认
                        channel.BasicAck(ea.DeliveryTag, true);
                    };
                    //消费者开启监听
                    //将autoAck设置false 关闭自动确认
                    //channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
                    channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
                    Console.ReadKey();
                }
            }
            #endregion
        }
    }
}
