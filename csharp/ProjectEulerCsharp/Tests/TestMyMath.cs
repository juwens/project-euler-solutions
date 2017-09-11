using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMath = ConsoleApplication1.Math;

namespace ConsoleApplication1.Tests
{
    [TestClass]
    public class TestMyMath
    {
        private void Test_combinations(IEnumerable<int> to_test, int k, int[][] expected_result)
        {
            var actual_result = MyMath.MyMath.Combinations<int>(to_test.ToList(), k).ToList();

            for (var i = 0; i < actual_result.Count; i++)
            {
                var expected_row = expected_result[i];
                var actual_row = actual_result[i];

                CollectionAssert.AreEqual(
                    expected_row,
                    actual_row
                );
            }
        }

        [TestMethod]
        public void Test_MyMath_GetAllCombinations_n2_k1()
        {
            int k = 1;
            var to_test = new int[] { 1, 2 };
            var expected_result = new int[][] {
                new int[] {1},
                new int[] {2},
            };

            Test_combinations(to_test, k, expected_result);
        }

        [TestMethod]
        public void Test_MyMath_GetAllCombinations_n3_k2()
        {
            var k = 2;
            var to_test = new int[] { 1, 2, 3 };
            var expected_result = new int[][] {
                new int[] {1,2},
                new int[] {1,3},
                new int[] {2,3}
            };

            Test_combinations(to_test, k, expected_result);
        }

        [TestMethod]
        public void Test_MyMath_GetAllCombinations_n4_k2()
        {
            var k = 2;
            var to_test = new int[] { 1, 2, 3, 4 };
            var expected_result = new int[][] {
                new int[] {1,2},
                new int[] {1,3},
                new int[] {1,4},
                new int[] {2,3},
                new int[] {2,4},
                new int[] {3,4},
            };

            Test_combinations(to_test, k, expected_result);
        }

        [TestMethod]
        public void Test_MyMath_GetAllCombinations_n4_k3()
        {
            var k = 3;
            var to_test = new int[] { 1, 2, 3, 4 };
            var expected_result = new int[][] {
                new int[] {1, 2, 3},
                new int[] {1, 2, 4},
                new int[] {1, 3, 4},
                new int[] {2, 3, 4},
            };

            Test_combinations(to_test, k, expected_result);
        }
    }
}
