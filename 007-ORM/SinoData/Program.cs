
using Dapper;
using MySqlConnector;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace SinoData
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=192.168.1.27;port=3306;user id=root;password=123456;Initial Catalog=tmsystem;convertzerodatetime=True;Charset=utf8;";




            StringBuilder sb = new StringBuilder();
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                #region 1
                //string sql = @"select * from orders where  ClientId = 'e4588545-db46-4510-88bd-c82114765738' and isdeleted=0 and RealClientCode is not null
                //    and RealclientCode != '' and realClient is not null and RealClient!=''";

                //var orders = connection.Query<Order>(sql).AsList();

                //Console.WriteLine($"临时客户单位共{orders.Count}条");

                //List<LogisticsClientCode> list = new List<LogisticsClientCode>();
                //int count = 1;
                //foreach (var item in orders)
                //{
                //    var old = list.Where(a => a.LogisticsId == item.LogisticsId.Value && a.RealClientCode == item.RealClientCode).FirstOrDefault();

                //    Guid? id = null;

                //    if (old == null)
                //    {
                //        string sql2 = $"SELECT Id from EnterpriseLogisticsRelations  WHERE IsDeleted=0 and LogisticsCompanyId='{item.LogisticsId}' and EnterpriseCode='{item.RealClientCode}'";

                //        id = connection.QueryFirstOrDefault<Guid?>(sql2);

                //        if (id.HasValue)
                //        {
                //            list.Add(new LogisticsClientCode { LogisticsId = item.LogisticsId.Value, RealClientCode = item.RealClientCode, ClientId = id.Value });
                //        }
                //    }
                //    else
                //    {
                //        id = old.ClientId;
                //    }

                //    if (id.HasValue)
                //    {
                //        sb.Append(@$"update orders set RealClientId='{id}' where  Id ='{item.Id}';");
                //        sb.Append(Environment.NewLine);

                //        Console.WriteLine($"{count}处理完成,list有{list.Count}个");
                //        count++;
                //    }
                //}

                //Console.WriteLine($"需要修改得数据为{count}条");
                #endregion

                #region 托运人会员一级编码
                Console.WriteLine("开始处理托运人会员一级编码");
                string sql = "select * from enterpriselogisticsrelations ";
                var enterprises = connection.Query<EnterpriseLogisticsRelations>(sql).AsList();

                Console.WriteLine($"共{enterprises.Count}条数据");

                var enterprisesGroups = enterprises.GroupBy(a => a.CreationTime.Date).OrderBy(a => a.Key);

                var preFix = "TYR";

                foreach (var items in enterprisesGroups)
                {
                    var orderByItems = items.OrderBy(a => a.CreationTime);

                    int index = 1;
                    foreach (var a in orderByItems)
                    {
                        sb.Append($"update enterpriselogisticsrelations set LevelOneMemberCode ='{preFix}{a.CreationTime.ToString("yyMMdd")}{string.Format("{0:D4}", index)}' where id = '{a.Id}';");
                        sb.Append(Environment.NewLine);
                        index++;
                    }
                }

                #endregion

            }
            System.IO.File.WriteAllText(@"E:\同步数据正式服.txt", sb.ToString());
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
