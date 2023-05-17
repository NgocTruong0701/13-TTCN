namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUANTRIVIEN")]
    public partial class QUANTRIVIEN
    {
        [Key]
        [StringLength(10)]
        public string maQTV { get; set; }

        [Required]
        [StringLength(30)]
        public string tenQTV { get; set; }

        [Required]
        [StringLength(20)]
        public string taiKhoan { get; set; }

        [Required]
        [StringLength(20)]
        public string matKhau { get; set; }
    }
}
