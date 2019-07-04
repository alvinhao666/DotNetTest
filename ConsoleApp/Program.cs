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

            List<string> lst = new List<string>() { "1", "2", "3", "4", "5","6" };

            List<List<string>> listGroup = new List<List<string>>();
            int j = 3;
            for (int i = 0; i < lst.Count; i += 3)
            {
                Console.WriteLine(i);
                List<string> cList = new List<string>();
                cList = lst.Take(j).Skip(i).ToList();
                j += 3;
                listGroup.Add(cList);
            }

            string sdd = JsonConvert.SerializeObject(new { date = DateTime.Now });

            var dd = JsonConvert.DeserializeObject<Temp>(sdd);
            var ds=Convert.ToDateTime(dd.date);


            DateTime vv = Convert.ToDateTime("2019-01-01T23:33:23");

            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));

            foreach (Match match in Regex.Matches("2018-4-20", @"\d{4}-\d{1,2}-\d{1,2}"))
            {
                releaseDate = match.Groups[0].Value;
            }

            foreach (Match match in Regex.Matches("2323ddsdf2018-4-20xxx", @"((?<!\d)((\d{2,4}(\.|年|\/|\-))((((0?[13578]|1[02])(\.|月|\/|\-))((3[01])|([12][0-9])|(0?[1-9])))|(0?2(\.|月|\/|\-)((2[0-8])|(1[0-9])|(0?[1-9])))|(((0?[469]|11)(\.|月|\/|\-))((30)|([12][0-9])|(0?[1-9]))))|((([0-9]{2})((0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))(\.|年|\/|\-))0?2(\.|月|\/|\-)29))日?(?!\d))"))
            {
                releaseDate = match.Groups[0].Value;
            }

            string strhtml = NoHTML("</font>,&nbsp;<font face=\"Arial\"><span style=\"font - size: 14px; line - height: 21.59375px; \">,  满清康熙鼎盛之际，自十三岁入宫当宫女的兆佳沉香（");

            DateTime dt = DateTime.Parse("2019.1.1 10:10:11");
            //本月第一天时间      
            int year = dt.Date.Year;
            int month = dt.Date.Month;
            int dayCount = DateTime.DaysInMonth(year, month);
            var a = new DateTime(2019, 6, 23,10,20,20);
            var b = DateTime.Now.Date;
            var c = (a - b).Days;

            CCar car = new CCar() { a = 1 };
            car.b = 2;  //属性get方法会重新执行。
            car.a = 5;

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

        public static string NoHTML(string Htmlstring)  //替换HTML标记
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<img[^>]*>;", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            return Htmlstring;
        }
    }

    public class Users
    {
        public long? Id { get; set; }



        public string SecAuthorizationTypeTag { get; set; }
    }

    public class Temp
    {
        public string date { get; set; }
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
