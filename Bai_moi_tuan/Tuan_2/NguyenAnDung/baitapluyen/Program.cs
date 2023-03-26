using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
namespace de02
{
    class NhanVien
    {
        private string _mnv;
        private string _hoten;
        private bool _gt;
        public string mnv { get { return _mnv; } set { _mnv = value; } }
        public string hoten { get { return _hoten; } set { _hoten = value; } }
        public bool gt { get { return _gt; } set { _gt = value; } }

        public NhanVien()
        {

        }
        public NhanVien(string a, string b, bool c)
        {
            mnv = a; hoten = b; gt = c;
        }
        public override string ToString()
        {
            Console.OutputEncoding = UnicodeEncoding.UTF8;
            string gioitinh;
            if (gt == true)
            {
                gioitinh = "Nam";
            }
            else
            {
                gioitinh = "Nữ";
            }
            return "\t\t" + mnv + "\t\t" + hoten + "\t\t" + gioitinh;
        }
    }
    class NhanVienBanHang : NhanVien
    {
        private double sotien;
        public double stbh { get { return sotien; } set { sotien = value; } }

        public NhanVienBanHang() : base()
        {
            stbh = 0;
        }
        public NhanVienBanHang(string mnv,string hoten,bool gt,double Stbh) : base(mnv, hoten, gt)
        {
            stbh = Stbh;
        }

        public double hh()
        {
            if (stbh < 1000)
            {
                return 0;
            }
            else if (stbh >= 1000 && stbh <= 5000)
            {
                return 10 * stbh / 100;
            }
            else
            {
                return 20 * stbh / 100;
            }
        }
        public override string ToString()
        {
            Console.OutputEncoding = UnicodeEncoding.UTF8;
            return base.ToString() + "\t\t" + this.stbh + "\t\t" + this.hh();
        }
        class Program
        {
            static List<NhanVien> dsnv = new List<NhanVien>();

            static void Main(string[] args)
            {
                Console.OutputEncoding = UnicodeEncoding.UTF8;
                //dsnv.Add(new NhanVien("dat", "dat", true,));
                int chon;
                do
                {

                    Console.WriteLine("1.Hiện thị");
                    Console.WriteLine("2.Thêm");
                    Console.WriteLine("3.Sửa");
                    Console.WriteLine("4.Thoát");
                    
                    chon = int.Parse(Console.ReadLine());
                    switch (chon)
                    {
                        case 1:
                            hienthi();
                            break;
                        case 2:
                            them();
                            break;
                        case 3:
                            sua();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Nhập lại");
                            break;
                    }
                } while (chon!=4);
                void them()
                {
                    Console.WriteLine("Mời bạn chọn loại nhân viên muốn thêm");
                    Console.WriteLine("1.Nhân viên");
                    Console.WriteLine("2.Nhân viên bán hàng:");
                    int ktra=0;
                    int loainv;
                    loainv = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhập mã nhân viên:");
                    string mnv = Console.ReadLine();
                    for (int i = 0; i < dsnv.Count; i++)
                    {
                        if (dsnv[i].mnv == mnv)
                        {
                            ktra = 1;
                        }
                        else
                        {
                            ktra = 0;
                        }
                        
                    }
                    if (ktra != 1)
                    {
                        if (loainv == 1)
                        {

                            Console.WriteLine("Nhập họ tên: ");
                            string hoten = Console.ReadLine();
                            Console.WriteLine("Nhập giới tính: ");
                            bool gt = bool.Parse(Console.ReadLine());
                            dsnv.Add(new NhanVien(mnv, hoten, gt));
                        }
                        if (loainv == 2)
                        {

                            Console.WriteLine("Nhập họ tên: ");
                            string hoten = Console.ReadLine();
                            Console.WriteLine("Nhập giới tính: ");
                            bool gt = bool.Parse(Console.ReadLine());
                            Console.WriteLine("Nhập số tiền bán hàng:");
                            double stbh = double.Parse(Console.ReadLine());
                            dsnv.Add(new NhanVienBanHang(mnv, hoten, gt, stbh));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Mã nhân viên trùng");
                    }
                }
                void hienthi()
                {
                    foreach(var x in dsnv)
                    {
                        string a=x.GetType().Name;
                        if (a == "NhanVien")
                        {
                            Console.WriteLine(x + "\t\t----" + "\t\t-----");
                        }
                        else
                        {
                            Console.WriteLine(x);
                        }
                    }
                }
                void sua()
                {
                    Console.WriteLine("Nhap ma nhan vien:");
                    string mnv = Console.ReadLine();
                    for(int i = 0; i < dsnv.Count; i++)
                    {
                        if (dsnv[i].mnv.ToLower() == mnv)
                        {
                            string loainv = dsnv[i].GetType().Name;
                            if (loainv == "NhanVien")
                            {
                                Console.WriteLine("Nhập mã nhân viên:");
                                dsnv[i].mnv = Console.ReadLine();
                                Console.WriteLine("Nhập họ tên: ");
                                dsnv[i].hoten =Console.ReadLine();
                                Console.WriteLine("Nhập giới tính: ");
                                dsnv[i].gt = bool.Parse(Console.ReadLine());
                            }

                            else
                            {
                                NhanVienBanHang nvbh = new NhanVienBanHang();
                                Console.WriteLine("Nhập mã nhân viên:");
                                nvbh.mnv = Console.ReadLine();
                                Console.WriteLine("Nhập họ tên: ");
                                nvbh.hoten = Console.ReadLine();
                                Console.WriteLine("Nhập giới tính: ");
                                nvbh.gt = bool.Parse(Console.ReadLine());
                                Console.WriteLine("Nhap so tien ban hang:");
                                nvbh.stbh = double.Parse(Console.ReadLine());
                                dsnv[i] = nvbh;

                            }
                        }
                    }
                }
                }
            }
        }
    }

