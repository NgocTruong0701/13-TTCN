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
using test4.Models;
namespace test4
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
        De2Context db=new De2Context();
        private void hienthi()
        {
            var data = from bn in db.BenhNhans
                       orderby bn.SongayNv
                       select new
                       {
                           bn.Mabn,
                           bn.Hoten,
                           bn.Makhoa,
                           bn.SongayNv,
                           vienphi = bn.SongayNv * 600000
                       };
            dsbn.ItemsSource = data.ToList();
        }
        private void hienthicb()
        {
            var data1 = from bn1 in db.KhoaKhams
                        select bn1;
            cbokk.ItemsSource = data1.ToList();
            
            cbokk.DisplayMemberPath = "Tenkhoa";
            cbokk.SelectedValuePath = "Makhoa";
            cbokk.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
            hienthicb();
        }

        private void butthem_Click(object sender, RoutedEventArgs e)
        {
            var them = db.BenhNhans.SingleOrDefault(t => t.Mabn.Equals(txtmbn.Text));
            if (them == null)
            {
                BenhNhan m= new BenhNhan();
                m.Mabn = txtmbn.Text;
                m.Hoten = txtht.Text;
                m.Makhoa= ((KhoaKham)cbokk.SelectedItem).Makhoa;
                m.SongayNv=int.Parse(txtsnnv.Text);
                db.BenhNhans.Add(m);
                db.SaveChanges();
                MessageBox.Show("Them thanh cong", "Thong bao");
                hienthi();
            }
            else
            {
                MessageBox.Show("Benh nhan da ton tai");
            }    
        }

        private void buttim_Click(object sender, RoutedEventArgs e)
        {
            var tim=db.BenhNhans.SingleOrDefault(t=>t.Hoten.Equals(txtht.Text));
            if (tim == null)
            {
                MessageBox.Show("Khong tim thay", "Thong bao");
            }  
            else
            {
                var tk = from s in db.BenhNhans
                         where s.Hoten == txtht.Text
                         select new
                         {
                             s.Mabn,
                             s.Hoten,
                             s.SongayNv,
                             s.Makhoa,
                             vienphi = s.SongayNv * 600000
                         };
                dsbn.ItemsSource = tk.ToList();
            }            
        }

        private void butxoa_Click(object sender, RoutedEventArgs e)
        {
            var xoa=db.BenhNhans.SingleOrDefault(t=>t.Mabn.Equals(txtmbn.Text));
            if (xoa != null)
            {
                BenhNhan m = new BenhNhan();
                m.Mabn = "";
                m.Hoten = "";
                m.Makhoa = "";
                m.SongayNv = 0;
                db.BenhNhans.Remove(m);
                db.SaveChanges();
                MessageBox.Show("Xoa thanh cong", "Thong bao");
                hienthi();
            }
            else
            {
                MessageBox.Show("Khong the xoa tiep", "Thong bao");
            }    
        }
    }
}
