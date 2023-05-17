namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUMUON")]
    public partial class PHIEUMUON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUMUON()
        {
            PHIEUMUON_SACH = new HashSet<PHIEUMUON_SACH>();
        }

        [Key]
        [StringLength(10)]
        public string maPhieuMuon { get; set; }

        public DateTime ngayMuon { get; set; }

        [Required]
        [StringLength(20)]
        public string loaiMuon { get; set; }

        [Column(TypeName = "money")]
        public decimal tienTheCho { get; set; }

        public DateTime ngayTra { get; set; }

        [Required]
        [StringLength(10)]
        public string maNguoiMuon { get; set; }

        public virtual NGUOIMUON NGUOIMUON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUON_SACH> PHIEUMUON_SACH { get; set; }
    }
}
