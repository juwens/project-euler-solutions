// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
module Program

open System
open Solutions

//
//type Fibonacci = 
//    static member seq = Seq.unfold(fun(a,b) -> Some(a+b, (b, a+b))) (0,1)

//[<TestFixture>]
//type TestFibonacci = 
//    [<Test>]
//    member this.When2IsAddedTo2Expect4() =
//        let solution = [0; 1; 1; 2; 3; 5; 8; 13; 21; 34; 55; 89; 144; 233; 377; 610; 987; 1597; 2584; 4181; 6765; 10946; 17711; 28657; 46368; 75025; 121393; 196418; 317811; 514229; 832040; 1346269; 2178309; 3524578; 5702887; 9227465; 14930352; 24157817; 39088169]
//        Assert.AreEqual(solution, Fibonacci.seq |> Seq.take solution.Length)



open System.Diagnostics

let test() = 
    let rec fib x = if x <= 2 then 1 else fib(x-1) + fib(x-2)
 
    let fibs =
        [ for i in 0..43 -> fib(i) ]
    
    0

let testp() = 
    let rec fib x = if x <= 2 then 1 else fib(x-1) + fib(x-2)
 
    let fibs =
        Async.Parallel [ for i in 0..43 -> async { return fib(i) } ]
        |> Async.RunSynchronously
    
    0

let test_collatz() = 
    let rec collatz n =
        //System.Console.WriteLine("%d", n);
        printfn "%d" n
        if n = 1L then
            1L
        else if n % 2L = 0L then
            collatz (n/2L)
        else 
            collatz (n*3L + 1L)

    collatz 837799L

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    let sw = System.Diagnostics.Stopwatch.StartNew()
    printfn "%O" (p22())
    sw.Stop()
    printfn "%i ms" sw.ElapsedMilliseconds

    let s = System.Console.ReadLine()
    0 // return an integer exit code