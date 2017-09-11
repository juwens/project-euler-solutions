﻿using ConsoleApplication1.Contract;
using ConsoleApplication1.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Problem_0000_test : IRunnableProblem
    {
        public string Run()
        {
            int[] foo = new int[] { 1, 2, 3, 4 };
            //int[] foo_clone = (int[]) foo.Clone();
            //int[] foo_copy = new int[foo.Length];
            //foo.CopyTo(foo_copy, 0);

            //foo_clone[1] = 666;
            //foo_copy[2] = 666;

            //var bar_1 = MyMath.Combinations<int>(foo, 1);
            var bar_2 = MyMath.Combinations<int>(foo, 2);
            var bar_3 = MyMath.Combinations<int>(foo, 3);

            return "";
        }
    }

    class Problem_0008_jens_largest_product : IRunnableProblem
    {
        public string Answer
        {
            get { return "40824"; }
        }


        public string Run()
        {
            String input = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";

            int largest_product = 0;
            for (int i = 0; i < input.Length - 5; i++)
            {
                int product = 1;
                for (int j = 0; j < 5; j++)
                {
                    int casted_value = int.Parse(input[i + j].ToString());
                    product = product * casted_value;
                }

                if (product > largest_product)
                {
                    largest_product = product;
                }

            }
            Console.WriteLine(largest_product);
            return largest_product.ToString();
        }

    }
}
