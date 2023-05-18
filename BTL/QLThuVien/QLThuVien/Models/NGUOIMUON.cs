namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
using System.ComponentModel;
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
        [Required(ErrorMessage = "Mã người mượn không được để trống")]
        [DisplayName("Mã người mượn")]
        [StringLength(10)]
        public string maNguoiMuon { get; set; }

        [Required(ErrorMessage = "Tên người mượn không được để trống")]
        [DisplayName("Tên người mượn")]
        [StringLength(30)]
        public string tenNguoiMuon { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [DisplayName("Số điện thoại")]
        [StringLength(15)]
        public string soDT { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [DisplayName("Mã tác giả")]
        [StringLength(30)]
        public string diaChi { get; set; }

        [Required(ErrorMessage = "Tài khoản không được để trống")]
        [DisplayName("Tài khoản")]
        [StringLength(20)]
        public string taiKhoan { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DisplayName("Mật khẩu")]
        [StringLength(20)]
        public string matKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUON> PHIEUMUONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTRA> PHIEUTRAs { get; set; }
    }
}
