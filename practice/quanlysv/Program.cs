using System;
using System.Collections.Generic;
using System.Linq;
namespace bai2
{
    class NhanVien
    {
        private string hoten;
        private DateTime ngay;
        public string ht
        {
            get { return hoten; }
            set { hoten = value; }
        }
        public DateTime ngaytd
        {
            get
            {
                return ngay;
            }
            set { ngay = value; }
        }
        public NhanVien() { }
        public NhanVien(string a,DateTime b)
        {
            ht = a; ngaytd = b;
        }
        public override string ToString()
        {
            return "\t\t" + ht + "\t\t" + ngaytd.ToString("dd-MM-yyyy");
        }
    }
    class NhanVienBanHang : NhanVien
    {
         private int soluongban;
        public int slb
        {
            get { return soluongban; }
            set { soluongban = value; }
        }
        public NhanVienBanHang() : base()
        {
            slb = 0;
        }
        public NhanVienBanHang(string ht,DateTime ngaytd,int soluong) : base(ht, ngaytd)
        {
            slb = soluong;
        }
        public float hh()
        {
            if (slb < 100)
            {
                return 1000;
            }
            else if (slb >= 100 && slb <= 500)
            {
                return 2000;
            }
            else
            {
                return 3000;
            }
        }
        public override string ToString()
        {
            return base.ToString()+"\t\t"+slb+ "\t\t" + hh();
        }
    }
    class Program
    {
        static List<NhanVien> dsnv = new List<NhanVien>();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            int chon;
            do
            {
                
                
                Console.WriteLine("Menu");
                Console.WriteLine("1.Thêm");
                Console.WriteLine("2.Hiện thị");
                Console.WriteLine("3.Sắp xếp");
                Console.WriteLine("4.Thoát");
                Console.WriteLine("Mời bạn chọn thao tác");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                { 
                    case 1:
                        Them();
                        break;
                    case 2:
                        HienThi();
                        break;
                    case 3:
                        SapXep();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    
                }
                    

            } while (chon !=4);
            void Them()
            {
                Console.WriteLine("1.Nhân Viên");
                Console.WriteLine("2.Nhân Viên Bán hàng:");
                Console.WriteLine("Mời bạn chọn nhân viên cần thêm:");
                int luachon = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Nhập họ tên nhân viên:");
                string a = Console.ReadLine();
                int ktra =0;
                for (int i = 0; i < dsnv.Count; i++)
                {
                    if (dsnv[i].ht == a)
                    {
                        ktra = 1;
                    }
                    else
                    {
                        ktra = 0;
                    }
                }
                if (ktra == 0)
                {
                    if (luachon == 1)
                    {
                        Console.WriteLine("Nhập ngày tuyển dụng");
                        DateTime ngaytd = DateTime.Parse(Console.ReadLine());
                        dsnv.Add(new NhanVien(a, ngaytd));
                    }
                    else
                    {
                        Console.WriteLine("Nhập ngày tuyển dụng");
                        DateTime ngaytd = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Nhập số lượng bán:");
                        int slb = int.Parse(Console.ReadLine());
                        dsnv.Add(new NhanVienBanHang(a, ngaytd, slb));
                    }

                }
                else
                {
                    Console.WriteLine("trùng họ tên");
                }
            }
            void HienThi()
            {
                foreach (var x in dsnv)
                {
                    if (x.GetType().Name == "NhanVien")
                    {
                        Console.WriteLine(x + "\t\t" + "----" + "\t\t" + "------");
                    }
                    else
                    {
                        Console.WriteLine(x);
                    }
                }
            }
            void SapXep()
            {
                dsnv.Sort(delegate (NhanVien nv1, NhanVien nv2)
                { int a = nv1.ngaytd.CompareTo(nv2.ngaytd);
                    if (a == 0)
                    {
                        return nv1.ht.CompareTo(nv2.ht);
                    }
                    else
                    {
                        return nv1.ngaytd.CompareTo(nv2.ngaytd);
                    }
                });
            }
        }
    }
}
