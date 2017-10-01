using ConsoleApplication1.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using MyMath = ConsoleApplication1.Math;

namespace ConsoleApplication1.Problems_002x
{
    class Problem_0024 : IRunnableProblem
    {
        private IEnumerable<string> GetPermutations(string[] array)
        {
            if (array.Length == 0)
            {
                yield return "";
                yield break;
            }

            if (array.Length == 1)
            {
                yield return array[0];
                yield break;
            }

            for (int i = 0; i < array.Length; i++)
            {
                var currentItem = array[i];
                var subItems = new string[array.Length - 1];
                Array.Copy(array, 0, subItems, 0, i); // from 0-n
                Array.Copy(array, i + 1, subItems, i, array.Length - 1 - i); // from n-end
                foreach (var subItem in GetPermutations(subItems))
                {
                    yield return string.Concat(currentItem, subItem);
                }
            }
        }

        public string Run()
        {
            const string input = "0, 1, 2, 3, 4, 5, 6, 7, 8, 9";
            var numbers = input.Split(',').Select(x => x.Trim()).ToArray();

            var permutations = GetPermutations(numbers);

            return permutations.Take(1000 * 1000).Last();
        }
    }
}
