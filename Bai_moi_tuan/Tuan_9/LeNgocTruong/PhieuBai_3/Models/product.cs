namespace PhieuBai_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [Key]
        [Required(ErrorMessage = "Ma san pham khong duoc trong")]
        [DisplayName("Ma san pham")]
        public int proid { get; set; }

        [Required(ErrorMessage = "Ten san pham khong duoc trong")]
        [DisplayName("Ten san pham")]
        [StringLength(45)]
        public string proname { get; set; }

        [Required(ErrorMessage = "Gia khong duoc trong")]
        [DisplayName("Gia")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "Stock khong duoc trong")]
        [DisplayName("Stock")]
        public decimal stock { get; set; }

        [DisplayName("Anh")]
        [StringLength(100)]
        public string image { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Mo ta khong duoc trong")]
        [DisplayName("Mo ta")]
        public string description { get; set; }

        [Required(ErrorMessage = "Ma danh muc khong duoc trong")]
        [DisplayName("Ma danh muc")]
        public int catid { get; set; }

        public virtual category category { get; set; }
    }
}
