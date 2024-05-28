using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai2_lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btdownload_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string filePath = textBox2.Text;

            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                try
                {
                    using (WebClient myClient = new WebClient())
                    {
                        myClient.DownloadFile(url, filePath);   
                        if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                        {
                            try
                            {
                                string htmlContent = getHTML(url);
                                string a = htmlContent;
                                string[] b = Regex.Split(a, @" ").ToArray();
                                foreach (string b2 in b)
                                {
                                    richTextBox1.Text += b2;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid URL.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid URL.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string getHTML(string szURL)
        {
            WebRequest request = WebRequest.Create(szURL);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            response.Close();
            return responseFromServer;
        }

    }
}
