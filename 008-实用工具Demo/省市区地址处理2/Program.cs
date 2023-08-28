using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace 省市区地址处理2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            //       .UseConnectionString(FreeSql.DataType.MySql, @"Data Source=192.168.1.27;port=3306;user id=root;password=123456;Initial Catalog=taihang_slsystem;convertzerodatetime=True;AutoEnlist=false;Charset=utf8;sslmode=none;")
            //       .Build();


            //var zones = fsql.Select<Zone>().ToList();

            //Excel文件所在的地址
            FileInfo file = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "运输区域分好版.xlsx");


            List<Area> areaList = new List<Area>();
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //指定需要读入的sheet名
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets["Sheet1"];

                var count = 3484;

                for (int i = 2; i <= count; i++)
                {
                    string code = excelWorksheet.Cells[i, 1].Value.ToString().Trim();
                    string adrress = excelWorksheet.Cells[i, 2].Value.ToString().Trim();

                    //if (code != zones[i - 2].Code)
                    //{
                    //    throw new Exception($"错误 i={i},code={code},zonesid={zones[i-2].Id}");
                    //}

                    Area p = new Area();
                    p.Code = code;

                    //if (adrress == "北京市北京市")
                    //{
                    //    var ssss = 0;
                    //}

                    if (code.Length >= 4)
                    {
                        var result = Split(adrress);
                        p.Sheng = result[0];
                        p.Shi = result[1];
                        p.Qu = result[2] + result[3];

                        if (p.Qu.Length == 0 && p.Shi.Length > 0) p.Qu = p.Shi;
                    }
                    else
                    {
                        p.Sheng = adrress;
                    }


                    p.FullName = adrress;

                    if (p.Code.Length == 2)
                    {
                        p.Type = 1;
                    }
                    else if (p.Code.Length == 4)
                    {
                        p.Type = 2;
                    }
                    else
                    {
                        p.Type = 3;
                    }

                    if (p.Code.StartsWith("4690") || p.Code.StartsWith("4290"))
                    {
                        p.Type = 2;

                        if (areaList.Any(a => a.Code == p.Code))
                        {
                            p.Type = 3;
                        }
                    }

                    areaList.Add(p);
                }
            }


            Console.WriteLine($"共有{areaList.Count}条数据");

            StringBuilder sb = new StringBuilder("insert into zones (Type,`Code`,`Name`,ParentCode,ParentName,FullName) values ");

            var shengList = areaList.Where(a => a.Type == 1).ToList();

            var shiList = areaList.Where(a => a.Type == 2).ToList();

            var quList = areaList.Where(a => a.Type == 3).ToList();

            int dataCount = 0;

            foreach (var p in shengList)
            {
                sb.Append($"(1,'{p.Code}','{p.Sheng}',null,null,'{p.FullName}'),");

                sb.Append(Environment.NewLine);

                dataCount++;

                var pShiList = shiList.Where(a => a.Code.Substring(0, 2) == p.Code).ToList();

                foreach (var s in pShiList)
                {
                    sb.Append($"(2,'{s.Code}','{s.Shi}','{p.Code}','{p.Sheng}','{s.FullName}'),");
                    sb.Append(Environment.NewLine);

                    dataCount++;

                    var pQuList = quList.Where(a => a.Code.Substring(0, 4) == s.Code || (a.Sheng + a.Shi) == s.FullName).ToList();

                    foreach (var q in pQuList)
                    {
                        sb.Append($"(3,'{q.Code}','{q.Qu}','{s.Code}','{s.Shi}','{q.FullName}'),");
                        sb.Append(Environment.NewLine);

                        dataCount++;
                    }
                }
            }

            System.IO.File.WriteAllText(@"F:\省市区.txt", sb.ToString());
            Console.WriteLine($"完成  {dataCount}");

            Console.ReadKey();
        }

        /// <summary>
        /// 地址拆分成省市区镇
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static List<string> Split(string address)
        {
            string province = "";

            string city = "";

            string district = "";

            string town = "";

            string regex = "(?<province>[^省]+省|.+自治区|[^澳门]+澳门|[^香港]+香港|[^市]+市)?(?<city>[^自治州]+自治州|[^特别行政区]+特别行政区|[^市]+市|.*?地区|.*?行政单位|.+盟|市辖区|[^县]+县)(?<county>[^县]+县|[^市]+市|[^镇]+镇|[^区]+区|[^乡]+乡|.+场|.+旗|.+海域|.+岛)?(?<address>.*)";

            string[] res = Regex.Split(address, regex);

            foreach (var item in res)
            {
                if (!string.IsNullOrWhiteSpace(item) && province == "")
                {
                    province = item;
                }
                else if (!string.IsNullOrWhiteSpace(item) && city == "")
                {
                    city = item;
                }
                else if (!string.IsNullOrWhiteSpace(item) && district == "")
                {
                    district = item;
                }
                else if (!string.IsNullOrWhiteSpace(item) && town == "")
                {
                    town = item;
                }
            }

            return new List<string> { province, city, district, town };
        }
    }

    public class Area
    {
        public string Code { get; set; }


        public int Type { get; set; }


        public string Sheng { get; set; }


        public string Shi { get; set; }


        public string Qu { get; set; }


        public string FullName { get; set; }
    }
}
