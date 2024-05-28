using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai7_lab4
{
    public partial class Form5 : Form
    {
        public Form5(string tenmonan, string gia, string mota, string diachi, string hinhanh )
        {
            InitializeComponent();
            ShowTheForm(tenmonan, gia, mota, diachi, hinhanh);
        }

        public Form5(Food randomFood)
        {
        }

        private void ShowTheForm(string tenmonan, string gia, string mota, string diachi, string hinhanh)
        {
           
            
             pictureBox1.ImageLocation = hinhanh;

            
            string a = $"Món ăn hôm nay là : {tenmonan}\r\nGiá: {gia}\r\nMô tả: {mota}\r\nĐịa chỉ: {diachi}";
            txtFood.Text = "Những thông tin về món ăn là: \r\n" + a;
                            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
