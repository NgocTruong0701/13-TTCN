namespace Example_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int Pid { get; set; }

        [Required(ErrorMessage = "Ma danh muc khong duoc trong")]
        [DisplayName("Ma danh muc")]
        public int Categoryid { get; set; }

        [Required(ErrorMessage = "Ten san pham khong duoc trong")]
        [DisplayName("Ten san pham")]
        [StringLength(250)]
        public string ProdName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Ten title khong duoc trong")]
        [DisplayName("Title")]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Mo ta khong duoc de trong")]
        [DisplayName("Mo ta")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Anh khong duoc de trong")]
        [DisplayName("Anh")]
        [StringLength(550)]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Gia khong duoc trong")]
        [DisplayName("Gia")]
        public decimal Price { get; set; }

        [DisplayName("So luong")]
        public int? Quatity { get; set; }
    }
}
