namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUTRA")]
    public partial class PHIEUTRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUTRA()
        {
            PHIEUTRA_SACH = new HashSet<PHIEUTRA_SACH>();
        }

        [Key]
        [Required(ErrorMessage = "Mã phiếu trả không được để trống")]
        [DisplayName("Mã phiếu trả")]
        [StringLength(10)]
        public string maPhieuTra { get; set; }

        [Required(ErrorMessage = "Ngày trả không được để trống")]
        [DisplayName("Ngày trả")]
        public DateTime ngayTra { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Tiền hoàn trả không được để trống")]
        [DisplayName("Tiền hoàn trả")]
        public decimal tienHoanTra { get; set; }

        [Required(ErrorMessage = "Tiền phạt không được để trống")]
        [DisplayName("Tiền phạt")]
        [Column(TypeName = "money")]
        public decimal tienPhat { get; set; }

        [Required(ErrorMessage = "Mã người mượn không được để trống")]
        [DisplayName("Mã người mượn")]
        [StringLength(10)]
        public string maNguoiMuon { get; set; }

        public virtual NGUOIMUON NGUOIMUON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTRA_SACH> PHIEUTRA_SACH { get; set; }
    }
}
