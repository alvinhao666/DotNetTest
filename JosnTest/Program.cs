using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JosnTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(JObject.Parse("")); //报错
            JsonConvert.SerializeObject(null);

            string json = "";

            var s = JsonConvert.DeserializeObject<Student>(json); //空字符串 null

            var a = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(null)); //不报错

            var st = new Student();
            st = null;
            //var result = System.Text.Json.JsonSerializer.Serialize(null); //编译报错
            var result = System.Text.Json.JsonSerializer.Serialize(st);  //"null"

            //var cacheUser = System.Text.Json.JsonSerializer.Deserialize<Student>(json); // 空字符串报错


            Console.WriteLine(JsonConvert.DeserializeObject("23424"));


            Dictionary<string, int> sdfs = new Dictionary<string, int>();
            sdfs.Add("订单", 1);
            sdfs.Add("海运", 2);
            Console.WriteLine(JsonConvert.SerializeObject(sdfs));

            var allList = new List<Student>();

            allList.Add(new Student { Name="1",Id="1" });

            allList.Add(new Student { Name = "2", Id = "2" });

            allList.Add(new Student { Name = "3", Id = "3" });

            var childList = new List<Student>();

            childList.Add(new Student { Name = "1", Id = "1" });

            childList.Add(new Student { Name = "2", Id = "2" });
            childList.Add(new Student { Name = "3", Id = "3" });
            childList.Add(new Student { Name = "4", Id = "4" });


            Console.WriteLine(JsonConvert.SerializeObject(childList.Where(x => allList.Any(b => b.Id == x.Id)).ToList()));
            Console.ReadKey();
        }
    }

    public class Student
    { 
        public string Name { get; set; }

        public string Id { get; set; }
    }
}
