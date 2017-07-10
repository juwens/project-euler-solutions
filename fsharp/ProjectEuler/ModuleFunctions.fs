module Functions

open NUnit.Framework

[<AutoOpen>]
module DivRem =
    type DivRem = DivRem with
        static member (/%) (x : int32,  DivRem) = fun y -> System.Math.DivRem(x, y)
        static member (/%) (x : int64,  DivRem) = fun y -> System.Math.DivRem(x, y)
        static member (/%) (x : bigint, DivRem) = fun y -> System.Numerics.BigInteger.DivRem(x, y)

    let inline (/%) x y = (x /% DivRem) y

open DivRem

let rec toWord n =
    let nE3 = n / 1000
    let nE2 = (n % 1000) / 100
    let nE1 = (n % 100) / 10
    let nE0 = (n % 10)

    let rec tw =
        function   
            | (0,0,0,0) -> ""
            | (0,0,0,1) -> "one"
            | (0,0,0,2) -> "two"
            | (0,0,0,3) -> "three"
            | (0,0,0,4) -> "four"
            | (0,0,0,5) -> "five"
            | (0,0,0,6) -> "six"
            | (0,0,0,7) -> "seven"
            | (0,0,0,8) -> "eight"
            | (0,0,0,9) -> "nine"
            | (0,0,1,0) -> "ten"
            | (0,0,1,1) -> "eleven"
            | (0,0,1,2) -> "twelve"
            | (0,0,1,3) -> "thirteen"
            | (0,0,1,5) -> "fifteen"
            | (0,0,1,x) -> (tw (0,0,0,x)) + "teen"

            | (0,0,2,x) -> "twenty-" + (toWord x)
            | (0,0,3,x) -> "thirty-" + (toWord x)
            | (0,0,4,x) -> "forty-" + (toWord x)
            | (0,0,5,x) -> "fifty-" + (toWord x)
            | (0,0,y,0) -> (tw (0,0,0,y)) + "ty"

            | (0,0,y,x) -> (tw (0,0,0,y)) + "ty-" + (tw (0,0,0,x))
            | (0,z,0,0) -> (tw (0,0,0,z)) + " hundred"
            | (0,z,y,x) -> (tw (0,0,0,z)) + " hundred and " + (tw (0,0,y,x))
            | (u,0,0,0) -> (tw (0,0,0,u)) + " thousand"
            | _ -> failwith "undef"

    (tw (nE3, nE2, nE1, nE0)).Replace("tt", "t").TrimEnd('-')

module testIntToWord = 
    [<TestCase(1, Result="one")>]
    [<TestCase(9, Result="nine")>]
    [<TestCase(10, Result="ten")>]
    [<TestCase(11, Result="eleven")>]
    [<TestCase(20, Result="twenty")>]
    [<TestCase(25, Result="twenty-five")>]
    [<TestCase(42, Result="forty-two")>]
    [<TestCase(68, Result="sixty-eight")>]
    [<TestCase(80, Result="eighty")>]
    [<TestCase(100, Result="one hundred")>]
    [<TestCase(115, Result="one hundred and fifteen")>]
    [<TestCase(342, Result="three hundred and forty-two")>]
    [<TestCase(623, Result="six hundred and twenty-three")>]
    [<TestCase(1000, Result="one thousand")>]
    let testToWord n =
        toWord n