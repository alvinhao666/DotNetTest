using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SolutionRenamer
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "解决方案重命名工具";

            //加载配置
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config.json");

            var configuration = builder.Build();

            var fileExtensions = configuration["FileExtension"];

            string[] filter = fileExtensions.Split(',');

            Console.WriteLine();
            Console.WriteLine("请输入查找的字符:");
            var oldName = Console.ReadLine();

            Console.WriteLine("请输入替换的字符:");
            var replaceName = Console.ReadLine();

            Console.WriteLine("请输入文件路径:");
            var rootDir = Console.ReadLine();


            RenameAllDir(rootDir, oldName, replaceName);

            Console.WriteLine("文件夹重命名完成!");

            RenameAllFileNameAndContent(rootDir, oldName, replaceName, filter);

            Console.WriteLine("文件及文件内容重命名完成!");

            Console.WriteLine("");
            Console.WriteLine("=====================================完成=====================================");
            Console.ReadKey();
        }


        #region 递归重命名所有目录

        /// <summary>
        /// 递归重命名所有目录
        /// </summary>
        static void RenameAllDir(string rootDir, string oldName, string replaceName)
        {
            string[] allDir = Directory.GetDirectories(rootDir);

            foreach (var item in allDir)
            {
                RenameAllDir(item, oldName, replaceName);

                DirectoryInfo dinfo = new DirectoryInfo(item);
                if (dinfo.Name.Contains(oldName))
                {
                    var newName = dinfo.Name;

                    if (!string.IsNullOrEmpty(oldName))
                    {
                        newName = newName.Replace(oldName, replaceName);
                    }

                    var newPath = Path.Combine(dinfo.Parent.FullName, newName);

                    if (dinfo.FullName != newPath)
                    {
                        Console.WriteLine(dinfo.FullName);
                        Console.WriteLine("->");
                        Console.WriteLine(newPath);
                        Console.WriteLine("-------------------------------------------------------------");
                        dinfo.MoveTo(newPath);
                    }

                }
            }
        }

        #endregion

        #region 递归重命名所有文件名和文件内容

        /// <summary>
        /// 递归重命名所有文件名和文件内容
        /// </summary>
        static void RenameAllFileNameAndContent(string rootDir, string oldName, string replaceName, string[] filter)
        {
            //获取当前目录所有指定文件扩展名的文件
            List<FileInfo> files = new DirectoryInfo(rootDir).GetFiles().Where(m => filter.Any(f => f == m.Extension)).ToList();

            //重命名当前目录文件和文件内容
            foreach (var item in files)
            {

                var text = File.ReadAllText(item.FullName, Encoding.UTF8);
                if (!string.IsNullOrEmpty(oldName))
                {
                    text = text.Replace(oldName, replaceName);
                }

                if (item.Name.Contains(oldName))
                {
                    var newName = item.Name;

                    if (!string.IsNullOrEmpty(oldName))
                    {
                        newName = newName.Replace(oldName, replaceName);

                    }
                    var newFullName = Path.Combine(item.DirectoryName, newName);
                    File.WriteAllText(newFullName, text, Encoding.UTF8);
                    if (newFullName != item.FullName)
                    {
                        File.Delete(item.FullName);
                    }
                }
                else
                {
                    File.WriteAllText(item.FullName, text, Encoding.UTF8);
                }
                Console.WriteLine(item.Name + "  完成!");

            }

            //获取子目录
            string[] dirs = Directory.GetDirectories(rootDir);
            foreach (var dir in dirs)
            {
                RenameAllFileNameAndContent(dir, oldName, replaceName, filter);
            }
        }

        #endregion
    }

}
