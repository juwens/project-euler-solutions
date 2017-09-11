using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Math
{
    class Divisors
    {
        // All Divisors including N
        public static IEnumerable<long> GetDivisors(long N)
        {
            foreach (var i in GetProperDivisors(N))
            {
                yield return i;
            }

            yield return N;

        }

        // All Divisors excluding N
        public static IEnumerable<long> GetProperDivisors(long N)
        {
            for (long i = 1; i * 2 <= N; i++)
            {
                if (N % i == 0)
                {
                    yield return i;
                }
            }
        }

        /**
         * 
         * Example 220:
         * - Prime Factors: 2^2, 5^1, 11^1
         * - divisors: { 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110, 220 }
         */
        private static long[] GetAllDivisorsViaPrimeFactorization(long N, bool excludeN = false)
        {
            var prime_facs = PrimefactorCalculator.getInstance().getPrimeFactors(N);

            var divisors = new HashSet<long>(); // prime_facs.Keys.ToList();
            divisors.Add(1);

            /*
             * Alle Variationen benutzen, 
             * zB: (2^2, 5^1, 11^1) == 2 * 2 * 5 * 11
             */
            foreach (var pf in prime_facs)
            {
                for (long exp = 1; exp <= pf.Value; exp++)
                {
                    divisors.Add(pf.Key);
                }

            }



            if (!divisors.Contains(N))
            {
                divisors.Add(N);
            }

            if (excludeN && divisors.Contains(N))
            {
                divisors.Remove(N);
            }


            return divisors.ToArray();
        }
    }
}
