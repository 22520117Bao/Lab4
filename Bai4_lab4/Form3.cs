using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai4
{
    public partial class Form3 : Form
    {
        public Form3(string url)
        {
            InitializeComponent();
            movieUrl = url;
            this.Load += new EventHandler(Form3_Load);
        }
        private string movieUrl;
        private void Form3_Load(object sender, EventArgs e)
        {
            webView.Source = new Uri(movieUrl);
        }

        private void webView_Click(object sender, EventArgs e)
        {

        }
    }
}
