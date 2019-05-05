using Dapper;
using HttpCode.Core;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ConsoleApp1
{
    class Program
    {
        //static ConcurrentDictionary<Type, PropertyInfo> enumCache = new ConcurrentDictionary<Type, PropertyInfo>();
        static void Main(string[] args)
        {




            //List<Person> lstPerson = new List<Person>();
            //for (int i = 0; i < 500000; i++)
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


            //Dictionary<int, int> pars = new Dictionary<int, int>() { { 0,2} };

            //List<int> ss = new List<int>();
            //for(int i = 0; i < 100; i++)
            //{
            //    ss.Add(GetRandomIndex(pars));
            //}
            //int all = ss.Count();
            //int A0 = ss.Where(a => a == 0).Count();
            //int A1= ss.Where(a => a == 1).Count();
            //int A2 = ss.Where(a => a == 2).Count();
            //int A3 = ss.Where(a => a == 3).Count();
            //Console.WriteLine(A0);
            //Console.WriteLine(A1);
            //Console.WriteLine(A2);
            //Console.WriteLine(A3);
            //Console.ReadKey();

               string publicKey =
            "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDMkmzEoj7LFqLmfKqix11b2A5SMXsAE9ag/9Uq+YeiJfFq5TtP7VpGdJUx06SgQqghgWL5hXLRVTMUn8LVW2SmHV0WjvFAqhtTK9CyTYFQ9wFXy7tpxHcl6jZnw8rokzY2y4yN5WbzEJ4+1c9j0Yp+oeTk0NauyOC03lEOEY9BGwIDAQAB";

         string privateKey =
            "MIICXAIBAAKBgQDMkmzEoj7LFqLmfKqix11b2A5SMXsAE9ag/9Uq+YeiJfFq5TtP7VpGdJUx06SgQqghgWL5hXLRVTMUn8LVW2SmHV0WjvFAqhtTK9CyTYFQ9wFXy7tpxHcl6jZnw8rokzY2y4yN5WbzEJ4+1c9j0Yp+oeTk0NauyOC03lEOEY9BGwIDAQABAoGAO106Zw1V/4VAHHaM5dPIycA21684LFuVav8Skvf6Xhl4pzaCMb2E9vEZ4m2yVjdBpwdu+024dfqtagy6c0OkPvNr6hp18DkjG94iERAWYTzO26hFaeRj/66p9O0I5VJauOCifwzHI50OM/qV0gUzTCeMu7wh6TXylK9RCpMVx7ECQQDo0kTBkqTKIxI98pauI2zwIpkmpzwVdxnqNNZC8UxaM2VZ6uTkJaQoc1BtpclgXAtRM4qN2agMa3E89ggf+B1FAkEA4PAvzu4zbjT5z9LdieP/Y/AMmGk/1OF2cK3R6ft5IG5GDRY1i/seHzLOMp4c6yxwo3cvHwaJ39z1bHUxVw3a3wJBANx626/w3muqYMkXZYiNdcnHCf/n2Wd+faUk2k9U0XiOOYm4f4BrARVpdp4PpS/CmtkQFUMV/yWbzgXr/G/B+H0CQGKRHYIB40uRrz4gWq/H1uvGDt7ij/QK8EmkAW4UohlR+SRW7RPv8F0feDe6DVYIXTtkSKPBy7zrKChkmkBZc+UCQCLSSKhMl6X/CZr13zM9pjiwEEXFmxL61ErUc9/qvOkSvzSqbC/XD1GZ996HS4iMoSt7GXqmuX9xsIMwuQIMIE4=";


            ////2048 公钥
            //string publicKey =
            //    "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDMkmzEoj7LFqLmfKqix11b2A5SMXsAE9ag/9Uq+YeiJfFq5TtP7VpGdJUx06SgQqghgWL5hXLRVTMUn8LVW2SmHV0WjvFAqhtTK9CyTYFQ9wFXy7tpxHcl6jZnw8rokzY2y4yN5WbzEJ4+1c9j0Yp+oeTk0NauyOC03lEOEY9BGwIDAQAB";
            ////2048 私钥
            //string privateKey =
            //    "MIICXAIBAAKBgQDMkmzEoj7LFqLmfKqix11b2A5SMXsAE9ag/9Uq+YeiJfFq5TtP7VpGdJUx06SgQqghgWL5hXLRVTMUn8LVW2SmHV0WjvFAqhtTK9CyTYFQ9wFXy7tpxHcl6jZnw8rokzY2y4yN5WbzEJ4+1c9j0Yp+oeTk0NauyOC03lEOEY9BGwIDAQABAoGAO106Zw1V/4VAHHaM5dPIycA21684LFuVav8Skvf6Xhl4pzaCMb2E9vEZ4m2yVjdBpwdu+024dfqtagy6c0OkPvNr6hp18DkjG94iERAWYTzO26hFaeRj/66p9O0I5VJauOCifwzHI50OM/qV0gUzTCeMu7wh6TXylK9RCpMVx7ECQQDo0kTBkqTKIxI98pauI2zwIpkmpzwVdxnqNNZC8UxaM2VZ6uTkJaQoc1BtpclgXAtRM4qN2agMa3E89ggf+B1FAkEA4PAvzu4zbjT5z9LdieP/Y/AMmGk/1OF2cK3R6ft5IG5GDRY1i/seHzLOMp4c6yxwo3cvHwaJ39z1bHUxVw3a3wJBANx626/w3muqYMkXZYiNdcnHCf/n2Wd+faUk2k9U0XiOOYm4f4BrARVpdp4PpS/CmtkQFUMV/yWbzgXr/G/B+H0CQGKRHYIB40uRrz4gWq/H1uvGDt7ij/QK8EmkAW4UohlR+SRW7RPv8F0feDe6DVYIXTtkSKPBy7zrKChkmkBZc+UCQCLSSKhMl6X/CZr13zM9pjiwEEXFmxL61ErUc9/qvOkSvzSqbC/XD1GZ996HS4iMoSt7GXqmuX9xsIMwuQIMIE4=";

            var rsa = new RSAHelper(RSAType.RSA, Encoding.UTF8, privateKey, publicKey);

            string str = "45c48c";

            Console.WriteLine("原始字符串：" + str);

            //加密
            string enStr = rsa.Encrypt(str);

            Console.WriteLine("加密字符串：" + enStr);

            ////解密
            //string deStr = rsa.Decrypt("mqXGR7acpvbiuTuYiODD9cFAiEFVe0phidipgr/wKMXEXz/WxqeAeZFP99KO4QPeAPXipVYSjls5zdFqhsC+JJfxBKJpohhqDXMKgIZQf+RHsQKQLt1AdKCQsImoXaVdJKDB0PxA9bqATmNIR1ie/w+Ug6xNtw5yTnISAmLLArU=");

            //Console.WriteLine("解密字符串：" + deStr);

            ////私钥签名
            //string signStr = rsa.Sign(str);

            //Console.WriteLine("字符串签名：" + signStr);

            ////公钥验证签名
            //bool signVerify = rsa.Verify(str, signStr);

            //Console.WriteLine("验证签名：" + signVerify);

            //////////const string _connectionString = "Data Source=192.168.1.110;port=3306;user id=root;password=123456;Initial Catalog=tmsystem;convertzerodatetime=True;";

            //////////List<Users> list = new List<Users>();
            //////////using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            //////////{
            //////////    Console.WriteLine("开启");
            //////////    dbConnection.Open();

            //////////    string sql = @"select * from users WHERE SystemType in (2,3)"; //tms 和合伙人
            //////////    list = dbConnection.Query<Users>(sql).ToList();

            //////////}
            //////////foreach (var item in list)
            //////////{
            //////////    Console.WriteLine(item.UserName + "--" + item.Password + "---" + item.GesturePassword);

            //////////    if (!string.IsNullOrWhiteSpace(item.Password))
            //////////    {
            //////////        item.Password = HMACSHA256(item.Password, "Es6E3Fg/58kEOPKyi0X3+w==");
            //////////    }
            //////////    if (!string.IsNullOrWhiteSpace(item.GesturePassword))
            //////////    {
            //////////        item.GesturePassword = HMACSHA256(item.GesturePassword, "Es6E3Fg/58kEOPKyi0X3+w==");
            //////////    }

            //////////}

            //////////using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            //////////{
            //////////    dbConnection.Open();

            //////////    var sql = @"UPDATE users SET Password=@Password WHERE Id = @Id ;";

            //////////    var res = dbConnection.Execute(sql, list);
            //////////}

            //////////Console.WriteLine("更新成功");
            //////////Console.ReadKey();

            //var result = from a in list
            //             group a by a.Year into g
            //             select new { Year = g.Key, Months = g };
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Year );
            //    foreach (var s in item.Months)
            //    {
            //        Console.WriteLine("===="+s.Month);
            //    }
            //}

            //Console.WriteLine(Regex.IsMatch("ss31Z`", @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[\s\S]{6,}$"));
            //bool isX = false;
            //string s = "Bearer 31123";
            //Console.WriteLine(s.Remove(0,7));
            Console.ReadKey();
        }

        public static string HMACSHA256(string srcString, string key)
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

    //public static Random Random = new Random();
    //public static int GetRandomIndex(Dictionary<int, int> pars)
    //{
    //    int maxValue = pars.Sum(a=>a.Value);
    //    //foreach (var item in pars)
    //    //{
    //    //    maxValue += item.Value;
    //    //}
    //    var num = Random.Next(1, maxValue);
    //    var result = 0;
    //    var endValue = 0;
    //    int index = 0;
    //    foreach (var item in pars)
    //    {
    //        var beginValue = index == 0 ? 0 : pars[index - 1];
    //        endValue += item.Value;
    //        result = item.Key;
    //        if (num >= beginValue && num <= endValue)
    //            break;
    //        index++;
    //    }
    //    return result;
    //}

    //static int ParallelSum(IEnumerable<int> values)
    //{
    //    return values.AsParallel().Aggregate(
    //    seed: 0,
    //    func: (sum, item) => sum + item
    //    );
    //}
    //async static Task WaitAsync()
    //{
    //    await Task.Delay(TimeSpan.FromSeconds(1));
    //}

    /// <summary>
    /// 获取所有字段
    /// </summary>
    /// <param name="enumType">枚举类型</param>
    /// <returns></returns>


    //}

    class Person:IPerson
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsDelete { get; set; }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    public class Users
    {
        public long Id { get; set; }
        /// <summary>
        /// 用户名（最大200字符）
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码（最大200字符）
        /// </summary>
        public string Password { get; set; }


        public string GesturePassword { get; set; }
    }



}



