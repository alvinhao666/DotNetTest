using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace 省市区地址处理
{
    class Program
    {
        //http://preview.www.mca.gov.cn/article/sj/xzqh/2020/2020/202101041104.html 数据源
        static void Main(string[] args)
        {
            //Excel文件所在的地址
            FileInfo file = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "省市区.xlsx");

            StringBuilder sb = new StringBuilder("insert into zones (Type,`Code`,`Name`,ParentCode,ParentName,FullName) values ");


            List<Area> areaList = new List<Area>();

            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //指定需要读入的sheet名
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets["Sheet1"];
                //比如读取第一行,第一列的值数据
                //object a = excelWorksheet.Cells[2, 1].Value;
                //读取第一行,第二列的值为
                //object b = excelWorksheet.Cells[36, 2].Value;
                //然后根据需要对a，b转为字符串，或者double，int等..


                var count = 3207;

                for (int i = 1; i <= count; i++)
                {
                    Console.WriteLine($"正在处理第{i}条数据");

                    string code = excelWorksheet.Cells[i, 1].Value.ToString().Trim();
                    string name = excelWorksheet.Cells[i, 2].Value.ToString().Trim();
                    //省
                    if (code.EndsWith("0000"))
                    {
                        Area p = new Area();
                        p.Code = code.Substring(0, 2);
                        p.Name = name;
                        areaList.Add(p);
                        sb.Append($"(1,'{p.Code}','{p.Name}',null,null,'{p.Name}'),");

                        sb.Append(Environment.NewLine);

                        if (i + 1 < count)
                        {
                            var codeNext = excelWorksheet.Cells[i + 1, 1].Value.ToString().Trim();

                            if (!codeNext.EndsWith("00"))
                            {
                                codeNext = p.Code + "01";
                                Area a2 = new Area();
                                a2.Code = codeNext;
                                a2.Name = name;
                                areaList.Add(a2);
                                sb.Append($"(2,'{a2.Code}','{a2.Name}','{p.Code}','{a2.Name}','{a2.Name}'),");
                                sb.Append(Environment.NewLine);
                            }
                        }
                    }
                    else if (code.EndsWith("00"))
                    {
                        var province = areaList.Where(a => a.Code.Length == 2 && a.Code == code.Substring(0, 2)).First();

                        var parentCode = province.Code;

                        var parentName = province.Name;

                        var fullName = province.Name + name;

                        Area a2 = new Area();
                        a2.Code = code.Substring(0, 4);
                        a2.Name = name;
                        areaList.Add(a2);

                        sb.Append($"(2,'{a2.Code}','{a2.Name}','{parentCode}','{parentName}','{fullName}'),");
                        sb.Append(Environment.NewLine);


                    }
                    else
                    {
                        var province = areaList.Where(a => a.Code.Length == 2 && a.Code == code.Substring(0, 2)).First();

                        var city = areaList.Where(a => a.Code.Length == 4 && a.Code == code.Substring(0, 4)).FirstOrDefault();

                        if (city == null) //直辖县级市
                        {
                            //city = areaList.Where(a => a.Code.Length == 4).Last();

                            Area a2 = new Area();
                            a2.Code = code.Substring(0, 4);
                            a2.Name = "直辖县级市";
                            areaList.Add(a2);

                            sb.Append($"(2,'{a2.Code}','{a2.Name}','{province.Code}','{province.Name}','{province.Name+a2.Name}'),");
                            sb.Append(Environment.NewLine);

                            Area a23 = new Area();
                            a23.Code = code;
                            a23.Name = name;
                            areaList.Add(a23);

                            sb.Append($"(3,'{a23.Code}','{a23.Name}','{a2.Code}','{a2.Name}','{province.Name+a2.Name + a23.Name}'),");

                            sb.Append(Environment.NewLine);

                            continue;
                        }


                        var parentCode = city.Code;

                        var parentName = city.Name;

                        var fullName = (province.Name != city.Name ? province.Name + city.Name : province.Name) + name;


                        Area a3 = new Area();
                        a3.Code = code;
                        a3.Name = name;
                        areaList.Add(a3);

                        sb.Append($"(3,'{a3.Code}','{a3.Name}','{parentCode}','{parentName}','{fullName}'),");

                        sb.Append(Environment.NewLine);
                    }
                }

                sb.Append($"(1,'71','台湾省',null,null,'台湾省')," + Environment.NewLine);
                sb.Append($"(2,'7101','台湾省','71','台湾省','台湾省')," + Environment.NewLine);
                sb.Append($"(3,'710101','台湾省','7101','台湾省','台湾省')," + Environment.NewLine);

                sb.Append($"(1,'81','香港',null,null,'香港')," + Environment.NewLine);
                sb.Append($"(2,'8101','香港','81','香港','香港')," + Environment.NewLine);
                sb.Append($"(3,'810101','香港','8101','香港','香港')," + Environment.NewLine);

                sb.Append($"(1,'82','澳门',null,null,'澳门')," + Environment.NewLine);
                sb.Append($"(2,'8201','澳门','82','澳门','澳门')," + Environment.NewLine);
                sb.Append($"(3,'820101','澳门','8201','澳门','澳门');");
            }

            System.IO.File.WriteAllText(@"E:\省市区.txt", sb.ToString());
            Console.WriteLine("完成");

            Console.ReadKey();
        }
    }


    public class Area
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
