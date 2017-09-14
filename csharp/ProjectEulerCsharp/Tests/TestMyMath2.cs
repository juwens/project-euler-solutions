using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using MyMath = ConsoleApplication1.Math;

namespace ConsoleApplication1.Tests
{
    [TestFixture]
    public class TestPrimefactorCalculator
    {
        [Test]
        [TestCase(1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1, 2)]
        [TestCase(5, 1)]
        [TestCase(6, 1, 2, 3)]
        [TestCase(7, 1)]
        [TestCase(9, 1, 3)]
        [TestCase(10, 1, 2, 5)]
        [TestCase(11, 1)]
        [TestCase(12, 1, 2, 3, 4, 6)]
        [TestCase(13, 1)]
        [TestCase(14, 1, 2, 7)]
        [TestCase(15, 1, 3, 5)]
        [TestCase(16, 1, 2, 4, 8)]
        [TestCase(20, 1, 2, 4, 5, 10)]
        [TestCase(30, 1, 2, 3, 5, 6, 10, 15)]
        public void TestProperDivisors(int n, params int[] expectedResult)
        {
            var res = MyMath.Divisors.GetProperDivisors(n).ToArray();
            NUnit.Framework.CollectionAssert.AreEqual(
                res, expectedResult
             );
        }
        
        [Test]
        public void TestDivisorsWith64()
        {
            var res = MyMath.Divisors.GetDivisors(64).ToArray();
            CollectionAssert.AreEqual(
                res
                 , new long[] { 1, 2, 4, 8, 16, 32, 64 }
             );
        }

        [Test]
        public void TestDivisorsWith64ExcludeN()
        {
            var res = MyMath.Divisors.GetProperDivisors(64).ToArray();
            CollectionAssert.AreEqual(
                res
                 , new long[] { 1, 2, 4, 8, 16, 32 }
             );
        }

        [Test]
        public void TestDivisorsWith220()
        {
            var res = MyMath.Divisors.GetDivisors(220).ToArray();
            CollectionAssert.AreEqual(
                res
                 , new long[] { 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110, 220 }
             );
        }

        [Test]
        public void TestDivisorsWith220ExcludeN()
        {
            CollectionAssert.AreEqual(
                MyMath.Divisors.GetProperDivisors(220).ToArray()
                 , new long[] { 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110 }
             );
        }

        [Test]
        public void TestDivisorsWith284()
        {
            CollectionAssert.AreEqual(
                MyMath.Divisors.GetDivisors(284).ToArray()
                 , new long[] { 1, 2, 4, 71, 142, 284 }
             );
        }

        [Test]
        public void TestDivisorsWith284ExcludeN()
        {
            CollectionAssert.AreEqual(
                MyMath.Divisors.GetProperDivisors(284).ToArray()
                 , new long[] { 1, 2, 4, 71, 142 }
             );
        }

        [Test]
        public void TestPrimeFactorsWith28()
        {
            CollectionAssert.AreEqual(
                (System.Collections.ICollection)PrimefactorCalculator.getInstance().getPrimeFactors(28),
                (System.Collections.ICollection)new Dictionary<long, long>()
                {
                   {2, 2},
                   {7, 1}
                }
            );
        }

        [Test]
        public void TestPrimeFactorsWith220()
        {
            CollectionAssert.AreEqual(
                (System.Collections.ICollection)PrimefactorCalculator.getInstance().getPrimeFactors(220),
                (System.Collections.ICollection)new Dictionary<long, long>()
                {
                   {2, 2},
                   {5, 1},
                   {11, 1}
                }
            );
        }

    }
}
