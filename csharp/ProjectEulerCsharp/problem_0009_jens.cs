using ConsoleApplication1.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Problem_0009_special_pythagorean_triplet : IRunnableProblem
    {
        public string Answer
        {
            get { return "31875000"; }
        }

        public string Run()
        {
            int a, b, c, rounds = 0;
            const int MAX_SUM = 1000;
            Random rnd = new Random();
            while (true)
            {
                rounds++;
                a = rnd.Next(1, MAX_SUM + 1);
                b = rnd.Next(1, MAX_SUM - a + 1);
                c = MAX_SUM - a - b;

                if (a >= b || b >= c)
                {
                    continue;
                }

                if ((a * a) + (b * b) == (c * c))
                {
                    break;
                }

            }
            Console.WriteLine("a:{0}, b:{1}, c:{2}", a, b, c);
            Console.WriteLine("rounds: {0}", rounds);
            Console.WriteLine("product: {0}", a * b * c);

            return (a * b * c).ToString();
        }

    }
}
