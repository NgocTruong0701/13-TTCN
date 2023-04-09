using System;
using System.Collections.Generic;

#nullable disable

namespace test4.Models
{
    public partial class KhoaKham
    {
        public KhoaKham()
        {
            BenhNhans = new HashSet<BenhNhan>();
        }

        public string Makhoa { get; set; }
        public string Tenkhoa { get; set; }

        public virtual ICollection<BenhNhan> BenhNhans { get; set; }
    }
}
