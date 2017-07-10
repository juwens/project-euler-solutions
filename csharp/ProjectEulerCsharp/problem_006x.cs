using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{

    class problem_0067_max_path_sum_2 : IProjectEulerTestableProblem
    {
        public string Run()
        {
            // var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            // var tmp2 = Path.Combine(location, @"..\..\..\Problem_67_triangle.txt");
            // var file_name = new Uri(tmp2).LocalPath;
            var file_name = @"Data/Problem_67_triangle.txt";

            var pyramid_str = System.IO.File.ReadAllText(file_name);
            return problem_0018_max_path_sum.solve(pyramid_str).ToString();
        }
    }

    [TestClass]
    public class Test_006x : TestProjectEulerBase
    {
        [TestMethod]
        public async void Test_Problem_0068()
        {
            await AssertAnswerAsync(new problem_0067_max_path_sum_2(), "7273");
        }
    }

}
