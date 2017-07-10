using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class problem_0020_factorial_sum : IProjectEulerTestableProblem
    {
        public string Run()
        {
            // python: sum = 0; for c in str(math.factorial(100)): sum += int(c)
            var sum = MyMath
                    .factorial(100)
                    .ToString()
                    .Select(char.GetNumericValue)
                    .Sum();
            Console.WriteLine("sum: " + sum);

            return sum.ToString();
        }
    }

    class problem_0021_amicabla_numbers : IProjectEulerTestableProblem
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
            HashSet<int> amicalbe_nrs = new HashSet<int>();

            for (int a = 1; a < 10000; a++)
            {
                int b = (int)MyMath.getProperDivisors(a).Sum();
                int b_dividers_sum = (int)MyMath.getProperDivisors(b).Sum();

                if (a == b_dividers_sum && a != b)
                {
                    Console.WriteLine("a: {0}, b: {1}", a, b);
                    if (!amicalbe_nrs.Contains(a))
                    {
                        amicalbe_nrs.Add(a);
                        amicalbe_nrs.Add(b);
                    }

                }
            }

            Console.WriteLine("sum: {0}", amicalbe_nrs.Sum());
            //amicalbe_nrs.Sort();
            Console.WriteLine("nrs: {0}", String.Join(", ", amicalbe_nrs.Select(x => x.ToString()).ToArray()));

            return amicalbe_nrs.Sum().ToString();
        }
    }

    class problem_0022_names_score : IProjectEulerTestableProblem
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

    class problem_0023_non_abundant_numbers : IProjectEulerTestableProblem
    {
        private string toString(int[] l)
        {
            var l2 = l.Select(x => x.ToString()).ToList();
            l2.Sort();

            return String.Join(",", l2);
        }

        private readonly int max_number = 28123;
        public string Run()
        {
            // braucht im Moment 5GB Arbeitsspeicher !!!

            var abundant_numbers = new List<int>();

            for (int i = 1; i <= max_number; i++)
            {
                var divisors = MyMath.getProperDivisors(i);
                var divisors_sum = divisors.Sum();

                if (divisors_sum > i) // i is abundant
                {
                    abundant_numbers.Add(i);
                }
            }

            //var tmp = new List<int>(abundant_numbers);
            //tmp.Sort();
            //Console.WriteLine(String.Join(",", tmp));
            //tmp = null;

            var doubled_abundand_numbers = new List<int>(abundant_numbers);
            doubled_abundand_numbers.AddRange(abundant_numbers);

            var all_abundant_pairs = MyMath.Combinations<int>(doubled_abundand_numbers, 2);
            var abundand_sums = new HashSet<int>(all_abundant_pairs.Select(x => x.Sum()));

            var sum = 0;
            var not_in_abundand_sums = new List<int>();
            for (int i = 1; i <= max_number; i++)
            {
                if (!abundand_sums.Contains(i))
                {
                    not_in_abundand_sums.Add(i);
                    //sum += i;
                    //Console.WriteLine(i);
                    //Console.WriteLine(sum);
                }
            }
            Console.WriteLine(String.Join(",", not_in_abundand_sums));
            sum = not_in_abundand_sums.Sum();

            return sum.ToString();
        }
    }

    [TestClass]
    public class Test_002x : TestProjectEulerBase
    {
        [TestMethod]
        public async Task Test_Problem_0020()
        {
            await AssertAnswerAsync(new problem_0020_factorial_sum(), "648");
        }

        [TestMethod]
        public async Task Test_Problem_0021()
        {
            await AssertAnswerAsync(new problem_0021_amicabla_numbers(), "31626");
        }

        [TestMethod]
        public async Task Test_Problem_0022()
        {
            await AssertAnswerAsync(new problem_0022_names_score(), "871198282");
        }

        [TestMethod]
        public async Task Test_Problem_0023()
        {
            await AssertAnswerAsync(new problem_0023_non_abundant_numbers(), "4179871");
        }
    }
}
