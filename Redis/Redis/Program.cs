using CSRedis;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = ConnectionMultiplexer.Connect("47.96.143.165:6379,allowAdmin = true");
            var result = redis.GetDatabase().ScriptEvaluate(LuaScript.Prepare(
                //Redis的keys模糊查询：

                " local ks = redis.call('get', @key) " +
                " return ks "
   ),
            new { key = "TMSystemWebInstanceEmployeeList7f062263-c0e0-47c8-9886-67eca77aaf3e" });
            List<EmployeeRedisListOutput> list = new List<EmployeeRedisListOutput>();
            if (!result.IsNull)
            {
                //var vals = ((StackExchange.Redis.RedisResult[])((StackExchange.Redis.RedisResult[])result)[1]);
                //foreach (var item in vals)
                //{

                //}
                list.Add(JsonConvert.DeserializeObject<EmployeeRedisListOutput>(result.ToString()));
            }

            //普通模式

            var csredis = new CSRedisClient("127.0.0.1:6379,password=123,defaultDatabase=1,poolsize=50,ssl=false,writeBuffer=10240");

            //初始化 RedisHelper

            RedisHelper.Initialization(csredis);

            //Install-Package Caching.CSRedis (本篇不需要)

            //注册mvc分布式缓存

            //services.AddSingleton(new Microsoft.Extensions.Caching.Redis.CSRedisCache(RedisHelper.Instance));

            Test();

            Console.ReadKey();
        }




        static void Test()

        {
            Console.ForegroundColor = ConsoleColor.Green;
            RedisHelper.Subscribe(("rgh", msg => Console.WriteLine("订阅者" + msg.Body)));

            Console.ForegroundColor = ConsoleColor.White;
            RedisHelper.Set("name", "祝雷");//设置值。默认永不过期

            //RedisHelper.SetAsync("name", "祝雷");//异步操作

            Console.WriteLine(RedisHelper.Get("name"));

            RedisHelper.Set("time", DateTime.Now, 1);

            Console.WriteLine(RedisHelper.Get("time"));

            Thread.Sleep(1100);

            Console.WriteLine(RedisHelper.Get("time"));

            // 列表

            RedisHelper.RPush("list", "第一个元素");

            RedisHelper.RPush("list", "第二个元素");

            RedisHelper.LInsertBefore("list", "第二个元素", "我是新插入的第二个元素!");

            Console.WriteLine($"list的长度为{RedisHelper.LLen("list")}");

            //Console.WriteLine($"list的长度为{RedisHelper.LLenAsync("list")}");//异步

            Console.WriteLine($"list的第二个元素为{RedisHelper.LIndex("list", 1)}");

            //Console.WriteLine($"list的第二个元素为{RedisHelper.LIndexAsync("list",1)}");//异步

            // 哈希

            RedisHelper.HSet("person", "name", "zhulei");

            RedisHelper.HSet("person", "sex", "男");

            RedisHelper.HSet("person", "age", "28");

            RedisHelper.HSet("person", "adress", "hefei");

            Console.WriteLine($"person这个哈希中的age为{RedisHelper.HGet("person", "age")}");

            //Console.WriteLine($"person这个哈希中的age为{RedisHelper.HGetAsync("person", "age")}");//异步

            // 集合

            RedisHelper.SAdd("students", "zhangsan", "lisi");

            RedisHelper.SAdd("students", "wangwu");

            RedisHelper.SAdd("students", "zhaoliu");

            Console.WriteLine($"students这个集合的大小为{RedisHelper.SCard("students")}");

            Console.WriteLine($"students这个集合是否包含wagnwu:{RedisHelper.SIsMember("students", "wangwu")}");

            RedisHelper.Set("rongguohao", 5555);
            RedisHelper.Set("rongguohao2", new EmployeeReidsListDto() { Id = "123" });
            RedisHelper.Set("rongguohao3", 11111);
            var value = RedisHelper.Get("rongguohao");
            RedisHelper.Expire("rongguohao", 0);
            value = RedisHelper.Get("rongguohao");
            var aaa = RedisHelper.Get<EmployeeReidsListDto>("rongguohao2");
            var bbb = RedisHelper.Keys("rongguohao*");
            RedisHelper.Publish("rgh", "我是发布者");
        }

    }



    public class EmployeeRedisListOutput
    {
        public List<EmployeeReidsListDto> Data { get; set; }
        public int Total { get; set; }
    }

    public class EmployeeReidsListDto
    {
        /// <summary>
        /// 标识符
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public string LastLoginTime { get; set; }

        /// <summary>
        /// 专员类型
        /// </summary>
        public string Types { get; set; }

        /// <summary>
        /// 高级权限值
        /// </summary>
        public string HighAuthNumber { get; set; }

        /// <summary>
        /// 中级权限值
        /// </summary>
        public string MiddleAuthNumber { get; set; }

        /// <summary>
        /// 低级权限值
        /// </summary>
        public string LowAuthNumber { get; set; }

        /// <summary>
        /// 菜单别名列表
        /// </summary>
        public List<string> SecAuthorizationTypeTag { get; set; }
    }
}
