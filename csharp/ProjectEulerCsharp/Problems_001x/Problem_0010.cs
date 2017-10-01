using ConsoleApplication1.Contract;
using ConsoleApplication1.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1.Problems_001x
{
    class Problem_0010 : IRunnableProblem
    {
        private List<long> real_primes;
        public string Run()
        {
            const int MAX_RPIME = 2000000;
            var pseudo_primes = new List<long>();
            real_primes = new List<long>();
            real_primes.Add(2);
            real_primes.Add(3);
            for (int i = 1; i < MAX_RPIME / 6; i++)
            {
                pseudo_primes.Add(i * 6 - 1);
                pseudo_primes.Add(i * 6 + 1);
            }

            foreach (long pseudo_prime in pseudo_primes)
            {
                if (IsPrime(pseudo_prime))
                {
                    real_primes.Add(pseudo_prime);
                }
            }

            long sum = 0;
            foreach (long prime in real_primes)
            {
                //Console.WriteLine("real_prime: {0}", prime);
                sum += prime;
            }
            Console.WriteLine("sum: {0}", sum);

            return sum.ToString();
        }

        private bool IsPrime(long i)
        {
            foreach (long prime in real_primes)
            {
                if (prime > System.Math.Sqrt(i)) return true;
                if (i % prime == 0) return false;
            }

            return true;
        }
    }
}
