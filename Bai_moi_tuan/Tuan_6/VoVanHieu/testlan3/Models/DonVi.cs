using System;
using System.Collections.Generic;

#nullable disable

namespace testlan3.Models
{
    public partial class DonVi
    {
        public DonVi()
        {
            VienChucs = new HashSet<VienChuc>();
        }

        public string Madv { get; set; }
        public string Tendonvi { get; set; }

        public virtual ICollection<VienChuc> VienChucs { get; set; }
    }
}
