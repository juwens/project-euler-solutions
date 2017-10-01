using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;
using ConsoleApplication1.Contract;

namespace ConsoleApplication1
{
    static class Program
    {
        public static void Main(string[] args)
        {
            var targetAssembly = Assembly.GetExecutingAssembly();
            var eulerProblemClasses = targetAssembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IRunnableProblem)))
                .Where(t => !t.IsInterface)
                .OrderBy(x => x.Name)
                .ToList();

            var number2type = new Dictionary<int, Type>();
            foreach (var @class in eulerProblemClasses)
            {
                var regexMatch = Regex.Match(@class.Name, @"problem_(\d+)($|[^\d])", RegexOptions.IgnoreCase);

                var intString = regexMatch.Groups[1].Value;
                var nr = int.Parse(intString);

                Console.WriteLine("[{0}] {1}", nr, @class.Name);

                number2type[nr] = @class;
            }

            Console.WriteLine("Choose Test:");
            var testToRun = Console.ReadLine();

            if (testToRun == "" || !Regex.Match(testToRun, @"^\d+$").Success)
            {
                return;
            }

            var testToRunInt = int.Parse(testToRun);
            if (number2type.ContainsKey(testToRunInt))
                RunProblem((IRunnableProblem)Activator.CreateInstance(number2type[testToRunInt]));
            else
                Console.WriteLine("Problem \"{0}\" existiert nicht", testToRunInt);

            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadKey();
        }

        private static void RunProblem(IRunnableProblem p)
        {
            Console.WriteLine("\nrun: {0}", p.GetType());
            var sw = new Stopwatch();
            sw.Start();
            var res = p.Run();
            sw.Stop();
            Console.WriteLine("Answer: " + res);
            Console.WriteLine("Dauer [ms]: " + sw.ElapsedMilliseconds);
        }
    }
}
