using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baitaphuongdanbai5.Models
{
    public class Staff
    {
        public int Staffid { get; set; }
        public string Staffname { get; set; }
        public DateTime birthofdate { get; set; }
        public decimal salary { get; set; }
        public string Staffimage { get; set; }
    }
}