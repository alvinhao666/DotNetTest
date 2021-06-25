using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace 图像处理
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var base64String = await GetBase64String("https://sinostoragedev.oss-cn-hangzhou.aliyuncs.com/upload/E7F0615EE45A9C71B640D00AB6261DF7.png");

            using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(Convert.FromBase64String(base64String)))
            {
                var width = image.Width;
                var height = image.Height;
            }


            Console.ReadKey();
        }

        private static async Task<string> GetBase64String(string imageUrl)
        {
            var webreq = WebRequest.Create(imageUrl);
            var webres = await webreq.GetResponseAsync();
            using (var stream = webres.GetResponseStream())
            {
                using (var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    byte[] fileBytes = new byte[ms.Length];
                    ms.Read(fileBytes, 0, (int)ms.Length);
                    var image = Convert.ToBase64String(fileBytes);
                    return image;
                }
            }
        }
    }
}
