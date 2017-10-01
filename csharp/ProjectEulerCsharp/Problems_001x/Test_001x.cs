using ConsoleApplication1.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Problems_001x
{
    [TestClass]
    public class Test_001x : TestBase
    {
        [TestMethod] public async Task Test_Problem_0010() => await AssertAnswerAsync(new Problem_0010(), "142913828922");
        [TestMethod] public async Task Test_Problem_0011() => await AssertAnswerAsync(new Problem_0011(), "70600674");
        [TestMethod] public async Task Test_Problem_0012() => await AssertAnswerAsync(new Problem_0012_number_of_divisors(), "76576500");
        [TestMethod] public async Task Test_Problem_0013() => await AssertAnswerAsync(new Problem_0013(), "5537376230");
        [TestMethod] public Task Test_Problem_0015() => throw new NotImplementedException();
        [TestMethod] public async Task Test_Problem_0014() => await AssertAnswerAsync(new Problem_0014_collatz(), "837799");
        [TestMethod] public async Task Test_Problem_0016() => await AssertAnswerAsync(new Problem_0016_digits(), "1366");
        [TestMethod] public async Task Test_Problem_0017() => await AssertAnswerAsync(new Problem_0017_number_letter_counts(), "21124");
        [TestMethod] public async Task Test_Problem_0018() => await AssertAnswerAsync(new Problem_0018_max_path_sum(), "1074");
        [TestMethod] public async Task Test_Problem_0019() => await AssertAnswerAsync(new Problem_0019_sundays(), "171");
    }
}
