using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace DateTimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DateTime,正则匹配日期
            DateTime dt = DateTime.Parse("2019.1.1 10:10:11");
            //本月第一天时间      
            int year = dt.Date.Year;
            int month = dt.Date.Month;
            int dayCount = DateTime.DaysInMonth(year, month);
            var a = new DateTime(2019, 6, 23, 10, 20, 20);
            var b = DateTime.Now.Date;
            var c = (a - b).Days;

            string sdd = JsonConvert.SerializeObject(new { date = DateTime.Now });

            var dd = JsonConvert.DeserializeObject<Temp>(sdd);
            var ds = Convert.ToDateTime(dd.date);


            DateTime vv = Convert.ToDateTime("2019-01-01T23:33:23");

            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            string releaseDate;

            foreach (Match match in Regex.Matches("2018-4-20", @"\d{4}-\d{1,2}-\d{1,2}"))
            {
                releaseDate = match.Groups[0].Value;
            }

            foreach (Match match in Regex.Matches("2323ddsdf2018-4-20xxx", @"((?<!\d)((\d{2,4}(\.|年|\/|\-))((((0?[13578]|1[02])(\.|月|\/|\-))((3[01])|([12][0-9])|(0?[1-9])))|(0?2(\.|月|\/|\-)((2[0-8])|(1[0-9])|(0?[1-9])))|(((0?[469]|11)(\.|月|\/|\-))((30)|([12][0-9])|(0?[1-9]))))|((([0-9]{2})((0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))(\.|年|\/|\-))0?2(\.|月|\/|\-)29))日?(?!\d))"))
            {
                releaseDate = match.Groups[0].Value;
            }
            #endregion

            #region 时间戳

            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            Console.WriteLine(Convert.ToInt64(ts.TotalSeconds).GetType() == typeof(long));
            #endregion

            #region string转datetime
            var date = DateTime.Parse("2019.07.13 15:56");
            #endregion


            Console.ReadKey();
        }
    }

    public class Temp
    {
        public string date { get; set; }
    }
}
