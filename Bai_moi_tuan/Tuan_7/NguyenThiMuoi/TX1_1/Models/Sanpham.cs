using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TX1_1.Models
{
    public class Sanpham
    {
        [DisplayName("Mã sản phẩm")]
        public string masp { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string tensp { get; set; }

        [DisplayName("Số lượng")]
        public int soluong { get; set; }

        [DisplayName("Giá tiền")]
        public double giatien { get; set; }

        [DisplayName("Thành tiền")]
        public double thanhtien
        {
            get { return soluong * giatien; }
        }

        public Sanpham()
        {
            
        }

        public Sanpham(string masp, string tensp, int soluong, double giatien)
        {
            this.masp = masp;
            this.tensp = tensp;
            this.soluong = soluong;
            this.giatien = giatien;
        }
    }
}