using ConsoleApplication1.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ConsoleApplication1.Problems_002x
{
    [TestClass]
    public class Test_002x : TestBase
    {
        [TestMethod]
        public async Task Test_Problem_0020()
        {
            await AssertAnswerAsync(new Problem_0020_factorial_sum(), "648");
        }

        [TestMethod]
        public async Task Test_Problem_0021()
        {
            await AssertAnswerAsync(new Problem_0021_amicabla_numbers(), "31626");
        }

        [TestMethod]
        public async Task Test_Problem_0022()
        {
            await AssertAnswerAsync(new Problem_0022_names_score(), "871198282");
        }

        [TestMethod]
        public async Task Test_Problem_0023()
        {
            await AssertAnswerAsync(new Problem_0023_non_abundant_numbers(), "4179871");
        }

        [TestMethod]
        public async Task Test_Problem_0024()
        {
            await AssertAnswerAsync(new Problem_0024(), "2783915460");
        }
    }
}
