using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using MyMath = ConsoleApplication1.Math;

namespace ConsoleApplication1.Tests
{
    [TestClass]
    public class TestPrimefactorCalculator
    {
        [TestMethod]
        public void TestDivisorsWith64()
        {
            var res = MyMath.Divisors.GetDivisors(64).ToArray();
            CollectionAssert.AreEqual(
                res
                 , new long[] { 1, 2, 4, 8, 16, 32, 64 }
             );
        }

        [TestMethod]
        public void TestDivisorsWith64ExcludeN()
        {
            CollectionAssert.AreEqual(
                MyMath.Divisors.GetProperDivisors(64).ToArray()
                 , new long[] { 1, 2, 4, 8, 16, 32 }
             );
        }

        [TestMethod]
        public void TestDivisorsWith220()
        {
            CollectionAssert.AreEqual(
                MyMath.Divisors.GetDivisors(220).ToArray()
                 , new long[] { 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110, 220 }
             );
        }

        [TestMethod]
        public void TestDivisorsWith220ExcludeN()
        {
            CollectionAssert.AreEqual(
                MyMath.Divisors.GetProperDivisors(220).ToArray()
                 , new long[] { 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110 }
             );
        }

        [TestMethod]
        public void TestDivisorsWith284()
        {
            CollectionAssert.AreEqual(
                MyMath.Divisors.GetDivisors(284).ToArray()
                 , new long[] { 1, 2, 4, 71, 142, 284 }
             );
        }

        [TestMethod]
        public void TestDivisorsWith284ExcludeN()
        {
            CollectionAssert.AreEqual(
                MyMath.Divisors.GetProperDivisors(284).ToArray()
                 , new long[] { 1, 2, 4, 71, 142 }
             );
        }

        [TestMethod]
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

        [TestMethod]
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
