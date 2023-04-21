using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace De5.Models
{
    public class SanPham
    {

        [DisplayName("Mã sản phẩm: ")]
        public string masp { get; set; }

        [DisplayName("Tên sản phẩm: ")]
        public string tensp { get; set; }

        [DisplayName("Số lượng: ")]
        public int soluong { get; set; }

        [DisplayName("Giá tiền: ")]
        public int giatien { get; set; }

        [DisplayName("Giảm giá: ")]
        public int giamgia { get; set; }

       public double thanhtien
        {
            get
            {
                if (giamgia == 0)
                    return soluong * giatien;
                else
                    return soluong * giatien * 0.9;
            }
        } 

        public SanPham()
        {

        }

        public SanPham(string masp, string tensp, int soluong, int giatien, int giamgia)
        {
            this.masp = masp;
            this.tensp = tensp;
            this.soluong = soluong;
            this.giatien = giatien;
            this.giamgia = giamgia;
            
            

        }

      

    }
}