using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{
    // ProjectEulerProblem
   abstract class ProjectEulerProblemOld
    {
       public static void test()
       {
           CollectionAssert.AreEqual(
               (System.Collections.ICollection)PrimefactorCalculator.getInstance().getPrimeFactors(28),
               (System.Collections.ICollection)new Dictionary<long, long>()
               {
                   {2, 2},
                   {7, 1}
               }
            );
       }


        public static void Main(String[] args)
        {
            test();

            Assembly targetAssembly = Assembly.GetExecutingAssembly();
            //IEnumerable<Type> subtypes = targetAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(IProjectEulerTestableProblem)));
            IEnumerable<Type> subtypes = targetAssembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IProjectEulerRunnableProblem)));
            Dictionary<int, Type> number2type = new Dictionary<int,Type>();

            List<Type> classes = subtypes.OrderBy(t => t.Name).ToList();
            foreach (Type class_type in classes)
            {
                int nr;
                try
                {
                    String val = Regex.Match(class_type.Name, @"problem_(\d+)_").Groups[1].Value;
                    nr = int.Parse(val);
                }
                catch (Exception)
                {
                    continue;
                }

                Console.WriteLine("[{0}] {1}", nr, class_type.Name);

                number2type[nr] = class_type;
            }

            Console.WriteLine("Choose Test:");
            var key = Console.ReadLine();

            if (key == "" || !Regex.Match(key, @"^\d+$").Success)
            {
                return;
            }
                

            var index = int.Parse(key);

            if (number2type.ContainsKey(index))
                runProblem((IProjectEulerRunnableProblem)Activator.CreateInstance(number2type[index]));
            else
                Console.WriteLine("Problem \"{0}\" existiert nicht", index);

            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadKey();
        }

       private static void runProblem(IProjectEulerRunnableProblem p)
       {
           Console.WriteLine("\nrun: {0}", p.GetType());
           var sw = new Stopwatch();
           sw.Start();
           var res = p.Run();
           sw.Stop();
           Console.WriteLine("Answer: " + res);
           Console.WriteLine("Dauer [ms]: " + sw.ElapsedMilliseconds);
       }

        public abstract string run();
    }

   // ProjectEulerProblem
    public interface IProjectEulerRunnableProblem
    {
        string Run();
    }

    // ProjectEulerProblem
    public interface IProjectEulerTestableProblem : IProjectEulerRunnableProblem
    {
        //string Answer {get;}
    }

    interface IDoNotTest { }

    [TestClass]
    public abstract class TestProjectEulerBase
    {
        //public abstract string Answer
        //{ 
        //    get; 
        //}
        //public abstract string Run();

        //[TestMethod]
        //public void TestMe()
        //{
        //    Assert.AreEqual(Answer, Run());
        //}

        protected async Task AssertAnswerAsync(IProjectEulerTestableProblem p, string answer)
        {
            var max_milliseconds_for_test = 5000L;
            Assert.AreNotEqual("", answer, "definierte Antwort ist leer");

            var sw = Stopwatch.StartNew();
            var res = Task.Run(() =>  p.Run());
            
            while (sw.ElapsedMilliseconds < max_milliseconds_for_test && !res.IsCompleted)
            {
                await Task.Delay(50);
            }
            sw.Stop();
            if (res.IsCompleted)
            {
                Assert.AreEqual(answer, await res);
            }

            Assert.IsTrue(sw.ElapsedMilliseconds < max_milliseconds_for_test, String.Format("brauchte zu lange({0} ms)", sw.ElapsedMilliseconds));
        }

    }

    //[TestClass]
    //public class TestAllProjectEulerProblems
    //{
    //    long max_milliseconds_for_test = 2000;

    //    [TestMethod]
    //    public void TestAllProblems()
    //    {
    //        Assembly targetAssembly = Assembly.GetExecutingAssembly();
    //        IEnumerable<Type> subtypes = targetAssembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IProjectEulerTestableProblem)));
    //        List<Type> classes = subtypes.OrderBy(t => t.Name).ToList();
    //        foreach (Type class_type in classes)
    //        {
    //            IProjectEulerTestableProblem obj = (IProjectEulerTestableProblem)Activator.CreateInstance(class_type);
    //            Assert.AreNotEqual("", obj.Answer, String.Format("Klasse {0} definierte Antwort ist leer)", obj.GetType().ToString()));
                
    //            string res = "";
    //            var sw = new Stopwatch();
    //            sw.Start();
    //            //try
    //            //{
    //                res = (obj).Run();
    //            //} catch (Exception e)
    //            //{ 
    //            //    Assert.
    //            //}
    //            sw.Stop();

    //            Assert.IsTrue(sw.ElapsedMilliseconds < max_milliseconds_for_test, String.Format("Klasse {0} brauchte zu lange({1} ms)", obj.GetType().ToString(), sw.ElapsedMilliseconds));
                
    //            Assert.AreEqual(obj.Answer, res, "Fehler in Klasse " + obj.GetType().ToString());
    //        }
    //    }
    //}

}
