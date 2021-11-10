using System;

namespace _2策略模式
{
    //介绍
    //定义一系列的算法，把它们一个个封装起来，并且使它们可相互替换。本模式使得算法的变化可独立于使用它的客户。

    //示例
    //有一个Message实体类，对它的操作有Insert()和Get()方法，持久化数据在SqlServer数据库中或Xml文件里（两种可互换的算法）。由客户端决定使用哪种算法。
    class Program
    {
        static void Main(string[] args)
        {
            Message m = new Message(new XmlMessage());

            Console.WriteLine(m.Insert(new MessageModel() {Message="插入",PublishTime=DateTime.Now }));

            Console.WriteLine(m.Get()[0].Message + " " + m.Get()[0].PublishTime.ToString());

            m = new Message(new SqlMessage());

            Console.WriteLine(m.Insert(new MessageModel() { Message = "插入", PublishTime = DateTime.Now }));

            Console.WriteLine(m.Get()[0].Message + " " + m.Get()[0].PublishTime.ToString());

            Console.ReadKey();
        }
    }
}
