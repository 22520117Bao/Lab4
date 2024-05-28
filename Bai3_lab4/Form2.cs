using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3
{
    public partial class Form2 : Form
    {
        public Form2(string htmlContent)
        {
            InitializeComponent();
            txtSource.Text = htmlContent;
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnviewsource_Click(object sender, EventArgs e)
        {

        }
    }
}
