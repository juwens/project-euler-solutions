using ConsoleApplication1.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1.Problems_002x
{
    internal class Problem_0026 : IRunnableProblem
    {
        public string Run()
        {
            const int max = 1_000;
            var nrOfReminders = new int[max + 1];
            //var knownRemainders = new bool[max + 1];

            for (int n = 2; n < 1_000; n++)
            {
                var knownRemainders = new bool[n + 1];
                var remainder = 1;

                while (remainder != 0 && !knownRemainders[remainder])
                {
                    knownRemainders[remainder] = true;
                    remainder = (remainder * 10) % n;
                }

                nrOfReminders[n] = knownRemainders.Count(x => x);
            }
            var maxRemainder = 0;
            var res = 0;
            for (int i = 0; i < nrOfReminders.Length; i++)
            {
                if (maxRemainder < nrOfReminders[i])
                {
                    maxRemainder = nrOfReminders[i];
                    res = i;
                }
            }

            return res.ToString();
        }
    }
}
