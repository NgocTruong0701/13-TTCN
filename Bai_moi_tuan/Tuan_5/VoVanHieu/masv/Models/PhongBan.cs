using System;
using System.Collections.Generic;

#nullable disable

namespace masv.Models
{
    public partial class PhongBan
    {
        public PhongBan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public string Mapb { get; set; }
        public string Tenphong { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
