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
using ontapcackieu.model;
using System.Reflection;
using System.Text.RegularExpressions;
namespace ontapcackieu
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
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.MaLoai,
                            sp.SoLuong,
                            sp.DonGia,
                            ThanhTien = sp.DonGia * sp.SoLuong
                        };
            dg.ItemsSource = query.ToList();
        }
        private void hienthicb()
        {
            var query = from lsp in ds.LoaiSanPhams
                        select lsp;
            cboTenLoai.DisplayMemberPath = "TenLoai";
            cboTenLoai.SelectedValuePath = "MaLoai";
            cboTenLoai.SelectedIndex = 0;
            cboTenLoai.ItemsSource = query.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
            hienthicb();
        }
        private bool checkdl()
        {
            
            if (txtMsp.Text == "" || txtTsp.Text =="" || txtSl.Text=="" || txtDG.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ dữ liệu");
            }
            if(!Regex.IsMatch(txtSl.Text, @"\d"))
            {
                MessageBox.Show("Số lượng không phải là số");
                txtSl.Focus();
                return false;
            }
            else
            {
                if (int.Parse(txtSl.Text) < 0)
                {
                    MessageBox.Show("Số lượng phải là số dương");
                    return false;
                    txtSl.Focus();
                    
                }
                return true;
            }

            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var spmoi = ds.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMsp.Text));
            if(spmoi == null)
            {
                try
                {
                    if (checkdl())
                    {
                        SanPham sp = new SanPham();
                        sp.MaSp = txtMsp.Text;
                        sp.TenSp = txtTsp.Text;
                        LoaiSanPham lsp = (LoaiSanPham)cboTenLoai.SelectedItem;
                        sp.MaLoai = lsp.MaLoai;
                        sp.SoLuong = int.Parse(txtSl.Text);
                        sp.DonGia = double.Parse(txtDG.Text);
                        ds.SanPhams.Add(sp);
                        ds.SaveChanges();
                        hienthi();
                    }
                }
                catch(Exception e1)
                {
                    MessageBox.Show("Lỗi nhập", e1.Message);
                }
            }
            else
            {
                MessageBox.Show("Mã sản phẩm trùng");
            }
        }
    }
}
