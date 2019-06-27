using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string identity = "41232719750212051X";
            Console.WriteLine(Convert.ToInt32(null));
            try
            {
                HttpClient httpClient = new HttpClient();
                string url = "https://qq.ip138.com/idsearch/index.asp?action=idcard&userid=identity";

                url = url.Replace("identity", identity);
                var t = httpClient.GetByteArrayAsync(url).Result;

                var ret = Encoding.GetEncoding("UTF-8").GetString(t);
                var firstStr = "地</p></td><td><p>";
               var firstIndex = ret.IndexOf(firstStr);
                if (firstIndex < 0)
                {
                    await FindByJuHeApi(identity);
                }
                else
                {
                    var str = ret.Substring(firstIndex + firstStr.Length, 80);
                    var lastStr = "<br/>";
                    var lastIndex = str.IndexOf(lastStr);
                    if (lastIndex < 0)
                    {
                        await FindByJuHeApi(identity);
                    }
                    else
                    {
                        var shengshiqu = str.Substring(0, lastIndex);
                        var list = shengshiqu.Split(' ').ToList();
                        if (list != null && list.Count >= 2)
                        {
                            //var area = new AreasInfo
                            //{
                            //    AreaId = identity.Substring(0, 6),
                            //    Province = list[0],
                            //    City = list[1],
                            //    Area = list.Count == 2 ? "市辖区" : list[2]
                            //};
                            //await AddNewIdentityArea(area);
                            //return area;
                        }
                        await FindByJuHeApi(identity);
                    }
                }

            }
            catch (Exception ex)
            {
                //_logger.Error(new LogInfo() { Method = "FindAreaOnInternet", Argument = ex, Description = "发证地网络获取异常" });
               await FindByJuHeApi(identity);
            }

            Console.ReadKey();

        }


        private static async Task FindByJuHeApi(string identity)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string url = "http://apis.juhe.cn/idcard/index?key=10c437bcaacd6f599c83773d18de3a3f&cardno=" + $"{identity}";
                var result = await httpClient.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject(result) as JObject;

                string errorCode1 = data["error_code"].ToString();
                var list = GetAddress("内蒙古自治区伊克昭盟达拉特旗");
                if (errorCode1 == "0")
                {
                    string address = data["result"]["area"].ToString();
            
                    //if (list != null && list.Count >= 2)
                    //{
                    //    var area = new AreasInfo
                    //    {
                    //        AreaId = identity.Substring(0, 6),
                    //        Province = list[0],
                    //        City = list[1],
                    //        Area = list[2]
                    //    };
                    //    await AddNewIdentityArea(area);
                    //    return area;
                    //}
                }
                //return null;
            }
            catch (Exception ex)
            {
                //_logger.Error(new LogInfo() { Method = "FindByJuHeApi", Argument = ex, Description = "发证地网络获取异常" });
                //return null;
            }

        }


        public static List<string> GetAddress(string address)
        {
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

            return new List<string>() { province, city, district };
        }
    }
}


/// <summary>
/// 身份证发证地(聚合数据 每天免费100次)
/// </summary>
/// <param name="identity"></param>
/// <returns></returns>







///// <summary>
///// 身份证发证地网络查找
///// </summary>
///// <param name="identity"></param>
///// <returns></returns>
//public async Task<AreasInfo> FindAreaOnInternet(string identity)
//{
//    try
//    {
//        HttpClient httpClient = new HttpClient();
//        string url = "https://qq.ip138.com/idsearch/index.asp?action=idcard&userid=identity";
//        url = url.Replace("identity", identity);
//        var t = httpClient.GetByteArrayAsync(url).Result;
//        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
//        var ret = System.Text.Encoding.GetEncoding("UTF-8").GetString(t);
//        var firstStr = "地</p></td><td><p>";
//        var firstIndex = ret.IndexOf(firstStr);
//        if (firstIndex < 0)
//        {

//        }
//        else
//        {
//            var str = ret.Substring(firstIndex + firstStr.Length, 80);
//            var lastStr = "<br/>";
//            var lastIndex = str.IndexOf(lastStr);
//            if (lastIndex < 0)
//            {

//            }
//            else
//            {
//                var shengshiqu = str.Substring(0, lastIndex);
//                var list = shengshiqu.Split(' ').ToList();
//                if (list != null && list.Count >= 2)
//                {
//                    var area = new AreasInfo
//                    {
//                        AreaId = identity.Substring(0, 6),
//                        Province = list[0],
//                        City = list[1],
//                        Area = list.Count == 2 ? "市辖区" : list[2]
//                    };
//                    await AddNewIdentityArea(area);
//                    return area;
//                }
//                return null;
//            }
//        }

//    }
//    catch (Exception ex)
//    {
//        _logger.Error(new LogInfo() { Method = "FindAreaOnInternet", Argument = ex, Description = "发证地网络获取异常" });
//        return null;
//    }

//}

///// <summary>
///// 身份证发证地(聚合数据 每天免费100次)
///// </summary>
///// <param name="identity"></param>
///// <returns></returns>
//private async Task<AreasInfo> FindByJuHeApi(string identity)
//{
//    try
//    {
//        HttpClient httpClient = new HttpClient();
//        string url = "http://apis.juhe.cn/idcard/index?key=10c437bcaacd6f599c83773d18de3a3f&cardno=" + $"{identity}";
//        var result = await httpClient.GetStringAsync(url);
//        var data = JsonConvert.DeserializeObject(result) as JObject;

//        string errorCode1 = data["error_code"].ToString();
//        if (errorCode1 == "0")
//        {
//            string area = data["result"]["area"].ToString();
//        }
//        return null;
//    }
//    catch (Exception ex)
//    {
//        _logger.Error(new LogInfo() { Method = "FindByJuHeApi", Argument = ex, Description = "发证地网络获取异常" });
//        return null;
//    }

//}
