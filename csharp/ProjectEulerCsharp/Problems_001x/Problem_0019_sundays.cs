using ConsoleApplication1.Contract;
using System;

namespace ConsoleApplication1.Problems_001x
{
    class Problem_0019_sundays : IRunnableProblem
    {
        public string Run()
        {
            /* Anzahl Tage, bei nen der monatserste ein Sonntag ist
             * im 20 Jahrhundert
             * 
             * How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
             */
            var count = 0;
            for (var day = new DateTime(1901, 1, 1); day < new DateTime(2000, 12, 31); day = day.AddMonths(1))
            {
                if (day.DayOfWeek == DayOfWeek.Sunday && day.Day == 1)
                {
                    //Console.WriteLine(day + " " + day.DayOfWeek);
                    count++;
                }

            }
            Console.WriteLine(count);

            return count.ToString();
        }
    }
}
