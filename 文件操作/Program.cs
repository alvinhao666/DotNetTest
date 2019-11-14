using System;
using System.Collections.Generic;
using System.IO;

namespace 文件操作
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo driveInfo = new DriveInfo("D");
            Console.WriteLine("驱动器的名称：" + driveInfo.Name);
            Console.WriteLine("驱动器类型：" + driveInfo.DriveType);
            Console.WriteLine("驱动器的文件格式：" + driveInfo.DriveFormat);
            Console.WriteLine("驱动器中可用空间大小：" + driveInfo.TotalFreeSpace);
            Console.WriteLine("驱动器总大小：" + driveInfo.TotalSize);
            Console.WriteLine("-----------------------------------------------------");
            DriveInfo[] drivers = DriveInfo.GetDrives();
            foreach (DriveInfo d in drivers)
            {
                if (d.IsReady)
                {
                    Console.WriteLine("驱动器名称：" + d.Name);
                    Console.WriteLine("驱动器的文件格式" + d.DriveFormat);
                }
            }


            DirectoryInfo directoryInfo = new DirectoryInfo("F:\\code");
            directoryInfo.Create();
            directoryInfo.CreateSubdirectory("code-1");
            directoryInfo.CreateSubdirectory("code-2");

            DirectoryInfo directoryInfos = new DirectoryInfo("F:\\桌面");
            IEnumerable<DirectoryInfo> dir = directoryInfos.EnumerateDirectories();
            foreach (var v in dir)
            {
                Console.WriteLine(v.Name);
            }

            bool flag = Directory.Exists("F:\\code"); //Directory 类省去了创建类实例的步骤，其他操作也与 Directoryinfo 类似。
            if (flag)
            {
                Directory.Delete("F:\\code", true);
            }
            else
            {
                Directory.CreateDirectory("F:\\code");
            }

            //C# 语言中 File 类和 FileInfo 类都是用来操作文件的，并且作用相似，它们都能完成对文件的创建、更改文件的名称、删除文件、移动文件等操作。

            //File 类是静态类，其成员也是静态的，通过类名即可访问类的成员；FileInfo 类不是静态成员，其类的成员需要类的实例来访问。

            //在D盘下创建code文件夹
            Directory.CreateDirectory("F:\\code");
            FileInfo fileInfo = new FileInfo("F:\\code\\test1.txt");
            if (!fileInfo.Exists)
            {
                //创建文件
                fileInfo.Create().Close();
            }
            fileInfo.Attributes = FileAttributes.Normal;//设置文件属性
            Console.WriteLine("文件路径：" + fileInfo.Directory);
            Console.WriteLine("文件名称：" + fileInfo.Name);
            Console.WriteLine("文件是否只读：" + fileInfo.IsReadOnly);
            Console.WriteLine("文件大小：" + fileInfo.Length);
            //先创建code-1 文件夹
            //将文件移动到code-1文件夹下
            Directory.CreateDirectory("F:\\code-1");
            //判断目标文件夹中是否含有文件test1.txt
            FileInfo newFileInfo = new FileInfo("F:\\code-1\\test1.txt");
            if (!newFileInfo.Exists)
            {
                //移动文件到指定路径
                fileInfo.MoveTo("F:\\code-1\\test1.txt");
            }

            //在D盘下创建code文件夹
            Directory.CreateDirectory("F:\\code");
            Directory.CreateDirectory("F:\\code-1");
            string path = "F:\\code\\test1.txt";
            //创建文件
            FileStream fs = File.Create(path);
            //获取文件信息
            Console.WriteLine("文件创建时间：" + File.GetCreationTime(path));
            Console.WriteLine("文件最后被写入时间：" + File.GetLastWriteTime(path));
            //关闭文件流
            fs.Close();
            //设置目标路径
            string newPath = "D:\\code-1\\test1.txt";
            //判断目标文件是否存在
            bool flag2 = File.Exists(newPath);
            if (flag2)
            {
                //删除文件
                File.Delete(newPath);
            }
            File.Move(path, newPath);

            //在 C# 语言中 Path 类主要用于文件路径的一些操作，它也是一个静态类

            Console.WriteLine("请输入一个文件路径：");
            string path = Console.ReadLine();
            Console.WriteLine("不包含扩展名的文件名：" + Path.GetFileNameWithoutExtension(path));
            Console.WriteLine("文件扩展名：" + Path.GetExtension(path));
            Console.WriteLine("文件全名：" + Path.GetFileName(path));
            Console.WriteLine("文件路径：" + Path.GetDirectoryName(path));
            //更改文件扩展名
            string newPath = Path.ChangeExtension(path, "doc");
            Console.WriteLine("更改后的文件全名：" + Path.GetFileName(newPath));
            Console.ReadKey();
        }
    }
}
