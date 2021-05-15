using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace RPN.WPF
{
    public partial class MainWindow : Window
    {
        private BindingList<Model> tabs;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void dgTab_Loaded(object sender, RoutedEventArgs e)
        {
            tabs = new BindingList<Model>()
            {
                new Model(){Range = 1,Function = "1+x", Result = "2"},
                new Model(){Range = 2,Function = "1+x", Result = "3"}
            };

            dgTab.ItemsSource = tabs;
        }

    }
}
