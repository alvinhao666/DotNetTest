using System;
using System.IO;
using System.Text;

namespace 流
{

    //计算机中的流其实是一种信息的转换。它是一种有序流，因此相对于某一对象，通常我们把对象接收外界的信息输入（Input）称为输入流，相应地从对象向外 输出（Output）信息为输出流，合称为输入/输出流（I/O Streams）。

    //对象间进行信息或者数据的交换时总是先将对象或数据转换为某种形式的流，再通过流的传输，到达目的对象后再将流转换为对象数据。

    //所以， 可以把流看作是一种数据的载体，通过它可以实现数据交换和传输。
    //流所在的命名空间也是System.IO，主要包括文本文件的读写、图像和声音文件的读写、二进制文件的读写等

    //流是字节序列的抽象概念，例如文件、输入/输出设备、内部进程通信管道等。

    //流提供一种向后备存储器写入字节和从后备存储器读取字节的方式。

    //除了和磁盘文件直接相关的文件流以外，流还有多种类型。

    //例如数据流(Stream) 是对串行传输数据的一种抽象表示，是对输入/输出的一种抽象。

    //数据有来源和目的地，衔接两者的就是串流对象。用比喻的方式来说或，数据就好比水，串流对象就好比水管，通过水管的衔接，水由一端流向另一端。

    //从应用程序的角度来说，如果将数据从来源取出，可以试用输入(读 ) 串流，把数据储存在内存缓冲区；如果将数据写入目的地，可以使用输出(写 ) 串流，把内存缓冲区的数据写入目的地。

    //当希望通过网络传输数据，或者对文件数据进行操作时，首先需要将数据转化为数据流。

    //典型的数据流和某个外部数据源相关，数据源可以是文件、外部设备、内存、网络套接字等。

    //根据数据源的不同，.Net 提供了多个从 Stream 类派生的子类，每个类代表一种具体的数据流类型，比如磁盘文件直接相关的文件流类 FileStream，和套接字相关的网络流类 NetworkStream，和内存相关的内存流类 MemoryStream 等。

    //在创建 FileStream 类的实例时还会涉及多个枚举类型的值， 包括 FileAccess、FileMode、FileShare、FileOptions 等。

    //FileAccess 枚举类型主要用于设置文件的访问方式，具体的枚举值如下。

    //    Read：以只读方式打开文件。
    //    Write：以写方式打开文件。
    //    ReadWrite：以读写方式打开文件。


    //FileMode 枚举类型主要用于设置文件打开或创建的方式，具体的枚举值如下。

    //    CreateNew：创建新文件，如果文件已经存在，则会抛出异常。
    //    Create：创建文件，如果文件不存在，则删除原来的文件，重新创建文件。
    //    Open：打开已经存在的文件，如果文件不存在，则会抛出异常。
    //    OpenOrCreate：打开已经存在的文件，如果文件不存在，则创建文件。
    //    Truncate：打开已经存在的文件，并清除文件中的内容，保留文件的创建日期。如果文件不存在，则会抛出异常。
    //    Append：打开文件，用于向文件中追加内容，如果文件不存在，则创建一个新文件。


    //FileShare 枚举类型主要用于设置多个对象同时访问同一个文件时的访问控制，具体的枚举值如下。

    //    None：谢绝共享当前的文件。
    //    Read：允许随后打开文件读取信息。
    //    ReadWrite：允许随后打开文件读写信息。
    //    Write：允许随后打开文件写入信息。
    //    Delete：允许随后删除文件。
    //    Inheritable：使文件句柄可由子进程继承。


    //FileOptions 枚举类型用于设置文件的高级选项，包括文件是否加密、访问后是否删除等，具体的枚举值如下。

    //    WriteThrough：指示系统应通过任何中间缓存、直接写入磁盘。
    //    None：指示在生成 System.IO.FileStream 对象时不应使用其他选项。
    //    Encrypted：指示文件是加密的，只能通过用于加密的同一用户账户来解密。
    //    DeleteOnClose：指示当不再使用某个文件时自动删除该文件。
    //    SequentialScan：指示按从头到尾的顺序访问文件。
    //    RandomAccess：指示随机访问文件。
    //    Asynchronous：指示文件可用于异步读取和写入。



    class Program
    {
        static void Main(string[] args)
        {
            // StreamReader 类用于从流中读取字符串。它继承自 TextReader 类。
            // StreamReader 类对应的是 StreamWriter 类，StreamWriter 类主要用于向流中写入数据。
            //定义文件路径
            string path = @"D:\\code\\test.txt";
            //创建 StreamReader 类的实例
            StreamReader streamReader = new StreamReader(path);
            //判断文件中是否有字符
            while (streamReader.Peek() != -1)
            {
                //读取文件中的一行字符
                string str = streamReader.ReadLine();
                Console.WriteLine(str);
            }
            streamReader.Close();


            //文件读写流使用 FileStream 类来表示，FileStream 类主要用于文件的读写，不仅能读写普通的文本文件，还可以读取图像文件、声音文件等不同格式的文件。
            path = "F:\\test.txt";
            FileStream fileStream1 = new FileStream(path, FileMode.Open);
            FileStream fileStream2 = new FileStream(path, FileMode.Open, FileAccess.Read);
            FileStream fileStream3 = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            FileStream fileStream4 = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 10, FileOptions.None);

            //以二进制形式读取数据时使用的是 BinaryReader 类。
            //创建文件流的实例
            FileStream fileStream = new FileStream("D:\\code\\test.txt", FileMode.Open);
            BinaryReader binaryReader1 = new BinaryReader(fileStream);
            BinaryReader binaryReader2 = new BinaryReader(fileStream, Encoding.UTF8);
            BinaryReader binaryReader3 = new BinaryReader(fileStream, Encoding.UTF8, true);


            //【实例】在 D 盘 code 文件夹的 test.txt 文件中写入图书的名称和价格，使用 BinaryReader 类读取写入的内容。

            FileStream fileStream8 = new FileStream(@"D:\\code\\test.txt", FileMode.Open, FileAccess.Write);
            //创建二进制写入流的实例
            BinaryWriter binaryWriter = new BinaryWriter(fileStream8);
            //向文件中写入图书名称
            binaryWriter.Write("C#基础教程");
            //向文件中写入图书价格
            binaryWriter.Write(49.5);
            //清除缓冲区的内容，将缓冲区中的内容写入到文件中
            binaryWriter.Flush();
            //关闭二进制流
            binaryWriter.Close();
            //关闭文件流
            fileStream.Close();
            fileStream = new FileStream(@"D:\\code\\test.txt", FileMode.Open, FileAccess.Read);
            //创建二进制读取流的实例
            BinaryReader binaryReader = new BinaryReader(fileStream);
            //输出图书名称
            Console.WriteLine(binaryReader.ReadString());
            //输出图书价格
            Console.WriteLine(binaryReader.ReadDouble());
            //关闭二进制读取流
            binaryReader.Close();
            //关闭文件流
            fileStream.Close();
            Console.ReadKey();
        }
    }
}
