using System;
using System.Collections.Generic;
using System.Text;

namespace 爬取电影天堂
{
    public class Movie
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string Dy2018OnlineUrl { get; set; }

        public string MovieIntro { get; set; }


        public List<string> XunLeiDownLoadURLList { get; set; }


        public DateTime PubDate { get; set; }
    }
}
