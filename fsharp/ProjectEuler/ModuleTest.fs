module Tests

open Solutions
open NUnit.Framework

let list_assert_equal actual expected =
    let msg = sprintf "%A != %A" expected actual
    CollectionAssert.AreEqual(expected, actual, msg)

type Check = 
    static member result(given: int64, expected : int64) =
        if given = expected then
          printfn "OK for %i: %i" given expected
        else
            printfn "FAILED for %d, expected %i" given expected

    static member result (given: int, expected : int) =
        Check.result (int64(given),  int64(expected))

module example = 
    [<Test; Timeout(1000)>]
    let ``1 + 1 = 2``() = Assert.AreEqual(2, 1+1)

module fibonacci = 
    [<Test; Timeout(1000)>]
    let testFibonacciSeq() = 
        let solution = [0; 1; 1; 2; 3; 5; 8; 13; 21; 34; 55; 89; 144; 233; 377; 610; 987; 1597; 2584; 4181; 6765; 10946; 17711; 28657; 46368; 75025; 121393; 196418; 317811; 514229; 832040; 1346269; 2178309; 3524578; 5702887; 9227465; 14930352; 24157817; 39088169]
        let res = fibonacciSeq |> Seq.take solution.Length |> Seq.toList
        //printfn "%A %A" solution res
        CollectionAssert.AreEqual(solution, res)

open System.Reflection


module ``test problems`` = 
//    [<TestCase("9", Result="31875000")>]
//    [<TestCase("10_3", Result="142913828922")>]
//    [<TestCase("11", Result="70600674")>]
//    [<TestCase("12", Result="76576500")>]
//    [<TestCase("13", Result="5537376230")>]
//    [<TestCase("14", Result="837799")>]
//    [<TestCase("15", Result="137846528820")>]
//    [<TestCase("16", Result="1366")>]
//    [<TestCase("17", Result="21124")>]
//    
//    [<TestCase("19", Result="171")>]
//    
    [<MaxTime(5000)>]
    let testEuler name =
        let moduleInfo = 
            Assembly.GetExecutingAssembly().GetTypes()
            |> Seq.find (fun t -> t.Name = "Solutions")

        moduleInfo.GetMethod("p" + name).Invoke(null, null) |> string

//    [<Test; Timeout(1000)>]
//    let ``p1``() = 
//        Assert.AreEqual(233168, p1())

//    [<Test; Timeout(1000)>]
//    let ``p2``() = 
//        Assert.AreEqual(4613732, p2())

//    [<Test; Timeout(1000)>]
//    let ``p3``() = 
//        Assert.AreEqual(6857L, p3())

//    [<Test; Timeout(1000)>]
//    let ``p4``() = 
//        Assert.AreEqual(906609, p4())
//
//    [<Test; Timeout(1000)>]
//    let ``p5``() = 
//        Assert.AreEqual(232792560L, p5())
//
//    [<Test; Timeout(1000)>]
//    let ``p6``() = 
//        Assert.AreEqual(25164150, p6())
//
//    [<Test; Timeout(10000)>]
//    let ``p7``() = 
//        Assert.AreEqual(104743, p7())
//
//    [<Test; Timeout(1000)>]
//    let ``p8``() = 
//        Assert.AreEqual(23514624000L, p8())

module factorize = 
    [<Timeout(100)>]
    [<TestCase(2L, Result=[|2L|])>]
    [<TestCase(3L, Result=[|3L|])>]
    [<TestCase(4L, Result=[|2L; 2L|])>]
    [<TestCase(5L, Result=[|5L|])>]
    [<TestCase(10L, Result=[|2L; 5L|])>]
    [<TestCase(48L, Result=[|2;2;2;2;3|])>]
    [<TestCase(330L, Result=[|2L; 3L; 5L; 11L|])>]
    let ``factorize-test``(x) = 
        factorize x 
        |> List.toArray

module dividers = 
    [<Test; Timeout(1000)>]
    let ``dividers of 88``() = 
        let ex = [1L; 2L; 4L; 8L; 11L; 22L; 44L; 88L]
        let ac = findDividersOf 88L
        let msg = sprintf "%A != %A" ex ac
        CollectionAssert.AreEqual(ex, ac, msg)

module ``findPrimeFactorsOf`` = 
    [<Test; Timeout(1000)>]
    [<TestCase(2L ,Result=[|2L|])>]
    [<TestCase(3L ,Result=[|3L|])>]
    [<TestCase(4L ,Result=[|2L|])>]
    [<TestCase(5L ,Result=[|5L|])>]
    [<TestCase(6L ,Result=[|2L; 3L|])>]
    [<TestCase(48L ,Result=[|2L; 3L|])>]
    [<TestCase(330L ,Result=[|2L; 3L; 5L; 11L|])>]
    let ``findPrimeFactorsOf``(x) = 
        findPrimeFactorsOf x |> List.toArray

    [<Test; Timeout(1000)>]
    let ``findPrimeFactorsOf 2``() = 
        list_assert_equal (findPrimeFactorsOf 2L) [2L]

    [<Test; Timeout(1000)>]
    let ``findPrimeFactorsOf 3``() = 
        list_assert_equal (findPrimeFactorsOf 3L) [3L]

    [<Test; Timeout(1000)>]
    let ``findPrimeFactorsOf 4``() = 
        list_assert_equal (findPrimeFactorsOf 4L) [2L]

    [<Test; Timeout(1000)>]
    let ``findPrimeFactorsOf 5 2``() = 
        list_assert_equal (findPrimeFactorsOf 5L) [5L]

    [<Test; Timeout(1000)>]
    let ``findPrimeFactorsOf 6``() = 
        list_assert_equal (findPrimeFactorsOf 6L) [2L; 3L]

    [<Test; Timeout(1000)>]
    let ``findPrimeFactorsOf 10``() = 
        list_assert_equal (findPrimeFactorsOf 10L) [2L; 5L]

    [<Test; Timeout(1000)>]
    let ``findPrimeFactorsOf 330``() = 
        list_assert_equal (findPrimeFactorsOf 330L) [2L; 3L; 5L; 11L]

module ``test binomial coefficient`` = 
    [<MaxTime(100)>]
    [<TestCase(0, 0, Result=1)>]

    [<TestCase(1, 0, Result=1)>]
    [<TestCase(1, 1, Result=1)>]

    [<TestCase(2, 0, Result=1)>]
    [<TestCase(2, 1, Result=2)>]
    [<TestCase(2, 2, Result=1)>]

    [<TestCase(3, 0, Result=1)>]
    [<TestCase(3, 1, Result=3)>]
    [<TestCase(3, 2, Result=3)>]
    [<TestCase(3, 3, Result=1)>]

    [<TestCase(4, 0, Result=1)>]
    [<TestCase(4, 1, Result=4)>]
    [<TestCase(4, 2, Result=6)>]
    [<TestCase(4, 3, Result=4)>]
    [<TestCase(4, 4, Result=1)>]
    let ``test binomal_coefficient`` (n, k) =
        binomal_coefficient (n, k)