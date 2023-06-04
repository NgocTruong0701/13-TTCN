using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLThuVien.Models
{
    public class PhieuMuonViewModel
    {
        public string maPhieuMuon { get; set; }
        public string TenSach { get; set; }
        public DateTime NgayMuon { get; set; }
        public string LoaiMuon { get; set; }
        public decimal TienTheCho { get; set; }
        public DateTime NgayTra { get; set; }
    }
}