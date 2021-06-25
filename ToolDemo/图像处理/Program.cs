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
            var base64String = await GetBase64String("https://sinostoragedev.oss-cn-hangzhou.aliyuncs.com/upload/24EC15DA-32A6-4765-879B-1A49F9C56488.png");

            using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(Convert.FromBase64String(base64String)))
            {
                Console.WriteLine(image.Width + "  " + image.Height);
                Console.WriteLine((double)image.Width / image.Height);
                Console.WriteLine((double)750 / 1334);
                Console.WriteLine(image.Width / image.Height != 750 / 1334);
                Console.WriteLine((image.Width / image.Height) != (750 / 1334));
                if (image.Width / image.Height != 750 / 1334) throw new Exception("尺寸一有误，请重新选择图片");
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
