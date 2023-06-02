namespace THtuan11.Models
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
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(50)]
        [DisplayName("Id của Categorry")]
        public int Categoryid { get; set; }

        [Required]
        [StringLength(250)]
        public string ProdName { get; set; }

        [StringLength(50)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(550)]
        public string ImagePath { get; set; }

        public decimal Price { get; set; }
    }
}
