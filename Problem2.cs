using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                input = Console.ReadLine();
                Console.WriteLine(CheckResult(input) ? "Correct" : "Wrong");
            };
        }

        private static bool CheckResult(string expression)
        {
            string oprt = Regex.Match(expression, @"[\*+-//]").Value;
            MatchCollection coll = Regex.Matches(expression, @"\d");

            int first = Convert.ToInt32(coll[0].Value);
            int second = Convert.ToInt32(coll[1].Value);
            int third = Convert.ToInt32(coll[2].Value);

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
