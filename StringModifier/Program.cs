using System;
using System.Text.RegularExpressions;

namespace StringModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "blBLAAA  df(30) 45";

            Regex myRegex = new Regex(@"\(([^\)]+)\)");
            string output = myRegex.Replace(input, "");
            output = Regex.Replace(output, @"\s+", "");
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
