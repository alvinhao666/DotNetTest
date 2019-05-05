using HttpCode.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static ConcurrentDictionary<Type, PropertyInfo> enumCache = new ConcurrentDictionary<Type, PropertyInfo>();
        static void Main(string[] args)
        {




            //List<Person> lstPerson = new List<Person>();
            //for(int i=0;i<500000;i++)
            //{
            //    Person p = new Person() { Name = $"Name{i}" };
            //    lstPerson.Add(p);
            //}



            //Stopwatch watch = new Stopwatch();
            //watch.Start();


            //Type type = typeof(Person);

            //var name = type.GetProperty("Name");
            //var age = type.GetProperty("Age");
            //var delete = type.GetProperty("IsDelete");
            ////enumCache.GetOrAdd(type, type.GetProperty("Name"));

            ////var s = enumCache.GetOrAdd(type, type.GetProperty("Name"));

            //lstPerson.ForEach(a =>
            //{
            //    name.SetValue(a, a.Name + "新");
            //    age.SetValue(a, 10);
            //    delete.SetValue(a, false);
            //});
            ////bool flag=typeof(IPerson).IsAssignableFrom(type);
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed.TotalSeconds);

            //Stopwatch watch2 = new Stopwatch();
            //watch2.Start();
            //lstPerson.ForEach(a =>
            //{
            //    a.Name = "123";
            //    a.Age = 5;
            //    a.IsDelete = true;
            //});
            //watch2.Stop();
            //List<int> s = JsonConvert.DeserializeObject<List<int>>(null);
            //s.Add(1);


            //int pageIndex = 1;//页数
            //HttpHelpers httpHelpers = new HttpHelpers();
            //HttpItems items = new HttpItems();
            //items.Url = "https://www.cnblogs.com/mvc/AggSite/PostList.aspx";//请求地址
            //items.Method = "Post";//请求方式 post
            //items.Postdata = "{\"CategoryType\":\"SiteHome\"," +
            //                    "\"ParentCategoryId\":0," +
            //                    "\"CategoryId\":808," +
            //                    "\"PageIndex\":" + pageIndex + "," +
            //                    "\"TotalPostCount\":4000," +
            //                    "\"ItemListActionName\":\"PostList\"}";//请求数据
            //HttpResults hr = httpHelpers.GetHtml(items);

            string str = "[\"1\",\"1\",\"2\"]";
            List<string> list = JsonConvert.DeserializeObject<List<string>>(str);

            Person p = new Person() { Age = 10, LoginType = "324"};
           //p.Name = "213";
            Console.WriteLine(HMACSHA256("666666"));

            DateTime dt = DateTime.Parse("2018-04");
            //本月第一天时间      
            DateTime dt_First = dt.AddDays(1 - (dt.Day));
            //获得某年某月的天数    
            int year = dt.Date.Year;
            int month = dt.Date.Month;
            int dayCount = DateTime.DaysInMonth(year, month);
            //本月最后一天时间    
            DateTime dt_Last = dt_First.AddDays(dayCount - 1);


            Console.WriteLine(dt_First.ToString("yyyy-MM-dd HH:mm:ss"));


            Console.ReadKey();
        }




        public static string HMACSHA256(string srcString, string key= "Es6E3Fg/58kEOPKyi0X3+w==")
        {
            byte[] secrectKey = Encoding.UTF8.GetBytes(key);
            using (HMACSHA256 hmac = new HMACSHA256(secrectKey))
            {
                hmac.Initialize();

                byte[] bytes_hmac_in = Encoding.UTF8.GetBytes(srcString);
                byte[] bytes_hamc_out = hmac.ComputeHash(bytes_hmac_in);

                string str_hamc_out = BitConverter.ToString(bytes_hamc_out);
                str_hamc_out = str_hamc_out.Replace("-", "");

                return str_hamc_out;
            }
        }

    }


    class Person 
    {

        private string _loginType;
        /// <summary>
        /// 登录方式  手机：APP版本号；电脑：浏览器型号
        /// </summary>
        public string LoginType
        {
            get
            {
                if (Age == 10) return "123";
                return _loginType;
            }
            set { _loginType = value; }
        }

        public int Age { get; set; }

        public bool IsDelete { get; set; }
    }

    interface IPerson
    {
        string Name { get; set; }
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
