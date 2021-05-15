using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace RPN.Tets
{
    public class Tests
    {
        [TestCase( "(1/2+0,5)+2*((4-1)/3)", ExpectedResult = 13)]

        public int CreateRPN_Test(string expression)
        {
            return (CreateRPN.Parse(expression)).Count;
        }

        //[TestCase("(1/2+0,5)+2*((4-1)/3)", ExpectedResult = 3)]

        //public double Function_Test(string expression)
        //{
        //    return Function.Calculate(expression);
        //}
    }
}