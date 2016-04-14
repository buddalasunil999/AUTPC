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
            //string[] input = { "18F B", "34B O", "34B R", "09H C", "18F L", "00A X" };
            //Console.WriteLine(new FlightProcessor().GetUpgrades(input));

            //ParseRFile();
            //FizzBuzzProblem();

            //Console.WriteLine(Regex.IsMatch("Sunil likes native", @"^([SA]u{0,1}nil|Kavi)"));

            Console.ReadKey();
        }

        private static void FizzBuzzProblem()
        {
            int input = Convert.ToInt32(Console.ReadLine());

            while (input != 0)
            {
                bool divisibleBy3 = input % 3 == 0;
                bool divisibleBy5 = input % 5 == 0;

                if (divisibleBy3 && divisibleBy5)
                {
                    Console.WriteLine("Fizz Buzz");
                }
                else if (divisibleBy3)
                {
                    Console.WriteLine("Fizz");
                }
                else if (divisibleBy5)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(input);
                }

                input = Convert.ToInt32(Console.ReadLine());
            }
        }

        private static void Problem2()
        {
            string input = Console.ReadLine();
            while (input != "#")
            {
                input = Console.ReadLine();
                Console.WriteLine(CheckResult(input) ? "Correct" : "InCorrect");
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

        private static void Problem1()
        {
            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                string item = Console.ReadLine();
                if (item.Length < 100)
                    Console.WriteLine("Hello {0}!", item);
            }
        }

        private static void ParseRFile()
        {
            string scriptPath = @"C:\OnlineDataLab\Scripts\bivariate_cat_cat.R";
            string script = string.Empty;

            string line;
            StreamReader file = new StreamReader(scriptPath);
            while ((line = file.ReadLine()) != null)
            {
                if (!Regex.IsMatch(line, @"[#].*"))
                {
                    if (Regex.IsMatch(line, @"[^\{\}]$"))
                    {
                        line = line + ";";
                    }

                    script += line;
                }
            }

            Console.WriteLine(script.Replace("\t", ""));

            string commentsRemoved = Regex.Replace(script, @"[#].*", "");
            Console.WriteLine(commentsRemoved);

            string output = Regex.Replace(commentsRemoved, @"[\{]\w\s\n*[\}]", x => x.Value + ";");
            Console.WriteLine(output);
        }
    }

    public class FlightProcessor
    {
        public int GetUpgrades(string[] input)
        {
            Dictionary<string, int> output = new Dictionary<string, int>();

            foreach (var item in input)
            {
                string[] seatVal = item.Split(' ');
                if (output.ContainsKey(seatVal[0]))
                {
                    output[seatVal[0]] += GetCodeValue(seatVal[1]);
                }
                else
                {
                    output.Add(seatVal[0], GetCodeValue(seatVal[1]));
                }
            }

            return output.Count(x => x.Value >= 200);
        }

        private int GetCodeValue(string code)
        {
            switch (code)
            {
                case "L":
                    return 100;
                case "S":
                    return 150;
                case "B":
                    return 120;
                case "N":
                    return 40;
                case "C":
                    return 160;
                case "D":
                    return 100;
                case "R":
                    return 100;
                case "O":
                    return 100;
                default:
                    return 0;
            }
        }
    }
}
