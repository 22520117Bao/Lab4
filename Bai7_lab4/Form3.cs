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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form3_Load);
        }
        private List<Food> foodList;
        private int cUserPage = 1;
        private int cAllPage = 1;
        private string cList = "AllFood";
        

        private void btrandomfood_Click(object sender, EventArgs e)
        {
            if (foodList != null && foodList.Count > 0) 
            {
                var random = new Random();
                var randomFood = foodList[random.Next(foodList.Count)];
                string tenmonan = randomFood.ten_mon_an;
                string gia = randomFood.gia.ToString();
                string mota= randomFood.mo_ta.ToString();
                string diachi = randomFood.dia_chi.ToString();
                string hinhanh = randomFood.hinh_anh.ToString();
                Form5 f5 = new Form5(tenmonan,gia,mota,diachi,hinhanh);
                f5.Show();
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu món ăn.");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form3_LoadAsync();
        }

        private async Task Form3_LoadAsync()
        {
            await LoadFoodDataAsync();
        }

        private async Task LoadFoodDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new
                    System.Net.Http.Headers.AuthenticationHeaderValue(Tokens.TokenT, Tokens.AccessT); 

                var requestBody = new
                {
                    current = 1,
                    pageSize = 5
                }; 
                txtpage.Text = requestBody.pageSize.ToString();

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/monan/all", content); 

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();


                    System.IO.File.WriteAllText("food_data.json", jsonResponse); 


                    var foodResponse = JsonConvert.DeserializeObject<FoodResponse>(jsonResponse);
                    foodList = foodResponse.Data;


                    lbfood.Items.Clear();
                    foreach (var food in foodList) 
                    {
                        lbfood.Items.Add(food);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load food data.");
                }
            }
        }

        private void btaddfood_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }
        private async Task LoadUserCreatedFoodAsync(int currentUserPage) 
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Tokens.TokenT, Tokens.AccessT);
                var requestBody = new
                {
                    current = currentUserPage, 
                    pageSize = 5
                };
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/monan/my-dishes", content); 
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var foodResponse = JsonConvert.DeserializeObject<FoodResponse>(jsonResponse);
                    foodList = foodResponse.Data;
                    lbfood.Items.Clear();
                    foreach (var food in foodList)
                    {
                        lbfood.Items.Add(food);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load user-created food data.");
                }
            }
        }

        private async Task LoadAllFoodAsync(int currentAllPage)// Hàm load món ăn all, tương tự với hàm LoadUserCreatedFoodAsync(int) 
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Tokens.TokenT, Tokens.AccessT);
                var requestBody = new
                {
                    current = currentAllPage, // Use currentAllPage value
                    pageSize = 5
                };
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/monan/all", content); 
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var foodResponse = JsonConvert.DeserializeObject<FoodResponse>(jsonResponse);
                    foodList = foodResponse.Data;
                    lbfood.Items.Clear();
                    foreach (var food in foodList)
                    {
                        lbfood.Items.Add(food);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load all food data.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btdelete_ClickAsync();
        }

        private async Task btdelete_ClickAsync()
        {
            if (lbfood.SelectedItem is Food selectedFood && selectedFood.nguoi_dong_gop == User.LoginUser)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Tokens.TokenT, Tokens.AccessT);

                    var response = await client.DeleteAsync($"https://nt106.uitiot.vn/api/v1/monan/{selectedFood.id}"); 

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var delFood = JsonConvert.DeserializeObject<Food>(jsonResponse);
                        string deletef = "Xóa món ăn :"
                                         + "\n Tên món ăn" + delFood.ten_mon_an
                                         + "\n Giá:" + delFood.gia
                                         + "\n Mô tả:" + delFood.mo_ta
                                         + "\n Hình ảnh:" + delFood.hinh_anh
                                         + "\n Địa chỉ:" + delFood.dia_chi
                                         + "\n Người đóng góp:" + delFood.nguoi_dong_gop;
                        MessageBox.Show(deletef, "Món ăn hôm nay");
                        
                        if (cList == "AllFood") 
                        {
                            await LoadAllFoodAsync(cAllPage);
                        }
                        else if (cList == "UserCreatedFood")
                        {
                            await LoadUserCreatedFoodAsync(cUserPage);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xóa món ăn thất bại ", "Warning",MessageBoxButtons.RetryCancel);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chỉ được xóa món ăn bạn tạo ");
            }
        }

        private void btmyfood_Click(object sender, EventArgs e)
        {
            btmyfood_ClickAsync();
        }

        private async Task btmyfood_ClickAsync()
        {
            cUserPage = 1;
            cList = "UserCreatedFood";
            await LoadUserCreatedFoodAsync(cUserPage);
        }

        private void btallfood_Click(object sender, EventArgs e)
        {
            btallfood_ClickAsync();
        }

        private async Task btallfood_ClickAsync()
        {
            cAllPage = 1;
            cList = "AllFood";
            await LoadAllFoodAsync(cAllPage);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btpre_ClickAsync();
        }

        private async Task btpre_ClickAsync()
        {
            if (cList == "AllFood")
            {
                if (cAllPage > 1)
                {
                    cAllPage--;
                    await LoadAllFoodAsync(cAllPage);
                    txtcount.Text = cAllPage.ToString();
                }
            }
            else if (cList == "UserCreatedFood")
            {
                if (cUserPage > 1)
                {
                    cUserPage--;
                    await LoadUserCreatedFoodAsync(cAllPage);
                    txtcount.Text = cUserPage.ToString();
                }
            }

        }

        private void btnext_Click(object sender, EventArgs e)
        {
            btnext_ClickAsync();
        }

        private async Task btnext_ClickAsync()
        {
            if (cList == "AllFood") 
            {
                cAllPage++;
                await LoadAllFoodAsync(cAllPage);
                txtcount.Text = cAllPage.ToString();
            }
            else if (cList == "UserCreatedFood")
            {
                cUserPage++;
                await LoadUserCreatedFoodAsync(cUserPage);
                txtcount.Text = cUserPage.ToString();
            }
        }
    }
}
