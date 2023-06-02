namespace THtuan11.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int Categoryid { get; set; }

        [Required]
        [StringLength(150)]
        public string CategoryName { get; set; }

        [StringLength(50)]
        public string MetaTitle { get; set; }
    }
}
