using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1.Math;

namespace ConsoleApplication1
{
    class PrimefactorCalculator
    {
        private List<long> primeNumbers;
        private static PrimefactorCalculator inst;
        private PrimefactorCalculator()
        {
            primeNumbers = new List<long>(1000);
            primeNumbers.Add(2);
            primeNumbers.Add(3);
        }
        public static PrimefactorCalculator getInstance()
        {
            if (inst == null)
            {
                inst = new PrimefactorCalculator();
            }
            return inst;
        }
        public Dictionary<long, long> getPrimeFactors(long number)
        {
            if (number == 0) return new Dictionary<long, long>() { {0, 0} };
            if (number == 1) return new Dictionary<long, long>() { { 1, 1 } };

            long initial_number = number;

            generatePrimeNumbers((number+1)/2);
            Dictionary<long, long> prime_factors = new Dictionary<long,long>();

            foreach(long divider in primeNumbers)
            {
                while (number % divider == 0) {
                    number /= divider;
                    if (!prime_factors.ContainsKey(divider)) {
                        prime_factors.Add(divider, 1L);
                    } else {
                        prime_factors[divider]++;
                    }
                }

                if (divider > (initial_number/2))
                {
                    break;
                }
            }

            // Die Zahl selber ist Primfaktor, wenn keine andere Zahl gefunden wurde
            if (number != 1 && prime_factors.Count == 0)
            {
                prime_factors.Add(number, 1L);
            }
            
            return prime_factors;
        }

        private void generatePrimeNumbers(long max_prime)
        {
            // generate pseudo prime 
            for (long i = (primeNumbers.Last() / 6) + 1; (i * 6 - 1) <= max_prime; i++)
            {
                foreach (var pseudo_prime in new[] { i * 6 - 1, i * 6 + 1 })
                {
                    if (is_prime(pseudo_prime)) primeNumbers.Add(pseudo_prime);
                }
            }
        }

        private bool is_prime(long i)
        {
            foreach (long prime in primeNumbers)
            {
                if ((prime * prime) > i) return true;
                if (i % prime == 0) return false;
            }

            return true;
        }

        private void add_to_prime_numbers_if_prime(long[] numbers)
        {
            foreach (long number in numbers)
            {
                if (is_prime(number))
                {
                    //Console.WriteLine("prime: " + number);
                    primeNumbers.Add(number);
                }
            }

        }

    }
}
