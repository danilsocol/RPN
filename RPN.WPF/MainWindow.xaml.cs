using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RPN.Logic;
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
        List<RowInTabl> Rows = new List<RowInTabl>();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int minRange = Convert.ToInt32(tbMinRange.Text);
            int maxRange = Convert.ToInt32(tbMaxRange.Text);
            int step = Convert.ToInt32(tbStep.Text);

            string expression = Convert.ToString(tbExpression.Text);

            List<string> newExsaple = (CreateRPN.Parse(expression));
            List<string> RPN = new List<string>();

            string rpnStr = "";
            for (int i = minRange; i <= maxRange; i+= step)
            {
                RPN = newExsaple.GetRange(0, newExsaple.Count);

                for (int j = 0; j < RPN.Count; j++)
                {
                    if (newExsaple[j] == "x")
                        RPN[j] = $"{i}";
                }

                rpnStr = RPN[0];
                for (int k = 1; k < RPN.Count; k++)
                {
                    rpnStr += $",{RPN[k]}";
                }

                Rows.Add(new RowInTabl(){RPN = rpnStr, step= i,res= Function.Calculate(RPN) });
            }

           dgTab.ItemsSource = Rows;
        }

        
    }
}
