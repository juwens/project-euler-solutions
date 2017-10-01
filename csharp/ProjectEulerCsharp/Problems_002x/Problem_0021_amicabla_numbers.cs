using ConsoleApplication1.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using MyMath = ConsoleApplication1.Math;

namespace ConsoleApplication1.Problems_002x
{
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
}
