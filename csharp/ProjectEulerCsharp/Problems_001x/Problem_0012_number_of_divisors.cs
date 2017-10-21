using ConsoleApplication1.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.Problems_001x
{
    class Problem_0012_number_of_divisors : IRunnableProblem
    {
        public string Run()
        {
            return fastSolution();
        }

        private readonly int divisors_to_find = 500;

        // 300ms
        private string fastSolution()
        {
            int divider_count = 0;
            //			uint divider_count_max = 0;
            int divider_count_limit = divisors_to_find;
            int triangle_nr = 0;

            for (int i = 1; divider_count <= divider_count_limit; ++i)
            {
                triangle_nr += i;
                divider_count = 0;

                for (int j = 1; (j * j) < triangle_nr; j++)
                {
                    if (triangle_nr % j == 0) divider_count += 2;
                }

                /*
                if (divider_count >= divider_count_max = 0) {
                    Console.WriteLine("i = {0}, dc: {1}", i, divider_count);
                }
                */

                //				if (divider_count > divider_count_max) {
                //					divider_count_max = divider_count;
                //					Console.WriteLine("i = {0}, dc: {1}", triangle_nr, divider_count);
                //				}

                if (divider_count > 500)
                {
                    break;
                }
            }

            Console.WriteLine("i = {0}, dc: {1}", triangle_nr, divider_count);

            return triangle_nr.ToString();
        }

        // ca. 5 minuten
        private string slowSolution()
        {
            long step = 0;
            long i = 0;
            long divisors = 0;
            long last_step_digits = 0;
            long max_divisors = 0;
            var sw = new System.Diagnostics.Stopwatch();

            var pfc = PrimefactorCalculator.GetInstance();
            while (divisors < divisors_to_find)
            {
                i++;
                step = step + i;

                sw.Restart();
                Dictionary<long, long> pfactors = pfc.GetPrimeFactors(step);
                long pf_time_ext = sw.ElapsedMilliseconds;

                sw.Restart();
                long pfactors_exp_prod = 1;
                foreach (long exp in pfactors.Values.ToList())
                {
                    pfactors_exp_prod *= exp + 1;
                };
                divisors = pfactors_exp_prod;
                long pf_time_int = sw.ElapsedMilliseconds;

                Console.WriteLine("ext: {0}, int: {1}", pf_time_ext, pf_time_int);

                //Console.WriteLine(
                //    String.Join(", ", new String[]{
                //    "step: " + step,
                //    "div count: " + divisors,
                //    })
                //);

                //foreach (var entry in pfactors)
                //{
                //    Console.WriteLine("[{0} => {1}]", entry.Key, entry.Value); 
                //}

                int cur_step_digits = ("" + step).Length;
                if (
                    cur_step_digits > last_step_digits
                    || divisors > max_divisors
                    )
                {
                    Console.WriteLine("step: {0}, divisors: {1}", step, divisors);
                    last_step_digits = cur_step_digits;
                    max_divisors = divisors;
                }
            }
            Console.WriteLine("\n{0}: {1}", step, String.Join(", ", divisors));


            return step.ToString();
        }
    }
}
