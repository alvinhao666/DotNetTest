using MessagePack;
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

            var s = JsonConvert.DeserializeObject<Student>(json); //空字符串 null  //不报错

            s = JsonConvert.DeserializeObject<Student>("null"); // null  //不报错

            var ssss = JsonConvert.SerializeObject("123123"); // null  //不报错

            var ss = JsonConvert.SerializeObject(null);  //不报错
            var a = JsonConvert.DeserializeObject(ss); //不报错

            var st = new Student();
            st = null;
            //var result = System.Text.Json.JsonSerializer.Serialize(null); //编译报错
            var result = System.Text.Json.JsonSerializer.Serialize(st);  //"null"

            result = H_JsonSerializer.Serialize(st);

            //result = H_JsonSerializer.Serialize("string");
            var result2 = H_JsonSerializer.Serialize(new int[] { 1, 2 }.ToList());

            json = "";
            //var cacheUser = System.Text.Json.JsonSerializer.Deserialize<Student>(json); // 空字符串报错

            //json = "null";
            //cacheUser = System.Text.Json.JsonSerializer.Deserialize<Student>(json);  //null

            //Console.WriteLine(cacheUser == null);


            Console.WriteLine(JsonConvert.DeserializeObject("23424"));


            Dictionary<string, int> sdfs = new Dictionary<string, int>();
            sdfs.Add("订单", 1);
            sdfs.Add("海运", 2);
            Console.WriteLine(JsonConvert.SerializeObject(sdfs));



            string sssssd = "{\"id\":0,\"isUpdate\":false,\"dataJson\":[{\"auth\":\"\",\"index\":9,\"type\":\"轮播图\",\"key\":\"pa\",\"level\":0,\"data\":{\"format\":\"string\",\"value\":\"https://sinostoragedev.oss-cn-hangzhou.aliyuncs.com/upload/2020/11/25/f43ba2fb21154d3d9096995de594575e.png\"}},{\"auth\":\"\",\"index\":10,\"type\":\"轮播图\",\"key\":\"pb\",\"level\":0,\"data\":{\"format\":\"string\",\"value\":\"https://sinostoragedev.oss-cn-hangzhou.aliyuncs.com/upload/2020/11/25/8aea3722720d4f76aa1607d6372aba1c.png\"}}]}";


            var dds = JsonConvert.DeserializeObject<CrsIdentityData>(sssssd);

            IPerson person = new Student() { Id = "123", Name = "小明" };
            //var personString = JsonConvert.SerializeObject(person);

            //person = JsonConvert.DeserializeObject<IPerson>(personString);

            School school = new School() { Person = person };
            var schoolString = JsonConvert.SerializeObject(school);

            //school = JsonConvert.DeserializeObject<School>(schoolString); //接口和抽象类，不可以反序列化


            List<string> stringDemo = new List<string> { "1", "2", "3" };
            Console.WriteLine(JsonConvert.SerializeObject(stringDemo));


            string httpBody = "{\"alipay_fund_trans_uni_transfer_response\":{\"code\":\"10000\",\"msg\":\"Success\",\"out_biz_no\":\"201808080001\",\"order_id\":\"20190801110070000006380000250621\",\"pay_fund_order_id\":\"20190801110070001506380000251556\",\"status\":\"SUCCESS\",\"trans_date\":\"2019-08-2100:00:00\"},\"sign\":\"ERITJKEIJKJHKKKKKKKHJEREEEEEEEEEEE\"}";

            JObject jObj = JObject.Parse(httpBody);
            JObject jArr = JObject.Parse(jObj["alipay_fund_trans_uni_transfer_response"].ToString());
            var orderId = jArr["order_id"].ToString();

            #region MessagePack
            MyClass message = new MyClass()
            {
                Name = "DOTNET开发跳槽",
                Quantity = 100,
                Anything = new List<object>(new object[] { "欢迎关注公众号DOTNET开发跳槽", 2, false, 4.2d, "祝大家学业有成" })
            };

            // 序列化
            var buffer = MessagePackSerializer.Serialize(
              message,
              MessagePack.Resolvers.ContractlessStandardResolver.Options);

            var json2 = MessagePackSerializer.ConvertToJson(buffer);

            Console.WriteLine(json2);

            MyClass returnMsg = MessagePackSerializer.Deserialize<MyClass>(buffer, MessagePack.Resolvers.ContractlessStandardResolver.Options);
            #endregion



            Console.ReadKey();
        }
    }

    public class MyClass
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<object> Anything { get; set; }
    }

    public class School
    {
        public IPerson Person { get; set; }
    }

    public abstract class IPerson
    {
        public string Name { get; set; }

        public string Id { get; set; }
    }

    //public interface IPerson
    //{
    //    string Name { get; set; }

    //    string Id { get; set; }
    //}

    public class Student : IPerson
    {
        public string Name { get; set; }

        public string Id { get; set; }
    }

    public class CrsIdentityData
    {
        public int id { get; set; }


        public bool isUpdate { get; set; }


        public List<CrsDataJson> dataJson { get; set; }
    }

    public class CrsDataJson
    {
        /// <summary>
        /// 权限码，预留字段
        /// </summary>
        public string auth { get; set; } = "";

        /// <summary>
        /// 标识属性索引（不能为1001）
        /// </summary>
        public int index { get; set; }

        /// <summary>
        /// 标识属性类型 展示名称
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 属性Key
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// 数据等级 -1 是 隐藏数据 前端不做展示
        /// </summary>
        public int level { get; set; } = 0;

        /// <summary>
        /// 标识属性内容
        /// </summary>
        public CrsDataJsonFormatData data { get; set; }
    }

    public class CrsDataJsonFormatData
    {
        /// <summary>
        /// 标识属性内容格式（现只支持string）
        /// </summary>
        public string format { get; set; } = "string";

        /// <summary>
        /// 标识属性内容值
        /// </summary>
        public string value { get; set; }
    }
}
