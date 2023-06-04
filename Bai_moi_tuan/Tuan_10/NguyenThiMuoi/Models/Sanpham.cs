namespace _095_Muoi_tx2.Models
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
        public int masp { get; set; }

        [StringLength(30)]
        public string tensp { get; set; }

        [StringLength(100)]
        public string mota { get; set; }

        public int? soluong { get; set; }

        public double? giatien { get; set; }

        [StringLength(50)]
        public string hinhanh { get; set; }

        public int? madanhmuc { get; set; }

        public virtual Danhmuc Danhmuc { get; set; }
    }
}
