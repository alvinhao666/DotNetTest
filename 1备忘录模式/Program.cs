using System;

namespace 备忘录模式
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlMessage m = new SqlMessage()
            {
                Message = "内容",
                PublishTime = DateTime.Now
            };

            MessageModelCaretaker mmc = new MessageModelCaretaker();
            mmc.MessageModel = m.SaveMemento();

            bool flag = false;

            while (!flag)
            {
                flag = m.insert(new MessageModel() { Message = m.Message, PublishTime = m.PublishTime });

                Console.WriteLine(m.Message + " " + m.PublishTime.ToString() + " " + flag.ToString());

                if (!flag)
                {
                    System.Threading.Thread.Sleep(1000);
                    m.RestoreMemento(mmc.MessageModel);
                    m.PublishTime = DateTime.Now;
                }
            }
            Console.ReadKey();
        }
    }
}
