﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ontap.model
{
    public partial class SanPham
    {
        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public string MaLoai { get; set; }
        public double? DonGia { get; set; }
        public int? SoLuong { get; set; }
    }
}
