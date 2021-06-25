using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region split

            Console.WriteLine("12312&nbsp;vfdf&nbsp;sdf&nbsp;sdfdcc".Split(new String[1] { "&nbsp;" }, 8, StringSplitOptions.None)[0]);

            Console.WriteLine("12312&nbsp;vfdf&nbsp;sdf&nbsp;sdfdcc".Split("1").FirstOrDefault()); //以开头字母分割 会有空格

            var strs = "192.168.1.2".Split(',');
            #endregion

            #region 过滤html标签
            string strhtml = NoHTML("</font>,&nbsp;<font face=\"Arial\"><span style=\"font - size: 14px; line - height: 21.59375px; \">,  满清康熙鼎盛之际，自十三岁入宫当宫女的兆佳沉香（");
            #endregion

            #region 地址拆分

            string address = "江苏省镇江市京口区梦溪嘉苑";

            string province = "";

            string city = "";

            string district = "";

            string regex = "(?<province>[^省]+省|[^自治区]+自治区|.+市)(?<city>[^自治州]+自治州|.+区划|[^市]+市|[^盟]+盟|[^地区]+地区)?(?<county>[^市]+市|[^县]+县|[^旗]+旗|.+区)?(?<town>[^区]+区|.+镇)?(?<village>.*)";


            foreach (Match match in Regex.Matches(address, regex))
            {
                province = match.Groups[1].Value;
                city = match.Groups[2].Value;
                district = match.Groups[3].Value;
            }
            #endregion

            //D4就是转化含有4位整数位的字符串。比如 1.ToString("D4") = "0001"

            string sdf = "1235_24234_1235_jssdf";

            Console.WriteLine(sdf.Replace("1235_", ""));//替换所有

            var i = sdf.IndexOf("1235_");
            var s = sdf.Remove(i, "1235_".Length);//替换第一个
            Console.WriteLine(s);

            var index = 1;

            Console.WriteLine(index.ToString("D3"));


            string strssd = "7,3";

            strssd = FormatDataTagsForOldApp(strssd);

            string ssss = null;

            Console.WriteLine(ssss + "123123"); //123123


            Console.WriteLine(string.Format("{0:D8}", 123123));

            Console.WriteLine(123123.ToString().PadLeft(8, '0'));

            string testValue = "123";

            TestRef(ref testValue);


            Console.WriteLine(testValue);

            Console.ReadKey();
        }


        public static void TestRef(ref string value)
        {
            value = "xxxxx";
        }

        /// <summary>
        /// 处理数据标签
        /// </summary>
        /// <param name="expectStr"></param>
        /// <returns></returns>
        private static string FormatDataTagsForOldApp(string expectStr)
        {
            if (string.IsNullOrWhiteSpace(expectStr)) return "";

            var array = expectStr.Split(',').ToList();

            if (array.Contains("7")) array.Remove("7");

            if (array.Contains("8")) array.Remove("8");

            if (array.Count == 0) return "";

            return string.Join(",", array);
        }

        public static string NoHTML(string Htmlstring)  //替换HTML标记
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<img[^>]*>;", "", RegexOptions.IgnoreCase);
            Htmlstring=Htmlstring.Replace("<", "");
            Htmlstring=Htmlstring.Replace(">", "");
            Htmlstring=Htmlstring.Replace("\r\n", "");
            return Htmlstring;
        }
    }
}
