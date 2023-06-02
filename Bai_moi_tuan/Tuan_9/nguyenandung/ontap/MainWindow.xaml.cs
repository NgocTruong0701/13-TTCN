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
using ontap.model;
using System.Reflection;
using System.Text.RegularExpressions;
namespace ontap
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
        _12Context ds = new _12Context();
        private void hienthi()
        {
            var query = from sp in ds.SanPhams
                        orderby sp.DonGia
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.MaLoai,
                            sp.DonGia,
                            sp.SoLuong,
                            thanhtien=sp.SoLuong*sp.DonGia
                        };
            dg.ItemsSource = query.ToList();
        }
        private void hienthicb()
        {
            var query = from lsp in ds.LoaiSanPhams
                        select lsp;
            cboLsp.ItemsSource = query.ToList();
            cboLsp.DisplayMemberPath = "TenLoai";
            cboLsp.SelectedValuePath = "MaLoai";
            cboLsp.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
            hienthicb();

        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            var query = ds.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMsp.Text));
            if (query == null)
            {
                try
                {
                    SanPham sp = new SanPham();
                    sp.MaSp = txtMsp.Text;
                    sp.TenSp = txtTsp.Text;
                    LoaiSanPham lsp = (LoaiSanPham)cboLsp.SelectedItem;
                    sp.MaLoai = lsp.MaLoai;
                    sp.DonGia = double.Parse(txtDongia.Text);
                    sp.SoLuong = int.Parse(txtSl.Text);
                    ds.SanPhams.Add(sp);
                    ds.SaveChanges();
                    hienthi();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Lỗi nhập", e1.Message);
                }
            }
            else
            {
                MessageBox.Show("Mã sản phẩm trùng");
                hienthi();
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var query = ds.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMsp.Text));
            if (query != null)
            {
                try
                {
                    query.TenSp = txtTsp.Text;
                    LoaiSanPham lsp = (LoaiSanPham)cboLsp.SelectedItem;
                    query.MaLoai = lsp.MaLoai;
                    query.DonGia = double.Parse(txtDongia.Text);
                    query.SoLuong = int.Parse(txtSl.Text);
                    ds.SaveChanges();
                    hienthi();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Lỗi sửa", e1.Message);
                }
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào có mã này");
                hienthi();
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var sp = ds.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMsp.Text)); var query = ds.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMsp.Text));
            if (sp != null)
            {
                try
                {
                    ds.Remove(sp);
                    ds.SaveChanges();
                    hienthi();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Lỗi xóa", e1.Message);
                }
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào có mã này để xóa");
                hienthi();
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            LoaiSanPham query = (LoaiSanPham)cboLsp.SelectedItem;
            var sp = from s in ds.SanPhams
                     where s.MaLoai == query.MaLoai
                     select new
                     {
                         s.MaSp,
                         s.TenSp,
                         s.MaLoai,
                         s.DonGia,
                         s.SoLuong,
                         ThanhTien = s.SoLuong* s.DonGia
                     };
            dg.ItemsSource = null;
            dg.ItemsSource = sp.ToList();               
        }

        private void btnTk_Click(object sender, RoutedEventArgs e)
        {
            Window1 mywindow = new Window1();
            mywindow.Show();
            
        }
    }
}
