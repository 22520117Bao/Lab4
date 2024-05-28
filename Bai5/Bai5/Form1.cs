using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Bai5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private void btlogin_Click1(object sender, EventArgs e)
        {
            btlogin_ClickAsync();
        }

        private async Task btlogin_ClickAsync()
        {
            await AsyncConnectToApi();
        }

        private async Task AsyncConnectToApi()
        {
            string url = txturl.Text;
            string u_name = txtusername.Text;
            string pass = txtpass.Text;


            var content = new MultipartFormDataContent
             {
                { new StringContent(u_name), "username" },
                { new StringContent(pass), "password" }
             };


            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage res = await client.PostAsync(url, content);
                    string res_content = await res.Content.ReadAsStringAsync();

                    if(res.IsSuccessStatusCode)
                    {
                        var jres = JObject.Parse(res_content);
                        string tokentype = jres["token_type"].ToString();
                        string accesstoken = jres["access_token"].ToString();
                        rtbtoken.Text = $"Bearer {accesstoken}";
                        rtbtoken.Text += "\n\n\n\n" + "Đăng nhập thành công";  
                    }
                    else
                    {
                        var jres = JObject.Parse(res_content);
                        string detail = jres["detail"].ToString();
                        MessageBox.Show("Dang nhap that bai", "Error", MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi: { ex.Message}","Sai");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
