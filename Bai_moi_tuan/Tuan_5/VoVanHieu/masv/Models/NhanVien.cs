using System;
using System.Collections.Generic;

#nullable disable

namespace masv.Models
{
    public partial class NhanVien
    {
        public string Manv { get; set; }
        public string Hoten { get; set; }
        public string Mapb { get; set; }
        public double? Luong { get; set; }

        public virtual PhongBan MapbNavigation { get; set; }
    }
}
