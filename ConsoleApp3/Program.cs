using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

            var user = JsonConvert.DeserializeObject<Users>("{\"id\":1,\"secauthorizationtypetag\":\"uuuddc\"}");
            Console.WriteLine(user.SecAuthorizationTypeTag);

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
        public Type type { get; set; }
    }

    public enum Type
    {
        typeX,
        typeY
    }
}
