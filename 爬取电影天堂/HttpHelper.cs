using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 爬取电影天堂
{
    public class HttpHelper
    {


        public static  async Task<string> GetHTMLByURL(HttpClient http,string url)
        {
            try
            {
                var response = await http.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var t = response.Content.ReadAsByteArrayAsync().Result;
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    var ret = System.Text.Encoding.GetEncoding("GB2312").GetString(t);
                    return ret;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return string.Empty;
            }
        }
    }
}
