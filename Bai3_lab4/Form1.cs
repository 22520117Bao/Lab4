using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using Microsoft.Web.WebView2;
using System.Linq;
using System.Net;
using System.Security.Policy;


namespace Bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await webView2.EnsureCoreWebView2Async(null);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            webView2.Source = new Uri(url);
        }

        private async void btndownloadfiles_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            string urlsave = txtUrl.Text.Replace("https://","").Replace("/","")+".html";
            SaveHtmlToFile(url, urlsave);
        }

        private async void btndownloadresources_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            if (url != null || url != string.Empty)
            {
                AllDownloadImage(url);
            }
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            string htmlContent = await DownloadHtmlContentAsync(url);
            Form2 f2 = new Form2(htmlContent);
            f2.Show();
            
        }
        private async Task<string> DownloadHtmlContentAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string htmlContent = await response.Content.ReadAsStringAsync();
                return htmlContent;
            }
        }

        private void SaveHtmlToFile(string url, string urlsave)
        {
            WebClient client = new WebClient();
            Stream res = client.OpenRead(url);
            client.DownloadFile(url, urlsave);
            MessageBox.Show($"HTML content saved to {urlsave}");
        }

       

        private async void AllDownloadImage(string url)
        {
            var html = new HtmlWeb();
            var document = html.Load(url);

            var imageNodes = document.DocumentNode.SelectNodes("//img");
            if (imageNodes != null)
            {
                foreach (var img in imageNodes)
                {
                    string src = img.GetAttributeValue("src", null);
                    if (!string.IsNullOrEmpty(src))
                    {
                        if (!Uri.IsWellFormedUriString(src, UriKind.Absolute))
                        {
                            Uri baseUri = new Uri(url);
                            Uri absoluteUri = new Uri(baseUri, src);
                            src = absoluteUri.ToString();
                        }
                        DownloadImage(src);
                    }
                }
            }
        }

        private void DownloadImage(string url) // lưu ảnh về máy
        {
            WebClient client = new WebClient();
            Uri uri = new Uri(url);
            string fileName = Path.GetFileName(uri.LocalPath);
            client.DownloadFile(uri, fileName);
        }

    }
}
