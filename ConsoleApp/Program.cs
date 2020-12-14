using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ConsoleApp3
{
    ////////////////////////////////////////////////////////////////////
    //                          _ooOoo_                               //
    //                         o8888888o                              //
    //                         88" . "88                              //
    //                         (| ^_^ |)                              //
    //                         O\  =  /O                              //
    //                      ____/`---'\____                           //
    //                    .'  \\|     |//  `.                         //
    //                   /  \\|||  :  |||//  \                        //
    //                  /  _||||| -:- |||||-  \                       //
    //                  |   | \\\  -  /// |   |                       //
    //                  | \_|  ''\---/''  |   |                       //
    //                  \  .-\__  `-`  ___/-. /                       //
    //                ___`. .'  /--.--\  `. . ___                     //
    //              ."" '<  `.___\_<|>_/___.'  >'"".                  //
    //            | | :  `- \`.;`\ _ /`;.`/ - ` : | |                 //
    //            \  \ `-.   \_ __\ /__ _/   .-` /  /                 //
    //      ========`-.____`-.___\_____/___.-`____.-'========         //
    //                           `=---='                              //
    //      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^        //
    //                   佛祖保佑       永不宕机     永无BUG            //
    ////////////////////////////////////////////////////////////////////
    class Program
    {
        delegate int MyDelegate(int x, int y);
        //private const DateTime date = DateTime.Now;



        static void Main(string[] args)
        {

            //浮点型， 由于计算机表达十进制小数时有误差，控制循环次数可能会有误差，但也不一定。为保险起见，能用整型，则用整型。
            //for (var i = 0.1; i <= 1.0001; i = i + 0.05)
            //{
            //    Console.WriteLine(i);
            //}

            
            #region 小数点默认类型double

            var a = 3.24; //小数默认double类型
            Console.WriteLine(a.GetType());
            #endregion

            #region long类型
            
            Console.WriteLine(long.MaxValue);//9223372036854775807  19位   负号- 20位

            Console.WriteLine(ulong.MaxValue);//18446744073709551615 20位 


            //Console.WriteLine(Convert.ToInt64(Math.Pow(2, 64))); //报错

            Console.WriteLine(Convert.ToUInt64(Math.Pow(2, 63))); //9223372036854775808 19位

            //Console.WriteLine(Convert.ToUInt64(Math.Pow(2, 64))); //报错

            Console.WriteLine(Math.Pow(2, 64));//18446744073709551616 20位

            //ulong sum = Convert.ToUInt64(Math.Pow(2, 0));
            //for (int i = 1; i <= 63; i++) 
            //{
            //    sum= sum | Convert.ToUInt64(Math.Pow(2, i));
            //}
            //Console.WriteLine(sum); //18446744073709551615 一共64个
            Console.WriteLine(18446744073709551615 & 2); //18446744073709551615 一共64个
            #endregion



            Test t = new Test();
            t.x = 100;
            object tt = t;//装箱
            ((Test)tt).test(300);//x还是100不变，为什么



            Console.WriteLine(new Student().Sta);
            
            DervEmployee objDervEmployee = new DervEmployee();
            objDervEmployee.EmpInfo();
            Student aaa = new Student();

            Student bbb = new Student();


            Console.WriteLine(Encoding.UTF8.GetBytes("666666")[0]);
            Console.WriteLine(aaa == bbb);


            Console.WriteLine(decimal.MinValue);

            int? s = null;
            Console.WriteLine(s.ToString());


            string sss = null;

            //Console.WriteLine(sss.ToString());

            Console.WriteLine(3.3 > null);//始终为false

            int? i = (int?)Status.X;

            var list = new List<string>();
            var dat = new List<string> { "1"};
            list.AddRange(dat);
            string str = "1234567";
            var str1 = str.Substring(0, 2);
            str1 = "21";
            var str2 = str.Substring(2, 4);
            Console.WriteLine(str1 + str2);

            var pros = typeof(Student).GetProperties();
            var fields= typeof(Student).GetFields();
            var stu = new Student();

            var typebool = typeof(bool);
            var typebool2 = typeof(bool?);
            var typeint2 = typeof(int?);
            Console.WriteLine(typebool == typebool2);
            Console.WriteLine(typebool2 == typeint2);

            Console.WriteLine(-1> 0 & 1 > 0);

            Console.WriteLine(float.Parse("3.1415926654"));

            Console.WriteLine(Convert.ToInt64(null));

            
            Console.WriteLine(21.02.ToString("#0.#####"));

            List<int> nums = new List<int>();
            for(int b = 0; b < 10000000; b++)
            {
                nums.Add(b);
            }

            //var datetimes = nums.Select(x => new { Name = x, Time =DateTime.Now }).ToList();
            //Console.WriteLine(datetimes[0].Time);
            //Console.WriteLine(datetimes[9999999].Time);


            string url = "https://blog.csdn.net/vileman/article/details/84871000/sss.png";
            //int m = url.LastIndexOf('.')+1;
            //url = url.Substring(m);

            var array = url.Split('.');
            var type = array[array.Length - 1];
            
            Console.WriteLine(type);

            Console.WriteLine(float.Parse("31.237212"));

            int? value = 0;
            value++;
            Console.WriteLine(value);

            string code = "苏L0L937";

            var flag=Regex.IsMatch(code, @"^(([京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领][A-Z](([0-9]{5}[DF])|([DF]([A-HJ-NP-Z0-9])[0-9]{4})))|([京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领][A-Z][A-HJ-NP-Z0-9]{4}[A-HJ-NP-Z0-9挂学警港澳使领]))$");


            Console.WriteLine(Convert.ToInt64(Math.Pow(2, 0)));


            //Console.WriteLine("".Substring(0, 2));

            object num = 10;
            long num2 = Convert.ToInt32(num);
            Console.WriteLine(num2);



            //Student sdfdf = new Student() { isT = null };

            //Console.WriteLine(sdfdf.isT?.Value ?? false);

            string str3 = "1.";

            var strArray = str3.Split('.'); //两个 第二个空""

            str3 = null ;
            try
            {
                throw new H_Exception(str3); 
            }
            //catch (H_Exception ex)
            //{
            //    var aaaa = 1;
            //}
            catch (Exception ex)  // null 的话 会引发"Exception of type 'Sino.SinoException' was thrown."
            {

            }

            Student stu222 = new Student { Name = "小李子", ddd = DateTime.Now };

            int number = 123;
            Console.WriteLine(ToUrlParam(number));

            Console.WriteLine(string.Join(',', new List<string>() { "1221" }));

            Console.WriteLine("1232".Split(',')[0]);

            Console.WriteLine("SJQKllrDin3Mz+L4P0ius1ARF3uqfNEA6PiUEf8pncQjbxCnBnDZ0oIGe5CEruws9h11KvDZPr4FW1K8fIzASjSe1VCrubTLcYQygkh3rgxgkhkiNVpUAq2f+uL03eXSoYHPh42aYNduNhYFS0HmGmJWXK/7NZ6OFi0u5xxpQg==".Length);
            Console.WriteLine("VhV+LQGJJSdPz2UfzymHqKbAu8nYxxDPRnOZu+fEymaOm96E+3iB02u6ca25/gM/FeDo0O9HbJN3jKRmR/MVdlNbChW2dTafnLxQgFhFGf4S8rD8ImS3J1BnuBjhwIDE0L1eoRw4EKkO53Hpxb20A0GfW9f5VcL5TiAd1brdA/s=".Length);
            bool abc = bool.Parse("true"); //可以转化 "1"不可以


            Console.WriteLine(GetMd5("235423svxvxzvc"));
            
            var isMy=false;
            // Console.WriteLine(isMy = true);
            // Console.WriteLine(true = isMy);
            if (isMy = true)
            {
                Console.WriteLine("xxxx1111");
            }
            else
            {
                Console.WriteLine("xxxx2222");
            }

            Console.WriteLine(string.Join(",",new List<int>()));

            decimal x = 0.994m;

            Console.WriteLine(decimal.Round(x, 2, MidpointRounding.AwayFromZero));  //1


            x = 1.12345678912300m;

            Console.WriteLine(x.ToString("0.#####"));

             x = 0.995m;

            Console.WriteLine(x.ToString("0.##"));

            Console.WriteLine(string.Format("{0:N2}", x));

            var allCount = 1999;
            var times = allCount / 2000 + 1;
            var remainCount = allCount % 2000;

            for (int j = 0; j < times; j++)
            {
                if (j == times - 1)
                {
                    var count= remainCount;
                }
                else
                {
                   var count = 2000;
                }
            }



            Console.ReadKey();
        }



        private static string GetMd5(string encryptString)
        {
            var md5 = MD5.Create();
            var result = md5.ComputeHash(Encoding.UTF8.GetBytes(encryptString));
            var strResult = BitConverter.ToString(result);
            return strResult.Replace("-", "");
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


        private static string ToUrlParam(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            var count = properties.Length;
            var index = 1;
            StringBuilder sb = new StringBuilder();
            sb.Append("?");
            foreach (var p in properties)
            {
                var v = p.GetValue(obj, null);

                if (v == null) continue;

                if (p.PropertyType.IsEnum || IsNullableEnum(p.PropertyType))
                {
                    v = (int)v;
                }

                sb.Append($"{p.Name}={HttpUtility.UrlEncode(v.ToString())}");

                if (index < count)
                {
                    sb.Append("&");
                    index++;
                }
            }
            return sb.ToString();
        }
        
        public static bool IsNullableEnum(Type t)
        {
            Type u = Nullable.GetUnderlyingType(t);
            return (u != null) && u.IsEnum;
        }

        public static bool IsNullableEnum2(Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>) && t.GetGenericArguments()[0].IsEnum;
        }
    }


    struct Test
    {
        public int x;
        public void test(int x)
        {
            this.x = x;
        }

        public bool ser { get; set; }
    }


    public class Student
    {
        public Status? Sta { get; set; } = Status.Y;

        private string _name = "abc";
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public DateTime ddd { get; set; } = DateTime.Now;

        public DateTime ddd2 => DateTime.Now;

        public DateTime ddd3;


        public bool isT { get; set; }
    }

    public enum Status
    {
        X,
        Y
    }
    
    class Employee
    {
        public virtual void EmpInfo()
        {
            Console.WriteLine("用virtual关键字修饰的方法是虚拟方法");
        }
    }
    class DervEmployee : Employee
    {
        public override void EmpInfo()
        {
            base.EmpInfo();//base关键字将在下面拓展中提到
            Console.WriteLine("该方法重写base方法");
        }
    }


    public class H_Exception : Exception
    {
        public int? Code { get; private set; }

        public H_Exception() { }

        public H_Exception(int? code)
        {
            this.Code = Code;
        }

        public H_Exception(string message) : base(message) { }

        public H_Exception(string message, int? code) : base(message)
        {
            this.Code = code;
        }

        public H_Exception(string message, Exception innerException) : base(message, innerException) { }
    }



}
