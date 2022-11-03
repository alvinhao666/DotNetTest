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

                    Area p = new Area();
                    p.Code = code;

                    //if (adrress == "湖北省仙桃市仙桃市")
                    //{
                    //    var ssss = 0;
                    //}

                    if (code.Length >= 4)
                    {
                        var result = Split(adrress);
                        p.Sheng = result[0];
                        p.Shi = result[1];
                        p.Qu = result[2];

                        if (p.Shi == "" && p.Qu.Length > 0) p.Shi = p.Qu;

                        if (p.Qu.Length == 0 && result[3].Length>0) p.Qu = result[3];
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

                    if (p.Code.StartsWith("4690") ||p.Code.StartsWith ("4290"))
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

            var shengList = areaList.Where(a => a.Type==1).ToList();

            var shiList = areaList.Where(a => a.Type==2).ToList();

            var quList = areaList.Where(a => a.Type==3).ToList();

            int dataCount = 0;

            foreach (var p in shengList)
            {
                sb.Append($"(1,'{p.Code}','{p.Sheng}',null,null,'{p.FullName}'),");

                sb.Append(Environment.NewLine);

                dataCount++;

                var pShiList = shiList.Where(a => a.Code.Substring(0, 2) == p.Code ).ToList();

                foreach (var s in pShiList)
                {
                    sb.Append($"(2,'{s.Code}','{s.Shi}','{p.Code}','{p.Sheng}','{s.FullName}'),");
                    sb.Append(Environment.NewLine);

                    dataCount++;

                    var pQuList = quList.Where(a => a.Code.Substring(0, 4) == s.Code || (a.Sheng + a.Shi) == s.FullName).ToList();

                    foreach(var q in pQuList)
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

            string regex = "(?<province>[^省]+省|[^自治区]+自治区|.+市)(?<city>[^自治州]+自治州|.+区划|[^市]+市|[^盟]+盟|[^地区]+地区)?(?<county>[^市]+市|[^县]+县|[^旗]+旗|.+区)?(?<town>[^区]+区|.+镇)?(?<village>.*)";

            foreach (Match match in Regex.Matches(address, regex))
            {
                province = match.Groups[1].Value;
                city = match.Groups[2].Value;
                district = match.Groups[3].Value;
                town = match.Groups[4].Value;
            }

            IsSymmetry2(province, ref province, ref city);

            return new List<string>() { province, city, district, town };
        }

        static void IsSymmetry2(string str, ref string province, ref string city)
        {
            if (string.IsNullOrEmpty(str) || str.Length == 1)
            {
                return;
            }
            var halfLength = str.Length / 2;
            var str1 = str.Substring(0, halfLength);
            var str2 = new String(str.Substring(str.Length % 2 == 0 ? halfLength : halfLength + 1, halfLength).ToArray());

            if (str1.Equals(str2))
            {
                province = str1;
                city = str1;
            }
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
