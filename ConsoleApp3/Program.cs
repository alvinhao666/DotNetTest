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
            //const string _connectionString = "Data Source=47.96.143.165;port=3306;user id=root;password=5802486;Initial Catalog=tmsystem;convertzerodatetime=True;AutoEnlist=false;Charset=utf8;";
            //List<Users> list = new List<Users>();
            //using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            //{
            //    dbConnection.Open();

            //    string sql = @"select * from users WHERE Id =797"; //tms 和合伙人
            //    list = dbConnection.Query<Users>(sql).ToList();

            //}
            ////string str = "[\"1\",\"1\",\"2\"]";
            //List<string> ss = JsonConvert.DeserializeObject<List<string>>(list.FirstOrDefault().SecAuthorizationTypeTag);

            var user1 = new Users();
            var user2 = new Users();
            var users = new List<User>() { new User() { type = Type.typeX } };

            int d = (int)Type.typeY;

            Array arrays = Enum.GetValues(typeof(Type));
            Console.WriteLine(arrays.GetValue(0).ToString());

            Console.WriteLine("12312&nbsp;vfdf&nbsp;sdf&nbsp;sdfdcc".Split(new String[1] { "&nbsp;" }, 8, StringSplitOptions.None)[0]);

            Console.WriteLine("12312&nbsp;vfdf&nbsp;sdf&nbsp;sdfdcc".Split("1").FirstOrDefault()); //以开头字母分割 会有空格

            var user = JsonConvert.DeserializeObject<User>("{\"sdfds\":0}");
            Console.WriteLine(user.type);

            string s = "我";
            var dic = JsonConvert.DeserializeObject<SortedDictionary<string, object>>("{\"a\":\"1\",\"c\":\"我\"}");
            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>(dic);
            keyValues.OrderBy(m => m.Key);//按照键排序

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

            Console.WriteLine(users.FindAll(a=>a.type==Type.typeY).Count);
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

        public string c { get; set; }
    }

    public enum Type
    {
        typeX,
        typeY
    }
}
