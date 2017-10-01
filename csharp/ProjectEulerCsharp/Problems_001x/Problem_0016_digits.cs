using ConsoleApplication1.Contract;
using System;
using System.Linq;
using System.Numerics;

namespace ConsoleApplication1.Problems_001x
{
    class Problem_0016_digits : IRunnableProblem
    {

        public string Run()
        {
            var exp = 1000;
            BigInteger product = BigInteger.Pow(new BigInteger(2), exp);
            var sum = product.ToString().Select(c => int.Parse(c.ToString())).Sum();
            Console.WriteLine(sum);

            return sum.ToString();
        }
    }
}
