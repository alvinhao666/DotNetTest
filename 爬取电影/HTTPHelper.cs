using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace 爬取电影
{
    public class HTTPHelper
    {
        public static HttpClient Client { get; } = new HttpClient();

        public static string GetHTMLByURL(string url)
        {
            try
            {
                var t = Client.GetByteArrayAsync(url).Result;
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var ret = System.Text.Encoding.GetEncoding("GB2312").GetString(t);
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return string.Empty;
            }
        }

    }
}
