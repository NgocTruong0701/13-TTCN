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

namespace ontaptx2
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
        private List<Class1> dsnv = new List<Class1>();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Class1 nv1 = new Class1("dat", "dat", "20/2/2002");
            dsnv.Add(nv1);
            dgDs.ItemsSource = null;
            dgDs.ItemsSource = dsnv;
            dsnv.ToList();
        }
    }
}
