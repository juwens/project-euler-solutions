using ConsoleApplication1.Contract;
using System;
using System.IO;
using System.Linq;

namespace ConsoleApplication1.Problems_002x
{
    class Problem_0022_names_score : IRunnableProblem
    {

        public string Run()
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            var lines = File
                .ReadAllText(@"Data/p22_names.txt")
                .Split(',')
                .Select(line => line.Replace("\"", ""))
                .OfType<string>()
                .ToList();

            lines.Sort();

            //Console.WriteLine(String.Join("\n", lines));

            int sum = 0;
            int line_nr = 0;
            foreach (string line in lines)
            {
                line_nr++;

                int line_sum = 0;
                foreach (char c in line)
                {
                    int char_value = Array.IndexOf(alphabet, c) + 1;
                    line_sum += char_value;
                }
                int line_product = line_nr * line_sum;
                sum += line_product;
            }

            Console.WriteLine("sum: " + sum);

            return sum.ToString();
        }
    }
}
