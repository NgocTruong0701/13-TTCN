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
using de5.Models;

namespace de5
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
        De5Context db = new De5Context();
        private void hienthi()
        {
            var data = from cn in db.VienChucs
                       orderby cn.Songaycong
                       select new
                       {
                           cn.Mavc,
                           cn.Hoten,
                           cn.Madv,
                           cn.Songaycong,
                           Luong = cn.Songaycong * 120000
                       };
            var data1 = from vc in db.DonVis
            dsvc.ItemsSource = data.ToList();
        }
        private void hienthicb()
        {
                        select vc;
            cb_donvi.ItemsSource = data1.ToList();
            cb_donvi.DisplayMemberPath = "Tendonvi";
            cb_donvi.SelectedValuePath = "Madv";
            cb_donvi.SelectedIndex = 0;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
            hienthicb();
        }

        private void btn_Them_Click(object sender, RoutedEventArgs e)
        {
            var vcthem = db.VienChucs.SingleOrDefault(t => t.Mavc.Equals(txt_macv.Text));
            if(vcthem == null)
            {
                VienChuc v = new VienChuc();
                v.Hoten = txt_hoten.Text;
                v.Madv = ((DonVi)cb_donvi.SelectedItem).Madv;
                v.Mavc = txt_macv.Text;
                v.Songaycong = int.Parse(txt_ngaycong.Text);
                db.VienChucs.Add(v);
                db.SaveChanges();
                MessageBox.Show("Them thanh cong", "Thong bao");
                hienthi();
            }else
            {
                MessageBox.Show("Vien chuc nay da ton tai", "Thong bao");
            }
        }

        private void btn_tim_Click(object sender, RoutedEventArgs e)
        {
            var ten = db.VienChucs.SingleOrDefault(t => t.Hoten.Equals(txt_hoten.Text));
            if (ten == null)
            {
                MessageBox.Show("Khong tim thay vien chuc nay.", "Thong bao");

            }else
            {
                var tim = from s in db.VienChucs
                          where s.Hoten == txt_hoten.Text
                          select new
                          {
                              s.Mavc,
                              s.Hoten,
                              s.Madv,
                              s.Songaycong,
                              Luong = s.Songaycong * 120000
                          };
                dsvc.ItemsSource = tim.ToList();
            }
        }

        private void dsvc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void btn_tim2_Click(object sender, RoutedEventArgs e)
        {
            DonVi y = (DonVi)cb_donvi.SelectedItem;
            var a = from b in db.VienChucs
                    where b.Madv == y.Madv\
                    select new
                    {
                        b.Mavc,
                        b.Hoten,
                        b.Madv,
                        b.Songaycong,
                        Luong = b.Songaycong * 120000
                    };
            dsvc.ItemsSource = a.ToList();
        }
    }
}
