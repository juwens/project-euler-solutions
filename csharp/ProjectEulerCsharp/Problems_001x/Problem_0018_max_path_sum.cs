using ConsoleApplication1.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.Problems_001x
{
    class Problem_0018_max_path_sum : IRunnableProblem
    {
        private class Point
        {
            public int Sum;
            public int InitialValue;
            public List<int> InheritedValues = new List<int>();

            public Point(int i)
            {
                Sum = i;
                InitialValue = i;
                InheritedValues.Add(i);
            }

            public void addChild(Point p)
            {
                Sum += p.Sum;
                InheritedValues.AddRange(p.InheritedValues);
            }
        }

        // (1 Ebenen, 1 Zahlen) == 1 Wege == 2**0
        // (2 Ebenen, 3 Zahlen) == 2 Wege == 2**1
        // (3 Ebenen, 6 Zahlen) == 4 Wege == 2**2
        // (4 Ebenen, 10 Zahlen) == 8 Wege == 2**3
        // Anzahl Wege == 2**(ebenen-1)



        public string Run()
        {
            String pyramid_str =
@"75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

            return solve(pyramid_str).ToString();
        }

        public static int solve (String triangle)
        {
            var pyramid = triangle.Split('\n').Select(
                row => row.Split(' ').Select(s => new Point(int.Parse(s))).ToList()
            ).ToList();

            for (int y = pyramid.Count - 1; y >= 1; y--)
            {
                var current_row = pyramid[y];

                for (int x = 0; x < (current_row.Count - 1); x++)
                {
                    var above_point = pyramid[y - 1][x];
                    Point biggest;
                    if (current_row[x].Sum >= current_row[x + 1].Sum)
                        biggest = current_row[x];
                    else
                        biggest = current_row[x + 1];

                    above_point.addChild(biggest);

                    Console.WriteLine("above({0}) + current({1})", above_point.Sum, biggest.Sum);

                }
                Console.WriteLine("End of row.");
            }


            Console.WriteLine("\nResult: {0}", pyramid[0][0].InheritedValues.Sum());
            Console.WriteLine("{0}", String.Join(", ", pyramid[0][0].InheritedValues));

            return pyramid[0][0].InheritedValues.Sum();
        }
    }
}
