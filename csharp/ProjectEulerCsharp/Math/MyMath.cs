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
        public static IEnumerable<int[]> Combinations<T>(int[] arrayIn, int k)
        {
            if (k <= 0)
{
                yield return new int[0];
                yield break;
            }

            if (k == 1)
            {
                foreach (var elm in arrayIn)
                {
                    yield return new int[] { elm };
                }
                yield break;
            }

            int n = arrayIn.Length;

            for (int i = 0; i + 1 <= (n - k); i++)
            {
                var to_combine = arrayIn[i];
                var subLength = n - i - 1;
                var to_sub_combine = new int[subLength];
                Array.Copy(arrayIn, i + 1, to_sub_combine, 0, subLength);
                var sub_combinations = Combinations<int>(to_sub_combine, k - 1);

                foreach (var sub_comb in sub_combinations)
                {
                    var tmp = new int[sub_comb.Length + 1];
                    tmp[0] = to_combine;
                    Array.Copy(sub_comb, 0, tmp, 1, sub_comb.Length);
                    yield return tmp;
                }
            }

            yield return arrayIn.ToList().GetRange(n - k, k).ToArray();
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

