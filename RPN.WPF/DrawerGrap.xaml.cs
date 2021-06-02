using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RPN.WPF
{
    /// <summary>
    /// Логика взаимодействия для DrawerGrap.xaml
    /// </summary>
    public partial class DrawerGrap : Window
    {
        public DrawerGrap()
        {
            InitializeComponent();
        }

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvas.Children.Clear();
            IDrawer();
        }

        private void IDrawer()
        {
            Line vertL = new Line();
            vertL.X1 = canvas.ActualWidth / 2;
            vertL.X2 = canvas.ActualWidth / 2;
            vertL.Y1 = 0;
            vertL.Y2 = Convert.ToInt32(canvas.ActualHeight);
            vertL.Stroke = Brushes.Black;
            canvas.Children.Add(vertL);

            Line horL = new Line();
            horL.X1 = 0;
            horL.X2 = Convert.ToInt32(canvas.ActualWidth);
            horL.Y1 = Convert.ToInt32(canvas.ActualHeight) / 2;
            horL.Y2 = Convert.ToInt32(canvas.ActualHeight) / 2;
            horL.Stroke = Brushes.Black;
            canvas.Children.Add(horL);

            Polyline vertArr = new Polyline();
            vertArr.Points = new PointCollection();
            vertArr.Points.Add(new Point(Convert.ToInt32(canvas.ActualWidth) / 2 - 5, 5));
            vertArr.Points.Add(new Point(Convert.ToInt32(canvas.ActualWidth) / 2, 0));
            vertArr.Points.Add(new Point(Convert.ToInt32(canvas.ActualWidth) / 2 + 5, 5));
            vertArr.Stroke = Brushes.Black;
            canvas.Children.Add(vertArr);

            Polyline horArr = new Polyline();
            horArr.Points = new PointCollection();
            horArr.Points.Add(new Point(Convert.ToInt32(canvas.ActualWidth) - 5, Convert.ToInt32(canvas.ActualHeight) / 2 - 5));
            horArr.Points.Add(new Point(Convert.ToInt32(canvas.ActualWidth), Convert.ToInt32(canvas.ActualHeight) / 2));
            horArr.Points.Add(new Point(Convert.ToInt32(canvas.ActualWidth) - 5, Convert.ToInt32(canvas.ActualHeight) / 2 + 5));
            horArr.Stroke = Brushes.Black;
            canvas.Children.Add(horArr);
        }
        private void btGoCalc_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
