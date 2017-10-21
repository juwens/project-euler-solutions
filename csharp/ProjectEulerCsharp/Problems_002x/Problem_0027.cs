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

            for (long a = -999; a <= 999; a += 2)
            {
                for (long b = -1001; b < 1001; b += 2)
                {
                    for (long n = 0; n < 1000; n++)
                    {
                        //var y = (n * n) + a * n + b;
                        var y = n * (n + a) + b;
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
