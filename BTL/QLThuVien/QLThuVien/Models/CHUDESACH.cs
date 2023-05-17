﻿namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("CHUDESACH")]
    public partial class CHUDESACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUDESACH()
        {
            SACHes = new HashSet<SACH>();
        }

        [Key]
        [StringLength(10)]
        public string maChuDe { get; set; }

        [Required(ErrorMessage = "Tên chủ đề không được để trống")]
        [DisplayName("Tên chủ đề")]
        [StringLength(30)]
        public string tenChuDe { get; set; }

        [NotMapped]
        public int tongLuongSach {
            get
            {
                using (var context = new Model1())
                {
                    return context.SACHes.Count(s => s.maChuDe.Equals(maChuDe));
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACHes { get; set; }
    }
}
