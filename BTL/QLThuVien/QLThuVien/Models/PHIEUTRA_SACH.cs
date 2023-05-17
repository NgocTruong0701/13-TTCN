namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PHIEUTRA_SACH
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string maSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string maPhieuTra { get; set; }

        public int soLuongSachTra { get; set; }

        public virtual PHIEUTRA PHIEUTRA { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
