using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace 爬取电影天堂
{
    public interface IHttpHelper
    {
        Task<string> GetHTMLByURL(string url);
    }
}
