using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace JosnTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(JObject.Parse("")); //报错

            string json = "{\"Name\":\"张三\"}";

            var s = JsonConvert.DeserializeObject<Student>(json);
            Console.WriteLine();
            Console.ReadKey();
        }
    }

    public class Student
    { 
        public string Name { get; set; }

        public string Age { get; set; }
    }
}
