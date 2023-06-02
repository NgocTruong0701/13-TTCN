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
using System.Windows.Shapes;
using ontap.model;
namespace ontap
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _12Context ds = new _12Context();
            var query = from sp in ds.SanPhams
                        where sp.MaSp == "1"
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.MaLoai,
                            sp.DonGia,
                            sp.SoLuong,
                            ThanhTien = sp.SoLuong * sp.DonGia
                        };
            dgtk.ItemsSource = query.ToList();
        }
    }
}
