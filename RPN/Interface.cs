using System;
using System.Collections.Generic;
using System.Text;

namespace RPN
{
    public class Interface
    {
        public static void NewMain(string expression, int minRange, int maxRange, int step)
        {
            List<string> newExsaple = (CreateRPN.Parse(expression));

            for (int i = minRange; i <= maxRange; i = i + step)
            {
                List<string> rpn = new List<string>();
                rpn.AddRange(newExsaple.ToArray());


                for (int j = 0; j < newExsaple.Count; j++)
                {
                    if (newExsaple[j] == "x")
                        rpn[j] = $"{i}";

                }
                Console.WriteLine(Function.Calculate(rpn));
            }
        }
    }
}
