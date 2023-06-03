namespace TX_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Danhmuc")]
    public partial class Danhmuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Danhmuc()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        [Key]
        [DisplayName("Mã danh mục")]
        [Required(ErrorMessage = "Mã danh mục không được để trống")]
        public int MaDanhmuc { get; set; }

        [DisplayName("Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(50)]
        public string TenDanhmuc { get; set; }

        [StringLength(100)]
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Mô tả không được để trống")]
        public string Mota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
