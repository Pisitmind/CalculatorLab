using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {
        public string RPNProcess(string str)
        {
            string result = "Zero";
            Stack Numlist = new Stack();
            string[] parts = str.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    Numlist.Push(parts[i]);
                }
                if (isOperator(parts[i]))
                {
                    string first = Numlist.Pop().ToString();
                    string secound = Numlist.Pop().ToString();
                    result = calculate(parts[i], first, secound);
                    Numlist.Push(result);
                    

                }
                //


            }
            return result;
        }
    }
}