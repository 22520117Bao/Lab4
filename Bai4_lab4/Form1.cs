using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.IO;
using System.Security.Policy;
using System.Drawing;
using Microsoft.Web.WebView2.Core;

namespace bai4
{
    public partial class Form1 : Form
    {
        private List<Movie> movies = new List<Movie>();
        private FlowLayoutPanel FlowPanelMovie;


        public Form1()
        {
            InitializeComponent();
         
        }
        private async void btnFetchMovies_Click(object sender, EventArgs e)
        {
            await FetchAndLoadMoviesAsync();
        }

        private async Task FetchAndLoadMoviesAsync()
        {
            progressBar.Value = 0;        
            movies = await FetchMoviesAsync();
            SaveMoviesToJson(movies);
            
        }

        //private List<Movie> movies = new List<Movie>();
        //private FlowLayoutPanel FlowPanelMovie;
        private async Task<List<Movie>> FetchMoviesAsync()
        {
            var movies = new List<Movie>();
            string url = "https://betacinemas.vn/phim.htm";
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url); 

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(response); 

            var MoviesNode = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'col-lg-4 col-md-4 col-sm-8 col-xs-16 padding-right-30 padding-left-30 padding-bottom-30')]");
            
            if (MoviesNode == null || MoviesNode.Count == 0)
            {
                throw new Exception("No movies found. The XPath query did not return any results.");
            }

            progressBar.Maximum = MoviesNode.Count;
            progressBar.Value = 0;

            foreach (var node in MoviesNode) 
            {
                var titleNode = node.SelectSingleNode(".//h3/a"); 
                var linkNode = node.SelectSingleNode(".//h3/a");
                var imgNode = node.SelectSingleNode(".//img[@class='img-responsive border-radius-20']"); 

                if (titleNode != null && linkNode != null && imgNode != null)
                {
                    var d_Url = "https://betacinemas.vn" + linkNode.Attributes["href"].Value;
                    var detailResponse = await client.GetStringAsync(d_Url);
                    var detailDoc = new HtmlAgilityPack.HtmlDocument();
                    detailDoc.LoadHtml(detailResponse);

                    var genreNode = detailDoc.DocumentNode.SelectSingleNode("//ul[@class='list-unstyled font-lg font-family-san font-sm-15 font-xs-14']/li[1]");
                    var durationNode = detailDoc.DocumentNode.SelectSingleNode("//ul[@class='list-unstyled font-lg font-family-san font-sm-15 font-xs-14']/li[2]");
                    

                    var movie = new Movie
                    {
                        Title = titleNode.InnerText.Trim(),
                        Link = d_Url,
                        ImageUrl = imgNode.Attributes["src"].Value,
                      
                    };
                    movies.Add(movie);
                }
                progressBar.Value++; // ++ progressbar với mỗi node của 1 phim load hoàn thành
            }
            return movies;
        }


        private void SaveMoviesToJson(List<Movie> movies)
        {
            string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            File.WriteAllText("movies.json", json);
        }

      


        private void progressBar_Click(object sender, EventArgs e)
        {

        }

      
        private void pictureBoxMovie_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FlowPanelMovie = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,  
                WrapContents = false,
                ForeColor = Color.LightSkyBlue


            };
            Controls.Add(FlowPanelMovie);

            progressBar = new ProgressBar
            {
                Dock = DockStyle.Top,
                Maximum = 100,
                Value = 0
            };
            Controls.Add(progressBar);
            LoadMoviesAsync();
        }

        private async Task LoadMoviesAsync() 
        {
            try
            {
                var movies = await FetchMoviesAsync(); 
                SaveMoviesToJson(movies); 
                DisplayMovies(movies); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void DisplayMovies(List<Movie> movies) // show các phim 
        {
            foreach (var movie in movies)
            { // định dạng các controls trong panel 
                var pictureBox = new PictureBox
                {
                    ImageLocation = movie.ImageUrl,
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Width = 140,
                    Height = 220,
                    Dock = DockStyle.Left,
                    Cursor = Cursors.Hand,
                    BackColor = Color.LightSlateGray
                };

                var LabelTitleNode = new Label
                {
                    Text = movie.Title.Trim(),
                    Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point ,0),
                    ForeColor = Color.FromArgb(10, 192, 0),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Top,
                    Padding = new Padding(10),
                    Cursor = Cursors.Hand
                };

                var LabelLinkNode = new Label
                {
                    Text = $"{movie.Link}",
                    Font = new Font("Arial", 10F, FontStyle.Italic | FontStyle.Bold , GraphicsUnit.Point, 0),
                    AutoSize = true,
                    BorderStyle = BorderStyle.Fixed3D,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Padding = new Padding(5),
                    Cursor = Cursors.Hand
                };

                var panel = new Panel
                {
                    Width = FlowPanelMovie.ClientSize.Width -30,
                    Height = 270,
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle
                };

                panel.Controls.Add(LabelLinkNode);
                panel.Controls.Add(LabelTitleNode);
                panel.Controls.Add(pictureBox);


                LabelLinkNode.MouseEnter += (sender, e) => 
                {
                    LabelLinkNode.Font = new Font(LabelLinkNode.Font, FontStyle.Italic | FontStyle.Regular);
                };
                LabelLinkNode.MouseLeave += (sender, e) => // quay về bình thường
                {
                    LabelLinkNode.Font = new Font(LabelLinkNode.Font, FontStyle.Italic | FontStyle.Bold);
                };
                LabelLinkNode.Click += (sender, e) =>
                {
                    ShowMovieDetail(movie.Link);
                };

                LabelTitleNode.MouseEnter += (sender, e) =>
                {
                    LabelTitleNode.Font = new Font(LabelTitleNode.Font,  FontStyle.Regular);
                };
                LabelTitleNode.MouseLeave += (sender, e) =>
                {
                    LabelTitleNode.Font = new Font(LabelTitleNode.Font, FontStyle.Bold);
                };
                LabelTitleNode.Click += (sender, e) =>
                {
                    ShowMovieDetail(movie.Link);
                };
                pictureBox.MouseEnter += (sender, e) =>
                {
                    pictureBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                };
                pictureBox.MouseLeave += (sender, e) =>
                {
                    pictureBox.ForeColor = Color.Azure;
                };

                pictureBox.Click += (sender, e) =>
                {
                    ShowMovieDetail(movie.Link);
                };

                FlowPanelMovie.Controls.Add(panel);
            }
        }

        private void ShowMovieDetail(string detailUrl)
        {
            var f3 = new Form3(detailUrl);
            f3.Show();
        }

    }
    public class Movie
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string ImageUrl { get; set; }
        public int Time { get; set; } // Thời lượng phim (phút)
        public string Types { get; set; } // Thể loại phim
    }
}
