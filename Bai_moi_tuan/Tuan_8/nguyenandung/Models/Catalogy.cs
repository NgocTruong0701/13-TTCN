namespace nguyenandung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Catalogy")]
    public partial class Catalogy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catalogy()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(10)]
        [Required(ErrorMessage = "Mã danh mục không được để trống!")]
        [Display(Name = "Mã danh mục")]
        public string CatalogyID { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống!")]
        [StringLength(50)]
        [Display(Name = "Tên danh mục")]
        public string CatalogyName { get; set; }

        [StringLength(100)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
