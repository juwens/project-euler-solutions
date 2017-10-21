using ConsoleApplication1.Contract;
using ConsoleApplication1.Tests;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace ConsoleApplication1.Problems_002x
{
    [TestFixture]
    public class Test_002x : TestBase
    {
        [Test]
        public async Task Test_Problem_0020()
        {
            await AssertAnswerAsync(new Problem_0020_factorial_sum(), "648");
        }

        [Test]
        public async Task Test_Problem_0021()
        {
            await AssertAnswerAsync(new Problem_0021_amicabla_numbers(), "31626");
        }

        [Test]
        public async Task Test_Problem_0022()
        {
            await AssertAnswerAsync(new Problem_0022_names_score(), "871198282");
        }

        [Test]
        public async Task Test_Problem_0023()
        {
            await AssertAnswerAsync(new Problem_0023_non_abundant_numbers(), "4179871");
        }

        [Test] public async Task Test_Problem_0024() => await AssertAnswerAsync(new Problem_0024(), "2783915460");
        [Test] public async Task Test_Problem_0025() => await AssertAnswerAsync(new Problem_0025(), "4782");
        [Test] public async Task Test_Problem_0026() => await AssertAnswerAsync(new Problem_0026(), "983");
        [Test] public async Task Test_Problem_0027() => await AssertAnswerAsync(new Problem_0027(), "-59231");
    }
}
