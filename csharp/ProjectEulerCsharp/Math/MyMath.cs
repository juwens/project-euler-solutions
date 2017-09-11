using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConsoleApplication1.Math
{
    internal static class MyMath
    {
        public static BigInteger Factorial(int fac)
        {
            var result = new BigInteger(1);
            for (var i = new BigInteger(fac); i > 0; i--)
            {
                result *= i;
            }
            return result;
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
        public static List<int[]> Combinations<T>(IList<int> arrayIn, int k)
        {
            if (k <= 0) return new List<int[]>();
            if (k == 1) return arrayIn.Select(x => new int[] { x }).ToList();

            int n = arrayIn.Count;

            var arrayOut = new List<int[]>();
            
            for (int i = 0; i + 1 <= (n - k); i++)
            {
                var to_combine = arrayIn[i];
                var to_sub_combine = arrayIn.ToList().GetRange(i + 1, n - i - 1);
                var sub_combinations = Combinations<int>(to_sub_combine, k - 1);

                foreach (var sub_comb in sub_combinations)
                {
                    var tmp = new List<int>();
                    tmp.Add(to_combine);
                    tmp.AddRange(sub_comb);
                    arrayOut.Add(tmp.ToArray());
                }
            }

            arrayOut.Add(arrayIn.ToList().GetRange(n - k, k).ToArray());

            return arrayOut;
        }

        public static IEnumerable<IEnumerable<T>> Combinations_solution_from_stackoverflow<T>(this IEnumerable<T> elements, int k)
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
}

