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
using testlan3.Models;
namespace testlan3
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
            var data = from vc1 in db.VienChucs
                       orderby vc1.Songaycong
                       select new
                       {
                           vc1.Mavc,
                           vc1.Hoten,
                           vc1.Madv,
                           vc1.Songaycong,
                           luong = vc1.Songaycong * 120000
                       };
            dsvc.ItemsSource = data.ToList();
        }
        private void hienthicb()
        {
            var data1 = from vc2 in db.DonVis
                        select vc2;
            cbodvi.ItemsSource = data1.ToList();
            cbodvi.SelectedIndex = 0;
            cbodvi.DisplayMemberPath = "Tendonvi";
            cbodvi.SelectedValuePath = "Madv";
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
            hienthicb();
        }

        private void butthem_Click(object sender, RoutedEventArgs e)
        {
            var vcthem = db.VienChucs.SingleOrDefault(t => t.Mavc.Equals(txtmvc.Text));
            if (vcthem == null)
            {
                VienChuc v = new VienChuc();
                v.Madv = ((DonVi)cbodvi.SelectedItem).Madv;
                v.Hoten = txthoten.Text;
                v.Mavc=txtmvc.Text;
                v.Songaycong=int.Parse(txtsnc.Text);
                db.VienChucs.Add(v);
                db.SaveChanges();
                MessageBox.Show("Them thanh cong", "Thong bao");
                hienthi();
            } 
            else
            {
                MessageBox.Show("Vien chuc da ton tai", "Thong bao");
            }    
                
        }

        private void buttim_Click(object sender, RoutedEventArgs e)
        {
            var data2=from vc3 in db.VienChucs
        }
    }
}
