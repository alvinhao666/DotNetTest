using StackExchange.Redis;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = ConnectionMultiplexer.Connect("47.96.143.165:6379,allowAdmin = true");
            var result=redis.GetDatabase().ScriptEvaluate(LuaScript.Prepare(
                //Redis的keys模糊查询：

                " local ks = redis.call('get', @key) "+
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

            Console.ReadKey();
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
