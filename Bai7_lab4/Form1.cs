using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace Bai7_lab4
{
  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            btlogin_ClickAsync();
        }

        private async Task btlogin_ClickAsync()
        {
            await ConnectToApiAsync();
        }

        private async Task ConnectToApiAsync()
        {
            string url = "https://nt106.uitiot.vn/auth/token";
            string u_name = txtuser.Text;
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
                    if (res.IsSuccessStatusCode)
                    {
                        var jres = JObject.Parse(res_content);
                        User.LoginUser = u_name;
                        Tokens.TokenT = jres["token_type"].ToString();
                        Tokens.AccessT = jres["access_token"].ToString();
                        MessageBox.Show("Success to connect!", "Announce", MessageBoxButtons.OK);
                       
                        this.Hide();
                        Form3 f3 = new Form3();
                        f3.Show();
                    }
                    else
                    {
                        var jres = JObject.Parse(res_content);
                        string detail = jres["detail"].ToString();
                        MessageBox.Show("Fail to connect ", "Error", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi: {ex.Message}", "Sai");
            }
        }
        private void lbregister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
   
}
