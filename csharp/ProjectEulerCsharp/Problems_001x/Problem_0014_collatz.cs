using ConsoleApplication1.Contract;

namespace ConsoleApplication1.Problems_001x
{
    class Problem_0014_collatz : IRunnableProblem
    {

        public string Run()
        {
            int biggest_start = 1000000;

            //return solve_simple_via_brute_force(biggest_start);
            return solve_simple_java_solution_from_forum(biggest_start);
        }

        //private string solve_recursive(int max_start)
        //{
        //}

        private string solve_simple_java_solution_from_forum(int max_start)
        {
            // 216ms in java -> 285 ms in c# (Any Cpu or x64), 480 ms in c# (x86)
            long num, cnt, mcnt = 0, mnum = 0;
            for (long i = 2; i <= 1e6; i++)
            {
                num = i;
                cnt = 0;
                while (num > 1)
                {
                    cnt++;
                    //bitwise modulo
                    num = ((num & 1) == 0)
                            ? num >> 1//bitwise division by 2
                            : num * 3 + 1;
                }

                /*
                mcnt = (mcnt > cnt) ? mcnt : cnt;
                mnum = (mcnt > cnt) ? mnum : i;
                 */
                 // kein zeitunterschied
                if (cnt > mcnt)
                {
                    mcnt = cnt;
                    mnum = i;
                }
            }

            return mnum.ToString();
        }

        private string solve_simple_via_brute_force(int max_start)
        {
            string res = "";

            //int max_start = 15;
            long longest_len = 0;
            long longest_len_start = 0;
            for (long current_start = 2; current_start < max_start; current_start++)
            {
                long current_number = current_start;
                // die eins kommt immer dazu
                long current_len = 1;
                while (current_number > 1L)
                {
                    current_number = (current_number & 1) == 0
                        ? current_number >> 1
                        : 3 * current_number + 1;

                    /*
                    // if (current_number % 2 == 0)
                    if ((current_number & 1) == 0) // 700 ms (40%) gespart
                    {
                        //current_number /= 2;
                        current_number = current_number >> 1; // 800 ms (50%) gespart
                    }
                    else
                    {
                        current_number = 3 * current_number + 1;
                    }
                     */ 
                    current_len++;
                }

                if (current_len > longest_len)
                {
                    longest_len = current_len;
                    longest_len_start = current_start;
                    //Console.WriteLine("start {0}, len {1}", current_start, current_len);
                    res = current_start.ToString();
                }
            }

            return res;
        }
    }
}
