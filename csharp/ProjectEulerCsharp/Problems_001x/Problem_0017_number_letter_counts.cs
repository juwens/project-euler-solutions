using ConsoleApplication1.Contract;
using System;
using System.Text.RegularExpressions;

namespace ConsoleApplication1.Problems_001x
{
    class Problem_0017_number_letter_counts : IRunnableProblem
    {

        // Komma an erster Stelle, damit es 1-indexiert ist
        private String[] till_twenty= (",one,two,three,four,five,six,seven,eight,nine,ten"  
            + ",eleven,twelve,thirteen,fourteen,fifteen,sixteen,seventeen,eighteen,nineteen").Split(',');

        private String[] till_hundred = ",ten,twenty,thirty,forty,fifty,sixty,seventy,eighty,ninety".Split(',');

        public string Run()
        {
            var words = "";

            for (var i = 1; i <= 1000; i++)
            {
                var word = getEnglishWord(i);
                word = Regex.Replace(word, @"[^\w]", "");
                Console.WriteLine("{0}: {1} ({2})", i, word, word.Length);
                words += word;
            }

            //words = Regex.Replace(words,@"[^\w]", "");
            Console.WriteLine(words.Length);

            return words.Length.ToString();
        }

        private String getEnglishWord(int int_to_convert)
        {
            var rest = int_to_convert;
            var number = "";

            if (rest >= 1000)
            {
                number += till_twenty[rest/1000] + "-thousand ";
                rest -= (rest / 1000) * 1000;
            }

            if (rest >= 100)
            {
                number += till_twenty[rest / 100] + "-hundred ";
                rest -= (rest / 100) * 100;
                if (rest > 0) number += " and ";
            }

            if (rest >= 20)
            {
                number += " " + till_hundred[rest / 10];
                rest -= (rest / 10) * 10;
            }

            if (rest > 0)
            {
                number += " " + till_twenty[rest];
            }

            return number;
        }
    }
}
