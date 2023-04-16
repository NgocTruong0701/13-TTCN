using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using masv.Models;
namespace masv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        De1Context db = new De1Context();
        private void HienThiDL()
        {
            var query = from nv in db.NhanViens
                        orderby nv.Luong
                        select new
                        {
                            nv.Manv,
                            nv.Hoten,
                            nv.Mapb,
                            nv.Luong,
                            ThuNhap = nv.Luong * 1.5
                        };
            dgvNV.ItemsSource = query.ToList();
        }
        private void HienThiCB()
        {
            var query = from pb in db.PhongBans
                        select pb;
            txtPhong.ItemsSource = query.ToList();
            txtPhong.DisplayMemberPath = "Tenphong";
            txtPhong.SelectedValuePath = "MaPhong";
            txtPhong.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiCB();
            HienThiDL();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var query = db.NhanViens.SingleOrDefault(t => t.Manv.Equals(txtMa.Text));
            if(query!=null)
            {
                MessageBox.Show("ma san pham nay da ton tai!", "Thong bao");
                HienThiDL();
            }
            else
            {
                NhanVien nvMoi = new NhanVien();
                nvMoi.Manv = txtMa.Text;
                nvMoi.Hoten = txtTen.Text;
                nvMoi.Mapb = txtPhong.Text;
                nvMoi.Luong = double.Parse(txtLuong.Text);
                PhongBan i = (PhongBan)txtPhong.SelectedItem;
                nvMoi.Mapb = i.Mapb;
                db.NhanViens.Add(nvMoi);
                db.SaveChanges();
                MessageBox.Show("them thanh cong!", "Thong bao");
                HienThiDL();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PhongBan b = 
            var data = from nv in db.NhanViens
                       join nv1 in db.PhongBans
                       on nv.Mapb equals nv1.Mapb
                       select new
                       {
                           nv.Manv,
                           nv.Mapb,
                           nv.Luong,
                           nv.Hoten
                       };
            dgvNV.ItemsSource = data.ToList();
        }
    }
}
