using System;
using System.Collections.Generic;

#nullable disable

namespace de5.Models
{
    public partial class VienChuc
    {
        public string Mavc { get; set; }
        public string Hoten { get; set; }
        public string Madv { get; set; }
        public int? Songaycong { get; set; }

        public virtual DonVi MadvNavigation { get; set; }
    }
}
