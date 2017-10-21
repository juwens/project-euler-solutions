using ConsoleApplication1.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Problems_002x
{
    public class Problem_0027 : IRunnableProblem
    {
        public string Run()
        {
            var pfc = PrimefactorCalculator.GetInstance();
            var nMax = 0L;
            var res = 0L;

            for (long a = -1000; a < 1000; a++)
            {
                for (long b = -1000; b <= 1000; b++)
                {
                    for (long n = 0; n < 1000; n++)
                    {
                        var y = (n * n) + a * n + b;
                        if (y >= 0 && pfc.IsPrime(y))
                        {
                            if (n > nMax)
                            {
                                nMax = n;
                                res = a * b;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return res.ToString();
        }
    }
}
