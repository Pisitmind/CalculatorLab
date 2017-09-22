using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            if (str == null || str == "") return "E";
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    if (token.Substring(0, 1) == "+") return "E";
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?

                    try
                    {
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();

                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }

                    result = calculate(token, firstOperand, secondOperand, 6);
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
                else if (token.Length > 1)
                {
                    return "E";
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            try
            {
                result = rpnStack.Pop();
            }
            catch (InvalidOperationException)
            {
                return "E";
            }
            if (rpnStack.Count > 0) return "E";
            result = Convert.ToDouble(result).ToString();
            return result;
        }
    }
}
