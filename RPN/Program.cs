using System;

namespace RPN
{
    class Program
    {
        static void Main(string[] args)//(1/2+0.5)+2*((4-1)/3)
        {
            int minRange = 1,maxRange = 10, step = 1;

            string expression = "(1/2+0,5)+2*((4-1)/3)+x";

            for (int i = minRange; i <= maxRange; i = i + step)
            {
               string newExsample = expression.Replace("x", $"{i}");
                Console.WriteLine(Function.Calculate(newExsample));
            }
        }

        //static void newMain(int minRange,int maxRange,int step)
        //{
        //    string exsapmle = "(1/2+0,5)+2*((4-1)/3)+x";

        //    for (int i = minRange; i <= maxRange; i = i + step)
        //    {
        //        string newExsample = exsapmle.Replace("x", $"{i}");
        //        Console.WriteLine(Function.Calculate(newExsample));
        //    }
        //}
    }
}
