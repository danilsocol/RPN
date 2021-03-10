using System;
using System.Collections.Generic;
using System.Text;

namespace RPN
{
    public class Function
    {
        public static double Calculate(string expressionString)  //string expression = "(1/2+0.5)+2*(4-1/2)";
        {
            List<string> rpn = CreateRPN.Parse(expressionString);
            return ChooseOperation(rpn);
        }

        static double ChooseOperation(List<string> rpn)
        {

            for (int i =0; i < rpn.Count; i++)
            {
                if (rpn[i] == "+") i = Summation(rpn, i);
                else if (rpn[i] == "-") i = Subtraction(rpn, i);
                else if (rpn[i] == "/") i = Division(rpn, i);
                else if (rpn[i] == "*") i = Multiplication(rpn, i);
            }

            return Convert.ToDouble(rpn[0]);
        }

        static int Summation(List<string> rpn,int i)
        {
            double result = Convert.ToDouble(rpn[i - 2]) + Convert.ToDouble(rpn[i - 1]);
            rpn.RemoveAt(i);
            rpn.RemoveAt(i - 1);
            rpn.RemoveAt(i - 2);
            i -= 2;
            rpn.Insert(i, Convert.ToString(result));
            return i ;
        }
        static int Subtraction(List<string> rpn, int i)
        {
            double result = Convert.ToDouble(rpn[i - 2]) - Convert.ToDouble(rpn[i - 1]);
            rpn.RemoveAt(i);
            rpn.RemoveAt(i - 1);
            rpn.RemoveAt(i - 2);
            i -= 2;
            rpn.Insert(i, Convert.ToString(result));
            return i;
        }
        static int Division(List<string> rpn, int i)
        {
            double result = Convert.ToDouble(rpn[i - 2]) / Convert.ToDouble(rpn[i - 1]);
            rpn.RemoveAt(i);
            rpn.RemoveAt(i - 1);
            rpn.RemoveAt(i - 2);
            i -= 2;
            rpn.Insert(i, Convert.ToString(result));
            return i;
        }
        static int Multiplication(List<string> rpn, int i)
        {
            double result = Convert.ToDouble(rpn[i - 2]) * Convert.ToDouble(rpn[i - 1]);
            rpn.RemoveAt(i);
            rpn.RemoveAt(i - 1);
            rpn.RemoveAt(i - 2);
            i -= 2;
            rpn.Insert(i, Convert.ToString(result));
            return i;
        }
    }
}
