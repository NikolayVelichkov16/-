using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static string convertNum(double num)
        {
            return num.ToString(CultureInfo.InvariantCulture);
        }
        static double parseNum(string num)
        {
            return double.Parse(num, NumberStyles.Float, CultureInfo.InvariantCulture);
        }
        static string calcNoBrackets(string exp)
        {
            string operands = "^*/+-";
            foreach (char op in operands)
            {
                int idx = 0;
                do
                {
                    idx = exp.IndexOf(op);
                    if (idx >= 0)
                    {
                        int start = idx - 1;
                        while (start >= 0 && operands.IndexOf(exp[start]) == -1)
                            start--;
                        start++;

                        int end = idx + 1;
                        while (end < exp.Length && operands.IndexOf(exp[end]) == -1)
                            end++;
                        end--;

                        string left = exp.Substring(start, idx - start).Trim();
                        string right = exp.Substring(idx + 1, end - idx).Trim();

                        string result = "";
                        switch (op)
                        {
                            case '^':
                                result = convertNum(Math.Pow(parseNum(left), parseNum(right)));
                                break;
                            case '+':
                                result = convertNum(parseNum(left) + parseNum(right));
                                break;
                            case '-':
                                result = convertNum(parseNum(left) - parseNum(right));
                                break;
                            case '*':
                                result = convertNum(parseNum(left) * parseNum(right));
                                break;
                            case '/':
                                result = convertNum(parseNum(left) / parseNum(right));
                                break;
                        }
                        exp = exp.Substring(0, start) + result + exp.Substring(end + 1);
                    }
                } while (idx >= 0);
            }

            return exp;
        }
        static string calc(string exp)
        {
            int closeIdx = -1;
            // find closing bracket
            do
            {
                closeIdx = exp.IndexOf(')');
                if (closeIdx >= 0)
                {
                    // find the opening one
                    int openIdx = exp.Substring(0, closeIdx).LastIndexOf('(');

                    string s = exp.Substring(openIdx + 1, closeIdx - openIdx - 1);
                    s = calc(s);
                    exp = exp.Substring(0, openIdx) + s + exp.Substring(closeIdx + 1);
                }
            } while (closeIdx >= 0);
            return calcNoBrackets(exp);
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(calc(input));

            Console.ReadKey();
        }
    }
}
