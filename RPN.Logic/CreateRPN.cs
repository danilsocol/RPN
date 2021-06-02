using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RPN
{
    public class CreateRPN
    {
        public static List<string> Parse(string expressionString)
        {
            List<string> expression = SplitExpression(expressionString);
            List<string> rpn = new List<string>();
            ToRPN(expression, rpn,0);
            return rpn;
        }

        static List<string> SplitExpression(string expressionString)
        {
            List<string> expression = new List<string>();

            for(int i = 0; i<expressionString.Length;)
            {
                if (char.IsDigit(expressionString[i]) || expressionString[i]=='x')
                {
                    i = ReadNumber(expressionString, expression, i);
                }
                else if (char.IsWhiteSpace(expressionString[i]))
                {
                    i++;
                }
                else if (expressionString[i] == '(' || expressionString[i] == ')')
                {
                    expression.Add(Convert.ToString(expressionString[i]));
                    i++;
                }
                else if (!(expressionString[i] == '(') && !(expressionString[i] == ')')&& !(expressionString[i] == ','))
                {
                    i = ReadOperation(expressionString, expression, i);
                }
            }

            return expression;
        }

        static int ReadNumber(string expressionString, List<string> expression, int i)
        {
            string num = "";

            while(i< expressionString.Length && (char.IsDigit(expressionString[i])|| expressionString[i]== ','|| expressionString[i] == 'x'))
            {
                num += expressionString[i];
                i++;
            }
            expression.Add(num);
            return i;
        }

        static int ReadOperation(string expressionString, List<string> expression, int i)
        {
            string operation = "";

            while (i < expressionString.Length && !(char.IsDigit(expressionString[i])) && !(expressionString[i] == '(') && !(expressionString[i] == ')') && !(expressionString[i] == ',') && !(expressionString[i] == 'x'))
            {
                operation += expressionString[i];
                i++;
            }

            switch (operation)
            {
                case "+": expression.Add("+"); break;
                case "-": expression.Add("-"); break;
                case "/": expression.Add("/"); break;
                case "*": expression.Add("*"); break;
                case "log": expression.Add("log"); break;
                default: throw new Exception("Неизвестная операция");
            }

            return i;
        }

        static void ToRPN(List<string> expression, List<string> rpn, int i)
        {
            List<string> LostOperation = new List<string>();

            if (expression[i] != "(")
                rpn.Add(expression[i++]);

            for (; i < expression.Count; i++)
            {
                if(expression[i] == "(")
                {
                    List<string> partExpressionInBrackets = new List<string>();
                    List<string> partRPNInBreckets = new List<string>();
                    i = ParseExpressionInBrackets( expression, partExpressionInBrackets, partRPNInBreckets, i);
                    rpn.AddRange(partRPNInBreckets);
                }
                else if (expression[i]=="+"|| expression[i] == "-")
                {
                     ParsePlusOrMinusOperation(expression, rpn, LostOperation, i);
                }
                else if (expression[i] == "*" || expression[i] == "/")
                {
                    i = ParseMultiplyAndDivideOperation(expression, rpn, LostOperation, i);
                }
            }
        }
        static void ParsePlusOrMinusOperation(List<string> expression, List<string> rpn, List<string> LostOperation, int i)
        {
            if (expression[i + 1] != ")" || expression[i + 1] != "(")
                rpn.Add(expression[i + 1]);

            if (i + 2 < expression.Count && expression[i + 2] != "*" && expression[i + 2] != "/")
                rpn.Add(expression[i]);
            else if (i + 2 < expression.Count)
                LostOperation.Add(expression[i]);
            else
                rpn.Add(expression[i]);
        }

        static int ParseMultiplyAndDivideOperation(List<string> expression, List<string> rpn, List<string> LostOperation, int i)
        {
            int j = i;

            if (expression[i + 1] != ")" && expression[i + 1] != "(")
                rpn.Add(expression[i + 1]);

            else if (expression[i + 1] == "(")
            {
                i++;
                List<string> partExpressionInBrackets = new List<string>();
                List<string> partRPNInBreckets = new List<string>();
                i = ParseExpressionInBrackets(expression, partExpressionInBrackets, partRPNInBreckets, i);
                rpn.AddRange(partRPNInBreckets);
            }

            rpn.Add(expression[j]);

            if (j + 2 < expression.Count && expression[j + 2] != "*" && expression[j + 2] != "/")
                rpn.AddRange(LostOperation);

            return i;
        }

        static int ParseExpressionInBrackets(List<string> expression, List<string> partExpressionInBrackets, List<string> partRPNInBreckets, int i)
        {
            int closeBreckets = 0;
            int openBreckets = 1;

            for (; i < expression.Count;)
            {
                i++;

                if (expression[i] == "(")
                    openBreckets++;

                if (expression[i] == ")")
                    closeBreckets++;

                if (closeBreckets == openBreckets)
                    break;

                partExpressionInBrackets.Add(expression[i]);
            }

            ToRPN(partExpressionInBrackets, partRPNInBreckets, 0);

            return i;
        }
         
    }
}
