using System;
using System.Collections.Generic;
using System.Text;

namespace RPN
{
    public class Interface
    {
        public static void NewMain(string expression, int minRange, int maxRange, int step)
        {
           

            for (int i = minRange; i <= maxRange; i = i + step)
            {
                string newExsample = expression.Replace("x", $"{i}");
                Console.WriteLine(Function.Calculate(newExsample));
            }
        }
    }
}
