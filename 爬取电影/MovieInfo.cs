using System;
using System.Collections.Generic;
using System.Text;

namespace 爬取电影
{
    public class MovieInfo
    {
        public string MovieName { get; set; }

        public string Dy2018OnlineUrl { get; set; }

        public string MovieIntro { get; set; }


        public List<string> XunLeiDownLoadURLList { get; set; }


        public DateTime PubDate { get; set; }
    }
}
