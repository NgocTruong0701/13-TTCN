namespace Example_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int Categoryid { get; set; }

        [Required(ErrorMessage = "Ten khong duoc de trong khong duoc de trong")]
        [DisplayName("Ten danh muc")]
        [StringLength(150)]
        public string CategoryName { get; set; }

        [StringLength(50)]
        [DisplayName("Ten title")]
        [Required(ErrorMessage = "Title khong duoc de trong")]
        public string MetaTitle { get; set; }
    }
}
