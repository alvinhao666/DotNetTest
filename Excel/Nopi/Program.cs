using NopiStandard;
using System;

namespace Nopi
{
    class Program
    {
        //解决 Npoi 导出Excel 下拉列表异常: String literals in formulas can't be bigger than 255 Chars ASCII
        // https://blog.csdn.net/u011958513/article/details/78624036?utm_source=blogxgwz9
        static void Main(string[] args)
        {
            int max = 500;
            string[] datas = new string[max];
            for (int i = 0; i < max; i++)
            {
                datas[i] = "" + i;
            }

            string filePath = @"F:\\test.xls";
            Class1.dropDownList(datas, filePath);
            Console.WriteLine("结束");
            Console.Read();
        }
    }
}
