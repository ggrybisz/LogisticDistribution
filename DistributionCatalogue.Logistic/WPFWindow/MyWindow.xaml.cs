using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DistributionCatalogue.Logistic.WPFWindow
{
    /// <summary>
    /// Interaction logic for MyWindow.xaml
    /// </summary>
    public partial class MyWindow : Window
    {
        public MyWindow()
        {
            InitializeComponent();
            this.DataContext = new MyWindowViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MyWindowViewModel)this.DataContext).Calculate();
        }
    }
}
