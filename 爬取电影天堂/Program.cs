using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Polly;
using Snowflake.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 爬取电影天堂
{
    public class Program
    {
        private static HtmlParser htmlParser = new HtmlParser();

        private static int num = 1;

        const string _connectionString = "Data Source=119.27.173.241;Database=haohaoPlay;User ID=root;Password=Mimashi@7758258;CharSet=utf8;port=3306;sslmode=none";

        private static IdWorker _worker = new IdWorker(1,1);

        static async Task Main(string[] args)
        {
            try
            {

                IServiceCollection services = new ServiceCollection();

                services.AddHttpClient("dy", a => { a.Timeout = TimeSpan.FromMinutes(3); })
                        .AddPolicyHandler(Policy<HttpResponseMessage>
                        .Handle<SocketException>()
                        .Or<IOException>()
                        .Or<HttpRequestException>()
                        .WaitAndRetryForeverAsync(t => TimeSpan.FromSeconds(5), (ex, ts) =>
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("重试" + ts);
                        }))
                        .ConfigureHttpMessageHandlerBuilder((c) =>
                        new HttpClientHandler()
                        {
                            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                        });
                //.AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromMinutes(3)))


                //注入
                services.AddTransient<IHttpHelper, HttpHelper>();

                #region Autofac

                AutofacContainer.Build(services);
                var httpHelper = AutofacContainer.Resolve<IHttpHelper>();

                #endregion

                #region .net core 自带
                ////构建容器
                //IServiceProvider serviceProvider = services.BuildServiceProvider();
                ////解析
                //var memcachedClient = serviceProvider.GetService<IMemcachedClient>();
                #endregion



                for (int i = 0; i < 21; i++)
                {
                    //拼接成完整链接
                    var url = "https://www.dy2018.com/"+i+"/";

                    var htmlDoc = await httpHelper.GetHTMLByURL(url);
                    if (string.IsNullOrWhiteSpace(htmlDoc)) continue;
                    var dom = htmlParser.ParseDocument(htmlDoc);

                    var pContent = dom.QuerySelectorAll("div.x > p");
                    int pageNum = 0;
                    if (pContent != null && pContent.Length > 0)
                    {
                        var content = pContent.FirstOrDefault().InnerHtml.Split("&nbsp;").FirstOrDefault().Split("/")[1];
                        pageNum = Convert.ToInt32(content);
                    }

                    //获取电影
                    await GetMovie(httpHelper,url, dom);

                    if (pageNum > 0) 
                    {
                        for (int page = 2; page < pageNum; page++) 
                        {
                            var url2 = "https://www.dy2018.com/" + i + $"/index_{page}.html";

                            //获取电影
                            await GetMovie(httpHelper, url2);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("异常："+ex.ToString());
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("结束！！！！");
                Console.ReadKey();
            }
        }


        private static async Task GetMovie(IHttpHelper http, string url, IHtmlDocument dom = null)
        {
            if (dom == null) 
            {
                var htmlDoc = await http.GetHTMLByURL(url);
                if (string.IsNullOrWhiteSpace(htmlDoc)) return;
                dom = htmlParser.ParseDocument(htmlDoc);
            } 
            var tables = dom.QuerySelectorAll("table.tbspan");

            if (tables != null && tables.Count() > 0)
            {
                foreach (var tb in tables)
                {
                    var href = tb.QuerySelectorAll("a").Where(a => a.GetAttribute("href").Contains(".html")).FirstOrDefault();
                    //拼接成完整链接
                    var onlineURL = "http://www.dy2018.com" + href.GetAttribute("href");

                   
                    Movie movieInfo = await FillMovieInfoFormWeb(http, onlineURL);
                    if (movieInfo == null) continue;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{num++}电影名称：" + movieInfo.Name);
                    Console.WriteLine("下载地址：" + movieInfo.DownloadUrlFirst);
                    var success = await InsertDB(movieInfo);
                    Console.ForegroundColor = success ? ConsoleColor.Yellow : ConsoleColor.Blue;
                    Console.WriteLine(success ? "成功" : "失败");
                }
            }
        }


        private static async Task<Movie> FillMovieInfoFormWeb(IHttpHelper http, string onlineURL)
        {
            var movieHTML = await http.GetHTMLByURL(onlineURL);
            if (string.IsNullOrWhiteSpace(movieHTML)) return null;
            var movieDoc = htmlParser.ParseDocument(movieHTML);
            //电影的详细介绍 在id为Zoom的标签中
            var zoom = movieDoc.GetElementById("Zoom");
            //下载链接在 bgcolor='#fdfddf'的td中，有可能有多个链接
            var lstDownLoadURL = movieDoc.QuerySelectorAll("td > a").Select(a=>a.InnerHtml);
            //发布时间 在class='updatetime'的span标签中
            var updatetime = movieDoc.QuerySelector("span.updatetime");
            var pubDate = DateTime.Now;
            if (updatetime != null && !string.IsNullOrEmpty(updatetime.InnerHtml))
            {
                //replace成""之后再去转换，转换失败不影响流程
                DateTime.TryParse(updatetime.InnerHtml.Replace("发布时间：",""), out pubDate);
            }
            var movieInfo = new Movie()
            {
                //InnerHtml中可能还包含font标签，做多一个Replace
                Name = movieDoc.QuerySelectorAll("div.title_all > h1").FirstOrDefault().InnerHtml,
                //Dy2018OnlineUrl = onlineURL,
                //MovieIntro = zoom != null ? WebUtility.HtmlEncode(zoom.InnerHtml) : "暂无介绍...",
                ////可能没有简介，虽然好像不怎么可能
                // XunLeiDownLoadURLList = lstDownLoadURL?.ToList(),
                DownloadUrlFirst = lstDownLoadURL?.FirstOrDefault(),
                ////可能没有下载链接
                ReleaseDate = pubDate,
            };
            return movieInfo;
        }

        /// <summary>
        /// 插入电影数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private static async Task<bool> InsertDB(Movie info)
        {
            info.ID = _worker.NextId();
            List<string> matchValue = new List<string>();
            foreach (Match m in Regex.Matches(info.Name, "(?<=《)[^》]+(?=》)"))
            {
                matchValue.Add(m.Value);
            }
            if (matchValue.Count > 0) 
            {
                info.Name = matchValue.FirstOrDefault();
            }
            info.CreatorID = -1;
            info.CreateTime = DateTime.Now;
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();

                var sql = @" INSERT INTO Movie (ID,Name)  
                                        VALUES (@ID,@Name)"; 

                var res = await dbConnection.ExecuteAsync(sql, info);

                return res > 0;
            }
        }
    }
}
