using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai6
{
    public partial class Form1 : Form
    {
        private string accesst;
        private string tokent;
        public Form1()
        {
            InitializeComponent();
        }

        private void btconnect_Click(object sender, EventArgs e)
        {
            btConnect_ClickAsync();
        }

        private async Task btConnect_ClickAsync()
        {
            await ConnectToApiAsync();
        }

        private async Task ConnectToApiAsync()
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
                    if (res.IsSuccessStatusCode)
                    {

                        var jres = JObject.Parse(res_content);
                        tokent = jres["token_type"].ToString();
                        accesst = jres["access_token"].ToString();
                        rtbtoken.Text = $"Bearer {accesst}";
                        rtbtoken.Text += "\n\n\n\n" + "Đăng nhập thành công";
                    }

                    else
                    {
                        var jres = JObject.Parse(res_content);
                        string detail = jres["detail"].ToString();
                        MessageBox.Show("Đăng nhập thất bại ", "Error", MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi: {ex.Message}", "Sai");
            }
        }

        private void btinfo_Click(object sender, EventArgs e)
        {
            btinfo_ClickAsync();
        }

        private async Task btinfo_ClickAsync()
        {
            await InfoAsync();
        }
        private async Task InfoAsync()
        {
            if (string.IsNullOrEmpty(accesst))
            {
                MessageBox.Show("Lỗi chưa đăng nhập", "Error");
                return;
            }
            string url = "https://nt106.uitiot.vn/api/v1/user/me";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokent, accesst);
                    HttpResponseMessage res = await client.GetAsync(url);
                    string responseContent = await res.Content.ReadAsStringAsync();
                    if (res.IsSuccessStatusCode)
                    {
                        var jsonResponse = JObject.Parse(responseContent);
                        string id = jsonResponse["id"].ToString();
                        string uname = jsonResponse["username"].ToString();
                        string e_mail = jsonResponse["email"].ToString();
                        string e_mail_verify = jsonResponse["email_verified"].ToString();
                        string f_name = jsonResponse["first_name"].ToString();
                        string l_name = jsonResponse["last_name"].ToString();
                        string atr = jsonResponse["avatar"].ToString();
                        string gt = jsonResponse["sex"].ToString();
                        string birth = jsonResponse["birthday"].ToString();
                        string lang = jsonResponse["language"].ToString();
                        string dt = jsonResponse["phone"].ToString();
                        string dt_verify = jsonResponse["phone_verified"].ToString();
                        string is_active = jsonResponse["is_active"].ToString();
                        string is_sup = jsonResponse["is_superuser"].ToString();
                        string I_user = "Thông tin về user :" + "\n"
                                        + "ID:" + id + "\n"
                                        + "Username:" + uname + "\n"
                                        + "Email:" + e_mail + "\n"
                                        + "Email verified:" + e_mail_verify + "\n"
                                        + "First name:" + f_name + "\n"
                                        + "Last name:" + l_name + "\n"
                                        + "Avatar:" + atr + "\n"
                                        + "Sex:" + gt + "\n"
                                        + "Birthday:" + birth + "\n"
                                        + "Language:" + lang + "\n"
                                        + "Phone:" + dt + "\n"
                                        + "Phone verified:" + dt_verify + "\n"
                                        + "Is active:" + is_active + "\n"
                                        + "Is superuser:" + is_sup + "\n";

                        rtbtoken.Text = I_user.ToString();
                    }
                    else
                    {
                        var jres = JObject.Parse(responseContent);
                        string detail = jres["detail"].ToString();
                        MessageBox.Show(detail, "Lỗi");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Error");
            }
        }
    }

}
