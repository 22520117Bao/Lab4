using Newtonsoft.Json;
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

namespace Bai7_lab4
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = openFileDialog1.Filter = "JPG files (*jpg) | *.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //pictureBox1.ImageLocation = openFileDialog1.FileName;
                txtimage.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btadd_ClickAsync();
        }

        private async Task btadd_ClickAsync()
        {
            var info_food = new
            {
                ten_mon_an = txtfoodname.Text,
                gia = int.Parse(txtprice.Text),
                mo_ta = txtdescribe.Text,
                hinh_anh = txtimage.Text,
                dia_chi =txtaddress.Text,
            };

            string j_info = JsonConvert.SerializeObject(info_food);
            var data = new StringContent(j_info, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Tokens.TokenT, Tokens.AccessT);
                var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/monan/add", data);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Success to add food");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Fail to add food");
                }
            }
        }
    }
}
