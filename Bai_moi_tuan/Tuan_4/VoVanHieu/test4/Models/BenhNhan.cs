using System;
using System.Collections.Generic;

#nullable disable

namespace test4.Models
{
    public partial class BenhNhan
    {
        public string Mabn { get; set; }
        public string Hoten { get; set; }
        public string Makhoa { get; set; }
        public int? SongayNv { get; set; }

        public virtual KhoaKham MakhoaNavigation { get; set; }
    }
}
