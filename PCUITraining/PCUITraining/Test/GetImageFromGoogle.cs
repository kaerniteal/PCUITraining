using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace PCUITraining.Test
{
    public class GetImageFromGoogle
    {
        private string result { get; set; }

        public List<string> ImageUrlList { get; set; }


        public GetImageFromGoogle()
        {
            this.result = string.Empty;
            this.ImageUrlList = new List<string>();
        }


        public List<Bitmap> Exec(string text)
        {
            var wc = new WebClient();

            try
            {
                var urlpre = @"https://www.google.com/search?q=ポケモン図鑑+";
                var urlsa = @"&tbm=isch&num=10&safe=high&gbv=1";

                var url = urlpre + text + urlsa;

                wc.Encoding = Encoding.UTF8;
                this.result = wc.DownloadString(url);

                this.HtmlAnalize();

                return this.ToImageList(wc);

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new List<Bitmap>();
        }


        private void HtmlAnalize()
        {
            if (string.Empty.Equals(this.result))
            {
                return;
            }

            var replaced = this.result.Replace(">", ">\n");

            // 一行ずつ読み込む
            using (var rs = new StringReader(replaced))
            {
                // 末端まで繰り返す
                while (-1 < rs.Peek())
                {
                    //一行読み込んで表示する
                    var line = rs.ReadLine();
                    this.LineAnalize(line);
                }

                rs.Close();
            }
        }

        private void LineAnalize(string line)
        {
            var httpIndex = line.IndexOf("https://encrypted-tbn0.gstatic.com/images");
            if (httpIndex < 0)
            {
                return;
            }

            var httpText = line.Substring(httpIndex);
            var endIndex = httpText.IndexOf("\"");
            if (endIndex < 0)
            {
                return;
            }

            this.ImageUrlList.Add(httpText.Substring(0, endIndex));
        }


        private List<Bitmap> ToImageList(WebClient wc)
        {
            var imageList = new List<Bitmap>();

            foreach (var url in this.ImageUrlList)
            {
                using (var stream = wc.OpenRead(url))
                {
                    var bitmap = new Bitmap(stream);
                    imageList.Add(bitmap);
                    stream.Close();
                }
            }

            return imageList;
        }
    }
}
