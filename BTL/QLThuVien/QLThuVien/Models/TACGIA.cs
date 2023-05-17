namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TACGIA")]
    public partial class TACGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TACGIA()
        {
            SACHes = new HashSet<SACH>();
        }

        [Key]
        [Required(ErrorMessage = "Mã tác giả không được để trống")]
        [DisplayName("Mã tác giả")]
        [StringLength(10)]
        public string maTacGia { get; set; }

        [Required(ErrorMessage = "Tên tác giả không được để trống")]
        [DisplayName("Tên tác giả")]
        [StringLength(30)]
        public string tenTacGia { get; set; }

        [Required(ErrorMessage = "Năm sinh không được để trống")]
        [DisplayName("Năm sinh")]
        public DateTime namSinh { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        [DisplayName("Mô tả")]
        [StringLength(150)]
        public string moTa { get; set; }

        [StringLength(50)]
        public string anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACHes { get; set; }
    }
}
