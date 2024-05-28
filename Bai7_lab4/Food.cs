using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai7_lab4
{
    public class Food
    {
        public string id { get; set; } 
        public string ten_mon_an { get; set; }
        public double gia { get; set; } 
        public string mo_ta { get; set; }
        public string hinh_anh { get; set; }
        public string dia_chi { get; set; }
        public string nguoi_dong_gop { get; set; } 

        
        public override string ToString()
        {
            return $"Tên món ăn:{ten_mon_an} \n- Giá: {gia} đồng \n- Địa chỉ: {dia_chi} \n- Người đóng góp: {nguoi_dong_gop}";
        }
    }

    public class FoodResponse 
    {
        public List<Food> Data { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public int Current { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
    }
}
