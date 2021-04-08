
using System;
using System.Data;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace SinoData
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=192.168.1.201;port=23306;user id=root;password=123456;Initial Catalog=tmsystem;convertzerodatetime=True;Charset=utf8;";




            StringBuilder sb = new StringBuilder();
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"select * from orders where  ClientId = 'e4588545-db46-4510-88bd-c82114765738' and isdeleted=0 and RealClientCode is not null
                    and RealclientCode != '' and realClient is not null and RealClient!=''";

                var orders = connection.Query<Order>(sql).AsList();

                Console.WriteLine($"临时客户单位共{orders.Count}条");

                List<LogisticsClientCode> list = new List<LogisticsClientCode>();
                int count = 1;
                foreach (var item in orders)
                {
                    var old = list.Where(a => a.LogisticsId == item.LogisticsId.Value && a.RealClientCode == item.RealClientCode).FirstOrDefault();

                    Guid? id = null;

                    if (old == null)
                    {
                        string sql2 = $"SELECT Id from EnterpriseLogisticsRelations  WHERE IsDeleted=0 and LogisticsCompanyId='{item.LogisticsId}' and EnterpriseCode='{item.RealClientCode}'";

                        id = connection.QueryFirstOrDefault<Guid?>(sql2);

                        if (id.HasValue)
                        {
                            list.Add(new LogisticsClientCode { LogisticsId = item.LogisticsId.Value, RealClientCode = item.RealClientCode, ClientId = id.Value });
                        }
                    }
                    else
                    {
                        id = old.ClientId;
                    }

                    if (id.HasValue)
                    {
                        sb.Append(@$"update orders set RealClientId='{id}' where  Id ='{item.Id}';");
                        sb.Append(Environment.NewLine);

                        Console.WriteLine($"{count}处理完成,list有{list.Count}个");
                        count++;
                    }
                }

                Console.WriteLine($"需要修改得数据为{count}条");
            }
            System.IO.File.WriteAllText(@"E:\同步数据.txt", sb.ToString());
            Console.WriteLine("结束");
            Console.ReadKey();
        }
    }


    public class LogisticsClientCode
    {
        public Guid ClientId { get; set; }

        public Guid LogisticsId { get; set; }

        public string RealClientCode { get; set; }
    }
}
