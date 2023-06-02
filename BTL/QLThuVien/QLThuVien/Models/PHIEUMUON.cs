namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUMUON")]
    public partial class PHIEUMUON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        [Key]
        [Required(ErrorMessage = "Mã phiếu mượn không được để trống")]
        [DisplayName("Mã phiếu mượn")]
        [StringLength(10)]
        public string maPhieuMuon { get; set; }

        [Required(ErrorMessage = "Ngày mượn không được để trống")]
        [DisplayName("Ngày mượn")]
        public DateTime ngayMuon { get; set; }

        [Required(ErrorMessage = "Loại mượn không được để trống")]
        [DisplayName("Loại mượn")]
        [StringLength(20)]
        public string loaiMuon { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Tiền thế chỗ không được để trống")]
        [DisplayName("Tiền thế chỗ")]
        public decimal tienTheCho { get; set; }

        [Required(ErrorMessage = "Ngày trả không được để trống")]
        [DisplayName("Ngày trả")]
        public DateTime ngayTra { get; set; }

        [Required(ErrorMessage = "Mã sách không được để trống")]
        [DisplayName("Mã sách")]
        [StringLength(10)]
        public string maSach { get; set; }

        [Required(ErrorMessage = "Mã người mượn không được để trống")]
        [DisplayName("Mã người mượn")]
        [StringLength(10)]
        public string maNguoiMuon { get; set; }

        public virtual NGUOIMUON NGUOIMUON { get; set; }

    }
}
