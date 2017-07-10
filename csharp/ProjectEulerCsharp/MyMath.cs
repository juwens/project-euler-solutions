using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConsoleApplication1
{
    internal static class MyMath
    {
        public static BigInteger factorial(int fac)
        {
            var result = new BigInteger(1);
            for (var i = new BigInteger(fac); i > 0; i--)
            {
                result *= i;
            }
            return result;
        }

        // All Divisors including N
        public static IEnumerable<long> getDivisors(long N)
        {
            foreach (var i in getProperDivisors(N))
            {
                yield return i;
            }

            yield return N;

        }

        // All Divisors excluding N
        public static IEnumerable<long> getProperDivisors(long N)
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
        private static long[] getAllDivisorsViaPrimeFactorization(long N, bool excludeN = false)
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

        /*
         * unsortiertes Ziehen ohne zurücklegen
         * 
         * Bsp:
         * 2 aus ABC
         * A X BC -> AB and AC
         * B X C -> BC
         * 
         * 2 aus ABCD
         * A X BCD -> AB, AC, AD
         * B X CD -> BC, BD
         * C X D -> CD
         */
        public static List<int[]> Combinations<T>(IList<int> ary_in, int k)
        {
            if (k == 1) return ary_in.Select(x => new int[] { x }).ToList();

            int n = ary_in.Count;

            var ary_out = new List<int[]>();
            //int[,] ary_out = new int[n,k];

            if (k <= 0) return ary_out;

            for (int i = 0; i + 1 <= (n - k); i++)
            {
                var to_combine = ary_in[i];
                var to_sub_combine = ary_in.ToList().GetRange(i + 1, n - i - 1);
                var sub_combinations = Combinations<int>(to_sub_combine, k - 1);

                foreach (var sub_comb in sub_combinations)
                {
                    var tmp = new List<int>();
                    tmp.Add(to_combine);
                    tmp.AddRange(sub_comb);
                    ary_out.Add(tmp.ToArray());
                }
            }

            ary_out.Add(ary_in.ToList().GetRange(n - k, k).ToArray());

            return ary_out;
        }

        private static IEnumerable<IEnumerable<T>> Combinations_solution_from_stackoverflow<T>(this IEnumerable<T> elements, int k)
        {
            IEnumerable<IEnumerable<T>> res;

            if (k == 0)
            {
                res = new[] { new T[0] };
            }
            else
            {
                res = elements
                    .SelectMany((e, i) =>
                        elements.Skip(i + 1).Combinations_solution_from_stackoverflow(k - 1)
                            .Select(c =>
                                (new[] { e }).Concat(c)
                            )
                    )
                ;
            }


            return res;
        }
    }

    [TestClass]
    public class TestMyMath
    {
        private void test_combinations(IEnumerable<int> to_test, int k, int[][] expected_result)
        {
            var actual_result = MyMath.Combinations<int>(to_test.ToList(), k).ToList();

            for (var i = 0; i < actual_result.Count; i++)
            {
                var expected_row = expected_result[i];
                var actual_row = actual_result[i];

                CollectionAssert.AreEqual(
                    (System.Collections.ICollection)expected_row,
                    (System.Collections.ICollection)actual_row
                );
            }
        }

        [TestMethod]
        public void Test_MyMath_GetAllCombinations_n2_k1()
        {
            int k = 1;
            var to_test = new int[] { 1, 2 };
            var expected_result = new int[][] {
                new int[] {1},
                new int[] {2},
            };

            test_combinations(to_test, k, expected_result);
        }

        [TestMethod]
        public void Test_MyMath_GetAllCombinations_n3_k2()
        {
            var k = 2;
            var to_test = new int[] { 1, 2, 3 };
            var expected_result = new int[][] {
                new int[] {1,2},
                new int[] {1,3},
                new int[] {2,3}
            };

            test_combinations(to_test, k, expected_result);
        }

        [TestMethod]
        public void Test_MyMath_GetAllCombinations_n4_k2()
        {
            var k = 2;
            var to_test = new int[] { 1, 2, 3, 4 };
            var expected_result = new int[][] {
                new int[] {1,2},
                new int[] {1,3},
                new int[] {1,4},
                new int[] {2,3},
                new int[] {2,4},
                new int[] {3,4},
            };

            test_combinations(to_test, k, expected_result);
        }

        [TestMethod]
        public void Test_MyMath_GetAllCombinations_n4_k3()
        {
            var k = 3;
            var to_test = new int[] { 1, 2, 3, 4 };
            var expected_result = new int[][] {
                new int[] {1, 2, 3},
                new int[] {1, 2, 4},
                new int[] {1, 3, 4},
                new int[] {2, 3, 4},
            };

            test_combinations(to_test, k, expected_result);
        }
    }
}

