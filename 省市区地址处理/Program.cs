using OfficeOpenXml;
using System;
using System.IO;

namespace 省市区地址处理
{
    class Program
    {
        static void Main(string[] args)
        {
            //Excel文件所在的地址
            FileInfo file = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "省市区.xlsx");
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                //指定需要读入的sheet名
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets["Sheet1"];
                //比如读取第一行,第一列的值数据
                object a = excelWorksheet.Cells[1, 1].Value;
                //读取第一行,第二列的值为
                object b = excelWorksheet.Cells[1, 2].Value;
                //然后根据需要对a，b转为字符串，或者double，int等..

            }


            Console.WriteLine("完成");

            Console.ReadKey();
        }
    }
}
