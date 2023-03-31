using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhapDiemThi.Models
{
    public class Student
    {
        public string Name {get; set;}
        public int option { get; set;}
        public int KhuVuc { get; set; }
        public double DiemToan { get; set; }
        public double DiemLy { get; set; }
        public double DiemHoa { get; set; }

    }
}