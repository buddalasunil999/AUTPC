using System;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem2();
        }

        private static void Problem2()
        {
            string input = Console.ReadLine();
            while (input != "#")
            {                
                Console.WriteLine(CheckResult(input) ? "Correct" : "Wrong");
                input = Console.ReadLine();
            };
        }

        private static bool CheckResult(string expression)
        {
            string[] operands = expression.Split('=');
            string oprt = Regex.Match(expression, @"[\*+-//]").Value;
            string[] values = operands[0].Split(oprt.ToCharArray());

            int first = Convert.ToInt32(values[0]);
            int second = Convert.ToInt32(values[1]);
            int third = Convert.ToInt32(operands[1]);

            int result = GetResult(first, second, oprt);

            return result == third;
        }

        private static int GetResult(int first, int second, string oprt)
        {
            switch (oprt)
            {
                case "+":
                    return first + second;
                case "-":
                    return first - second;
                case "*":
                    return first * second;
                case "/":
                    return first / second;
                default:
                    return 0;
            }
        }
    }
}
