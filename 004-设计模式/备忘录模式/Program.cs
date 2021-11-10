using System;

namespace 备忘录模式
{
    //在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。这样以后就可将该对象恢复到保存的状态。

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
