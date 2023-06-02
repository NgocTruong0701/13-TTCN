namespace OnTap_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [Key]
        public int Mavd { get; set; }

        [Required]
        [StringLength(100)]
        public string Tenvd { get; set; }

        [StringLength(250)]
        public string Mota { get; set; }

        [Required]
        [StringLength(250)]
        public string TenAnh { get; set; }

        public decimal Giatien { get; set; }

        public int? Soluong { get; set; }

        public int MaDanhmuc { get; set; }

        public virtual Danhmuc Danhmuc { get; set; }
    }
}
