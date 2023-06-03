namespace TX_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [Key]
        [DisplayName("Mã sản phẩm")]
        [Required(ErrorMessage = "Mã sản phẩm không được để trống")]
        public int Mavd { get; set; }

        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100)]
        public string Tenvd { get; set; }

        [DisplayName("Mô tả")]
        [StringLength(250)]
        public string Mota { get; set; }

        [DisplayName("Ảnh")]
        [StringLength(250)]
        public string TenAnh { get; set; }

        [DisplayName("Giá")]
        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        public decimal Giatien { get; set; }

        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Số lượng không được để trống")]
        public int? Soluong { get; set; }

        [DisplayName("Mã danh mục")]
        [Required(ErrorMessage = "Mã danh mục không được để trống")]
        public int MaDanhmuc { get; set; }

        public virtual Danhmuc Danhmuc { get; set; }
    }
}
