using Sino.TMSystem.DomainModel.Order;
using SqlSugar;
using System;

namespace SqlSugarDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //创建数据库对象
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                //ConnectionString = "Data Source=192.168.1.27;port=3306;user id=root;password=123456;Initial Catalog=tmsystem;convertzerodatetime=True;Charset=utf8;",
                
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            });

            var orders = db.Queryable<Order>().AS("orders").ToList();

            //db.Fastest<Order>().BulkCopy(GetList());

            Console.WriteLine("完成");

            Console.ReadKey();
        }
    }
}
