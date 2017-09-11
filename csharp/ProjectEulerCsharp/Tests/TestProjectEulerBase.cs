using ConsoleApplication1.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Tests
{
    [TestClass]
    public abstract class TestBase
    {
        protected async Task AssertAnswerAsync(IRunnableProblem p, string answer)
        {
            var max_milliseconds_for_test = 5000L;
            Assert.AreNotEqual("", answer, "definierte Antwort ist leer");

            var sw = Stopwatch.StartNew();
            var res = Task.Run(() => p.Run());

            while (sw.ElapsedMilliseconds < max_milliseconds_for_test && !res.IsCompleted)
            {
                await Task.Delay(50);
            }
            sw.Stop();
            if (res.IsCompleted)
            {
                Assert.AreEqual(answer, await res);
            }

            Assert.IsTrue(sw.ElapsedMilliseconds < max_milliseconds_for_test, String.Format("brauchte zu lange({0} ms)", sw.ElapsedMilliseconds));
        }

    }
}
