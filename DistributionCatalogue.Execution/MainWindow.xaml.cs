using DistributionCatalogue.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DistributionCatalogue.Execution.cs
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Will be changed to use reflection to find dlls with IDistributionFormEntry implemented
            //For testing purpose use standard way
            var ec = new DistributionCatalogue.Logistic.MyEntryClass();
            this.lbDistributionList.Items.Add(ec);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ec = this.lbDistributionList.SelectedItem as IDistributionFormEntry;
            if (ec == null)
            {
                MessageBox.Show("Sth gone wrong!");
                return;
            }

            if (ec.WindowsFormsForm == null && ec.WPFWindow == null)
            {
                MessageBox.Show("No WPF or WF implementation provided. Nothing to do here!");
                return;
            }

            if (ec.WindowsFormsForm != null && ec.WPFWindow != null)
            {
                MessageBox.Show("both WPF and WF implementation provided!");
                return;
            }

            if (ec.WindowsFormsForm != null)
            {
                var form = ec.WindowsFormsForm;
                WindowInteropHelper helper = new WindowInteropHelper(this);
                form.ShowDialog(new Win32WindowHandle(helper.Handle));
            }
            else
            {
                var window = ec.WPFWindow;
                window.ShowDialog();
            }
        }

        private void lbDistributionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.lbDistributionList.SelectedItem == null || this.lbDistributionList.SelectedIndex < 0)
                this.btExe.IsEnabled = false;
            else
                this.btExe.IsEnabled = true;
        }
    }
}
