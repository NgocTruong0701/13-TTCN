namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
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
        [StringLength(10)]
        public string maPhieuTra { get; set; }

        public DateTime ngayTra { get; set; }

        [Column(TypeName = "money")]
        public decimal tienHoanTra { get; set; }

        public DateTime ngayPhat { get; set; }

        [Required]
        [StringLength(10)]
        public string maNguoiMuon { get; set; }

        public virtual NGUOIMUON NGUOIMUON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTRA_SACH> PHIEUTRA_SACH { get; set; }
    }
}
