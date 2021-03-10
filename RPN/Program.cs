using System;

namespace RPN
{
    class Program
    {
        static void Main(string[] args)//(1/2+0.5)+2*((4-1)/3)
        {
            //string expression = "(1/2+0.5)+2*(4-1/2)";
            double result = Function.Calculate("(1/2+0,5)+2*((4-1)/3)");
            Console.WriteLine(result);
        }
    }
}
