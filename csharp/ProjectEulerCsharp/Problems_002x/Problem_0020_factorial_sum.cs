using ConsoleApplication1.Contract;
using ConsoleApplication1.Math;
using System;
using System.Linq;
using System.Numerics;
using System.Text;
using MyMath = ConsoleApplication1.Math;

namespace ConsoleApplication1.Problems_002x
{
    class Problem_0020_factorial_sum : IRunnableProblem
    {
        public string Run()
        {
            // python: sum = 0; for c in str(math.factorial(100)): sum += int(c)
            var sum = MyMath.MyMath
                    .Factorial(100)
                    .ToString()
                    .Select(char.GetNumericValue)
                    .Sum();
            Console.WriteLine("sum: " + sum);

            return sum.ToString();
        }
    }
}
