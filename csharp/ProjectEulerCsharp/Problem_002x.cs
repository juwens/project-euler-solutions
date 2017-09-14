using ConsoleApplication1.Contract;
using ConsoleApplication1.Math;
using ConsoleApplication1.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MyMath = ConsoleApplication1.Math;

namespace ConsoleApplication1
{
    class Problem_0020_factorial_sum : IRunnableProblem
    {
        public string Run()
        {
            // python: sum = 0; for c in str(math.factorial(100)): sum += int(c)
            var sum = MyMath.MyMath
                    .Factorial(100)
                    .ToString()
                    .Select(char.GetNumericValue)
                    .Sum();
            Console.WriteLine("sum: " + sum);

            return sum.ToString();
        }
    }

    class Problem_0021_amicabla_numbers : IRunnableProblem
    {

        /*
         * Let d(n) be defined as the sum of proper divisors of n(numbers less than n which divide evenly into n).
         * If d(a) = b and d(b) = a, where a != b, then a and b are amicable pair and each of a and b are called amicable 
         * numbers.
         * 
         * For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 22, 44, 55, 110;
         * therefore d(220) = 284.
         * The proper divisors of 284 are 1, 2, 4, 71 and 142;
         * so d(284) = 220
         *
         * Evaluate the sum of all amicable numbers under 10000
         */
        public string Run()
        {
            var amicalbe_nrs = new HashSet<int>();

            for (int a = 1; a < 10000; a++)
            {
                int b = (int)MyMath.Divisors.GetProperDivisors(a).Sum();
                int a2 = (int)MyMath.Divisors.GetProperDivisors(b).Sum();

                if (a == a2 && a != b)
                {
                    Console.WriteLine("a: {0}, b: {1}", a, b);
                    if (!amicalbe_nrs.Contains(a))
                    {
                        amicalbe_nrs.Add(a);
                    }
                    if (!amicalbe_nrs.Contains(b))
                    {
                        amicalbe_nrs.Add(b);
                    }
                }
            }

            //amicalbe_nrs.Sort();
            Console.WriteLine("nrs: {0}", String.Join(", ", amicalbe_nrs.Select(x => x.ToString()).ToArray()));

            return amicalbe_nrs.Sum().ToString();
        }
    }

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

    class Problem_0023_non_abundant_numbers : IRunnableProblem
    {
        public string Run()
        {
            const int max_number = 28123;
            var abundant_numbers = new List<int>(7000);

            for (int i = 2; i <= max_number; i += 1)
            {
                var divisors_sum = MyMath.Divisors.GetProperDivisorsSum(i);

                if (divisors_sum > i) // i is abundant
                {
                    abundant_numbers.Add(i);
                }
            }

            // faster than HashSet<int>: 1000ms
            var abundand_sums = new bool[1000 * 1000];

            var abundandNumbersArray = abundant_numbers.ToArray();
            // faster than foreach or LINQ: 200-300ms
            for (int a = 0; a < abundandNumbersArray.Length; a++)
            {
                for (int b = 0; b < abundandNumbersArray.Length / 2; b++)
                {
                    var sum = abundandNumbersArray[a] + abundandNumbersArray[b];
                    abundand_sums[sum] = true;
                }
            }

            var not_in_abundand_sums = new List<int>();
            for (int i = 1; i <= max_number; i++)
            {
                if (!abundand_sums[i])
                {
                    not_in_abundand_sums.Add(i);
                }
            }
            Console.WriteLine(String.Join(",", not_in_abundand_sums));

            var res = not_in_abundand_sums.Sum();
            return res.ToString();
        }
    }

    [TestClass]
    public class Test_002x : TestBase
    {
        [TestMethod]
        public async Task Test_Problem_0020()
        {
            await AssertAnswerAsync(new Problem_0020_factorial_sum(), "648");
        }

        [TestMethod]
        public async Task Test_Problem_0021()
        {
            await AssertAnswerAsync(new Problem_0021_amicabla_numbers(), "31626");
        }

        [TestMethod]
        public async Task Test_Problem_0022()
        {
            await AssertAnswerAsync(new Problem_0022_names_score(), "871198282");
        }

        [TestMethod]
        public async Task Test_Problem_0023()
        {
            await AssertAnswerAsync(new Problem_0023_non_abundant_numbers(), "4179871");
        }
    }
}
