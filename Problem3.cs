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
			string input = Console.ReadLine();
			List<string> lstSeats = new List<string>();
			while(input != "00A X")
			{
				lstSeats.Add(input);
				input = Console.ReadLine();
			}
			
			new FlightProcessor().GetUpgrades(lstSeats);
        }
    }

    public class FlightProcessor
    {
        public void GetUpgrades(List<string> input)
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

            output.Select(x => x.Value >= 200);
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
