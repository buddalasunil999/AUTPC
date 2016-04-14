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
            Problem1();

            Console.ReadKey();
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
    }
}
