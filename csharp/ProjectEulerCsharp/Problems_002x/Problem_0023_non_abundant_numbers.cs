using ConsoleApplication1.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using MyMath = ConsoleApplication1.Math;

namespace ConsoleApplication1.Problems_002x
{
    class Problem_0023_non_abundant_numbers : IRunnableProblem
    {
        public string Run()
        {
            const int max_number = 28_123;
            var abundant_numbers = new List<int>(7_000);

            for (int i = 2; i <= max_number; i += 1)
            {
                var divisors_sum = MyMath.Divisors.GetProperDivisorsSum(i);

                if (divisors_sum > i) // i is abundant
                {
                    abundant_numbers.Add(i);
                }
            }

            // faster than HashSet<int>: 1000ms
            var abundand_sums = new bool[1_000_000];

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
}
