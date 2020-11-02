using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dictionary_HashTable_List_HashSet区别
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Student> hashSet = new HashSet<Student>();

            var s1 = new Student { Name = "张三", Age = 20 };

            hashSet.Add(s1);
            hashSet.Add(s1);

            var s2 = new Student { Name = "张三", Age = 20 };
            hashSet.Add(s2);

            Console.WriteLine(JsonConvert.SerializeObject(hashSet)); //输出两个张三


            Console.ReadKey();
        }
    }


    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
