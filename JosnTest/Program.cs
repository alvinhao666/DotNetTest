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

            result = H_JsonSerializer.Serialize(st);
            
            //result = H_JsonSerializer.Serialize("string");
            var result2 = H_JsonSerializer.Serialize(new int[]{1,2}.ToList());

            json = "";
            var cacheUser = System.Text.Json.JsonSerializer.Deserialize<Student>(json); // 空字符串报错

            json = "null";
            cacheUser = System.Text.Json.JsonSerializer.Deserialize<Student>(json);  //null

            Console.WriteLine(cacheUser == null);


            Console.WriteLine(JsonConvert.DeserializeObject("23424"));


            Dictionary<string, int> sdfs = new Dictionary<string, int>();
            sdfs.Add("订单", 1);
            sdfs.Add("海运", 2);
            Console.WriteLine(JsonConvert.SerializeObject(sdfs));


            Console.ReadKey();
        }
    }

    public class Student
    { 
        public string Name { get; set; }

        public string Id { get; set; }
    }


}
