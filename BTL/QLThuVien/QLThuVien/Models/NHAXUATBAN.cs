namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHAXUATBAN")]
    public partial class NHAXUATBAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAXUATBAN()
        {
            SACHes = new HashSet<SACH>();
        }

        [Key]
        [Required(ErrorMessage = "Mã nhà xuất bản không được để trống")]
        [DisplayName("Mã nhà xuất bản")]
        [StringLength(10)]
        public string maNXB { get; set; }

        [Required(ErrorMessage = "Tên nhà xuất bản không được để trống")]
        [DisplayName("Tên nhà xuất bản")]
        [StringLength(30)]
        public string tenNXB { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [DisplayName("Số điện thoại")]
        [StringLength(15)]
        public string soDT { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [DisplayName("Địa chỉ")]
        [StringLength(30)]
        public string diaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACHes { get; set; }
    }
}
