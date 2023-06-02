namespace nguyenandung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Display(Name = "Mã rượu")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Tên rượu không được để trống!")]
        [StringLength(50)]
        [Display(Name = "Tên rượu")]
        public string ProductName { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Giá nhập không được để trống!")]
        [Column(TypeName = "numeric")]
        [Display(Name = "Giá nhập")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Giá bán không được để trống!")]
        [Column(TypeName = "numeric")]
        [Display(Name = "Giá bán")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống!")]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [StringLength(20)]
        [Display(Name = "Năm sản xuất")]
        public string Vintage { get; set; }

        [Required(ErrorMessage = "Danh mục không được để trống!")]
        [StringLength(10)]
        [Display(Name = "Danh mục")]
        public string CatalogyID { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Vùng không được để trống!")]
        [StringLength(100)]
        [Display(Name = "Vùng")]
        public string Region { get; set; }

        public virtual Catalogy Catalogy { get; set; }
    }
}
