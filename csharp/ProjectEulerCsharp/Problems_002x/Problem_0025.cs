using ConsoleApplication1.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Problems_002x
{
    internal class Problem_0025 : IRunnableProblem
    {
        private BigInteger last = 1;
        private BigInteger current = 1;
        private int index = 2;

        public string Run()
        {
            while (true)
            {
                var currentCopy = current;
                current += last;
                last = currentCopy;
                index++;

                if (current.ToString().Length == 1_000)
                {
                    return index.ToString();
                }
            }
        }
    }
}
