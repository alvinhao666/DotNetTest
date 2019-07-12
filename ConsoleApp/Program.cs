using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    class Program
    {
        delegate int MyDelegate(int x, int y);
        static void Main(string[] args)
        {
            var user1 = new Users();
            var user2 = new Users();
            var users = new List<User>() { new User() { type = Type.typeX } };

            int d = (int)Type.typeY;

            Array arrays = Enum.GetValues(typeof(Type));
            Console.WriteLine(arrays.GetValue(0).ToString());


            var user = JsonConvert.DeserializeObject<User>("{\"sdfds\":0}");
            Console.WriteLine(user.type);

            #region SortDictionary
            var dic = JsonConvert.DeserializeObject<SortedDictionary<string, object>>("{\"a\":\"1\",\"c\":\"我\"}");
            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>(dic);
            keyValues.OrderBy(m => m.Key);//按照键排序
            #endregion


            var data = new StringBuilder();
            data.Append("[");
            foreach (var item in keyValues)
            {
                Console.WriteLine(item.Value.GetType());
                data.Append("{\"" + item.Key + "\":" + item.Value + "}");
            }
            data.Append("]");

            string ss= data.ToString();
            List<object> sss = new List<object>();
            sss.Add("1");
            sss.Add(2);
            //var jObject =JsonConvert.DeserializeObject(SortedDictionary<string, object>);
            //Console.WriteLine(jObject);

            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            Console.WriteLine(Convert.ToInt64(ts.TotalSeconds).GetType()==typeof(long));

            //Console.WriteLine(string.Format("{\"\{0}\":{1}}", 1, 2));

            string date = "◎上映日期　2018-10-05(苏黎世电影节)/2019-05-17(美国)";

            string releaseDate = "";
            if(date.Contains("/"))
            {
                date = date.Split("/")[0];
            }
            foreach (Match match in Regex.Matches(date, @"\d{4}-\d{1,2}-\d{1,2}"))
            {
                releaseDate = match.Groups[0].Value;
            }
            User use = null;
            Console.WriteLine(JsonConvert.SerializeObject(null));

            for (var i = 0.1; i <= 1.0001; i = i + 0.05)
            {
                
                Console.WriteLine(i);
            }

            #region 属性get方法会重新执行
            CCar car = new CCar() { a = 1 };
            car.b = 2;  
            car.a = 5;
            #endregion

            Console.ReadKey();
        }


        static int Sum(int x ,int y)
        {
            return x + y;
        }

        static List<string> GetParameters(string text)
        {
            var matchVale = new List<string>();
            string Reg = @"(?<={)[^{}]*(?=})";
            string key = string.Empty;
            foreach (Match m in Regex.Matches(text, Reg))
            {
                matchVale.Add(m.Value);
            }
            return matchVale;
        }

    
    }

    public class Users
    {
        public long? Id { get; set; }



        public string SecAuthorizationTypeTag { get; set; }
    }




    public class User
    {
        [JsonProperty(PropertyName = "sdfds")]
        public Type type { get; set; }
    }

    public class Car
    {
        public int  a { get; set; }

        public int b { get; set; }

        public string c { get; set; }
    }

    public class A
    {
        public int a { get; set; }
    }

    public class C
    {
        public string c { get; set; }
    }

    public class CCar
    {
        public int a { get; set; }

        public int b { get; set; }

        public string c
        { get
            {
                string d = "";
                if (a > 0) d += a ;
                if (b > 0) d += b;
                return d;
            }
        }
    }

    public enum Type
    {
        typeX,
        typeY
    }
}
