namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIMUON")]
    public partial class NGUOIMUON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOIMUON()
        {
            PHIEUMUONs = new HashSet<PHIEUMUON>();
            PHIEUTRAs = new HashSet<PHIEUTRA>();
        }

        [Key]
        [StringLength(10)]
        public string maNguoiMuon { get; set; }

        [Required]
        [StringLength(30)]
        public string tenNguoiMuon { get; set; }

        [Required]
        [StringLength(15)]
        public string soDT { get; set; }

        [Required]
        [StringLength(30)]
        public string diaChi { get; set; }

        [Required]
        [StringLength(20)]
        public string taiKhoan { get; set; }

        [Required]
        [StringLength(20)]
        public string matKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUON> PHIEUMUONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTRA> PHIEUTRAs { get; set; }
    }
}
