using System;
using System.Collections.Generic;

namespace RPN
{
    class Program
    {
        static void Main(string[] args)//(1/2+0.5)+2*((4-1)/3)
        {
            int minRange = 1,maxRange = 10, step = 1;

            string expression = "(1/2+0,5)+2*((4-1)/x)";

            List<string> newExsaple = (CreateRPN.Parse(expression));

            for (int i = minRange; i <= maxRange; i = i + step)
            {
                
                List<string> rpn = new List<string>();
                rpn.AddRange(newExsaple.ToArray());
                string strTable = $" {i} |";

                for (int j = 0; j < newExsaple.Count; j++)
                {
                    if(newExsaple[j]=="x")
                        rpn[j] = $"{i}";
                    strTable += $"{rpn[j]},";
                }
                strTable += $" | {Function.Calculate(rpn)}";
                DrawerTableConsole.DrawerTable(strTable);
            }


        }

    }
}
