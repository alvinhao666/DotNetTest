using AngleSharp.Html.Parser;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace 爬取电影
{
    class Program
    {
        private static HtmlParser htmlParser = new HtmlParser();

        private static ConcurrentDictionary<string, MovieInfo> _cdMovieInfo = new ConcurrentDictionary<string, MovieInfo>();

        static void Main(string[] args)
        {
            AddToHotMovieList();
            Console.ReadKey();
        }




        private static void AddToHotMovieList()
        {
            //此操作不阻塞当前其他操作，所以使用Task
            // _cdMovieInfo 为线程安全字典，存储了当期所有的电影数据
            Task.Factory.StartNew(() =>
            {
                try
                {
                    //通过URL获取HTML
                    var htmlDoc = HTTPHelper.GetHTMLByURL("http://www.dy2018.com/");
                    //HTML 解析成 IDocument
                    var dom = htmlParser.ParseDocument(htmlDoc);
                    //从dom中提取所有class='co_content222'的div标签
                    //QuerySelectorAll方法接受 选择器语法
                    var lstDivInfo = dom.QuerySelectorAll("div.co_content222");
                    if (lstDivInfo != null)
                    {
                        //前三个DIV为新电影
                        foreach (var divInfo in lstDivInfo.Take(3))
                        {
                            //获取div中所有的a标签且a标签中含有"/i/"的
                            //Contains("/i/") 条件的过滤是因为在测试中发现这一块div中的a标签有可能是广告链接
                            divInfo.QuerySelectorAll("a").Where(a =>
                            a.GetAttribute("href").Contains("/i/"))
                            .ToList().ForEach(
                            a =>
                            {
            //拼接成完整链接
            var onlineURL = "http://www.dy2018.com" + a.GetAttribute("href");
            //看一下是否已经存在于现有数据中
            if (!_cdMovieInfo.ContainsKey(onlineURL))
                                {
                //获取电影的详细信息
                MovieInfo movieInfo = FillMovieInfoFormWeb(a, onlineURL);
                //下载链接不为空才添加到现有数据
                if (movieInfo.XunLeiDownLoadURLList != null
                && movieInfo.XunLeiDownLoadURLList.Count != 0)
                                    {
                                        _cdMovieInfo.TryAdd
                    (movieInfo.Dy2018OnlineUrl, movieInfo);
                                    }
                                }
                            });
                        }
                    }

                }
                catch (Exception ex)
                {

                }
            });
        }


        private static  MovieInfo FillMovieInfoFormWeb(AngleSharp.Dom.IElement a,
string onlineURL)
        {
            var movieHTML = HTTPHelper.GetHTMLByURL(onlineURL);
            var movieDoc = htmlParser.ParseDocument(movieHTML);
            //http://www.dy2018.com/i/97462.html 分析过程见上，不再赘述
            //电影的详细介绍 在id为Zoom的标签中
            var zoom = movieDoc.GetElementById("Zoom");
            //下载链接在 bgcolor='#fdfddf'的td中，有可能有多个链接
            var lstDownLoadURL = movieDoc.QuerySelectorAll("[bgcolor='#fdfddf']");
            //发布时间 在class='updatetime'的span标签中
            var updatetime = movieDoc.QuerySelector("span.updatetime");
            var pubDate = DateTime.Now;
            if (updatetime != null && !string.IsNullOrEmpty(updatetime.InnerHtml))
            {
                //内容带有“发布时间：”字样，
                //replace成""之后再去转换，转换失败不影响流程
                DateTime.TryParse(updatetime.InnerHtml.Replace("发布时间：",
                ""), out pubDate);
            }


            var movieInfo = new MovieInfo()
            {
                //InnerHtml中可能还包含font标签，做多一个Replace
                MovieName = a.InnerHtml.Replace("<font color=\"#0c9000\">", "")
             .Replace("<font color=\" #0c9000\">", "")
             .Replace("</font>", ""),
                Dy2018OnlineUrl = onlineURL,
                MovieIntro = zoom != null ? WebUtility.HtmlEncode(zoom.InnerHtml) : "暂无介绍...",
                //可能没有简介，虽然好像不怎么可能
                XunLeiDownLoadURLList = lstDownLoadURL != null ?
             lstDownLoadURL.Select(d => d.FirstElementChild.InnerHtml).ToList() : null,
                //可能没有下载链接
                PubDate = pubDate,
            };
            return movieInfo;
        }
    }
}
