using ConsoleApplication1.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1.Problems_002x
{
    internal class Problem_0026 : IRunnableProblem
    {
        private class TreeNode
        {
            public TreeNode Parent;
            public TreeNode[] Children;
            public int Index;
        }

        private class TreeEdge
        {
            public string String;
            public TreeNode Parent;
            public TreeNode Child;
        }

        /// <summary>
        /// a well known solution for finding repeating substrings is to use a suffix tree
        /// https://en.wikipedia.org/wiki/Longest_repeated_substring_problem
        /// https://stackoverflow.com/questions/9452701/ukkonens-suffix-tree-algorithm-in-plain-english/9513423#9513423
        /// </summary>
        public string Run()
        {
            var offset = BigInteger.Pow(10, 1_000);
            for (int i = 1; i < 1_000; i++)
            {
                var numberToTest = offset / i;
                var matches = Regex.Match(numberToTest.ToString(), "\\d+");
            }

            return "";
        }
    }
}
