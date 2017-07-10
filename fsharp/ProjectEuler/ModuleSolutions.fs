module Solutions
open NUnit.Framework

// http://fsharpforfunandprofit.com/posts/list-module-functions/#13
// http://fsharpforfunandprofit.com/posts/list-module-functions/#23

open System
open System.Text.RegularExpressions

type EulerProblemAttribute (nr:int, Result:string) =
    inherit System.Attribute()
    member this.ProblemNr = nr
    member thus.Result = Result


let inline ( |>! ) x sideEffect =
    do sideEffect x
    x

let tap (action : 'T -> unit) (value : 'T) : 'T =
    action value
    value

//open SolutionResources

//let inline retype (x:'a) : 'b = (# "" x : 'b #)
//let inline sqrt_int (n:'a) = retype (sqrt (float n)) : 'a

let fibonacciSeq = Seq.unfold(fun(a,b) -> Some(a, (b, a+b))) (0,1)

let sqrtCeilInt64 = double >> sqrt >> ceil >> int64
    
let inline findDividersOf n = 
    let limit = int64(Math.Sqrt(double(n)))
    let factors = seq {
        for i in 1L .. limit do
            if n % i = 0L then 
                yield i
                yield n/i
    }
    factors |> Seq.sort

let inline properDivisorsOf n =
    findDividersOf n |> Seq.where (fun x -> x <> n)

let isPrime n =
    let rec check i =
        i > n/2L || (n % i <> 0L && check (i + 1L))
    check 2L

let primeSeq (limit:int64) = seq { for n in 2L..(limit) do if isPrime n then yield n }

let findPrimeFactorsOf(n:int64) =
    if n <= 1L then
        []
    else 
        let factors = 
            primeSeq (n/2L)
            |> Seq.filter (fun x -> n % x = 0L) 

        if Seq.isEmpty factors then
            [n]
        else
            factors |> Seq.toList

let factorize (n: int64) =
    let factors = findPrimeFactorsOf n |> Seq.toList

    let rec solve (n : int64) (factors : seq<int64>) =
        if Seq.length factors = 0 then
            []
        else
            let f1 = factors |> Seq.item(0)

            if n % f1 = 0L then
                [f1] @ solve (n / f1) (factors)
            else
                solve (n) (factors |> Seq.skip 1)

    solve n factors

let factorize2 (n: int64) = 
    factorize n
    |> Seq.map (fun x -> (x,1L)) 
    |> Seq.groupBy fst 
    |> Seq.map (fun (key, values) -> (key, values |> Seq.sumBy snd))

let findMaxPrimeFactorOf(n:int64) =
    factorize n
    |> Seq.max

let inline binomal_coefficient (n:int64, k:int64) = 
    match (n,k) with
    | (0L,_) | (_,0L) -> 1L
    | (_,_) when n = k -> 1L
    | (n,k) -> 
        [1L..k]
        |> List.fold (fun acc i -> acc * (n - k + i)/i) 1L

let binomal_coefficient_rec (n, k) = 
    let rec bc (n, k, i) = 
        match (n, k, i) with
        | (0,0,_) -> 1
        | (_,0,_) -> 1
        | (_,_,_) when n = k -> 1
        | (_,_,_) when i <= k -> (n-k+1) / i * bc (n, k, i+1)
        | (_,_,_) -> 0

    if 2*k > n then
        bc (n, n - k, 1)
    else
        bc (n, k, 1)

[<TestCase(Result=233168)>]
let p1() = {1..999} |> Seq.filter (fun x -> x % 3 = 0 || x % 5 = 0) |> Seq.sum

[<TestCase(Result=4613732)>]
let p2() = 
    fibonacciSeq 
    |> Seq.takeWhile (fun x -> x <= (4*1000*1000))
    |> Seq.filter (fun x -> x % 2 = 0)
    |> Seq.sum

[<TestCase(Result=6857L)>]
let p3() =
    600851475143L 
    |> findDividersOf
    |> Seq.filter isPrime
    |> Seq.max

[<TestCase(Result=906609)>]
let p4() =
    let isPalindromic n =
        let chars = n.ToString().ToCharArray()
        let revChars = Array.rev chars
        chars = revChars

    let numbers = [100..999]
    let products = List.collect (fun x -> numbers |> List.map (fun y -> x * y)) numbers
    
    products |> Seq.filter isPalindromic |> Seq.max

[<TestCase(Result=232792560L)>]
let p5() =
    [1L..20L] 
    |> Seq.map factorize2 
    |> Seq.filter (not << Seq.isEmpty) 
    |> Seq.concat 
    |> Seq.groupBy fst 
    |> Seq.map (fun (key, values) -> Seq.max values) 
    |> Seq.map (fun (b, e) -> pown (int(b)) (int(e)) ) 
    |> Seq.reduce (*);;

[<TestCase(Result=25164150)>]
let p6() = 
    let x = 100
    let a = [1..x] |> Seq.reduce (+) |> (fun x -> pown x 2)
    let b = [1..x] |> Seq.map (fun x -> pown x 2) |> Seq.reduce (+)
    abs (b - a)

[<TestCase(Result=104743)>]
let p7() =
    primeSeq 1000000L
    |> Seq.take 10001
    |> Seq.last

let inline debug x =
    printfn "%A" x
    x

[<TestCase(Result=23514624000L)>]
let p8() =
    let s = (SolutionResources.p8_input.Replace("\r\n", ""))
    let l = 13

    let intAarray = s |> Seq.map (string >> int64)
       
    let chunkProduct intAarray = 
        intAarray 
        |> Seq.chunkBySize l
        |> Seq.map (fun x -> (x, Seq.reduce (*) x))

    let res = 
        [0..l] 
        |> Seq.map (fun x -> Seq.skip x intAarray)
        |> Seq.map chunkProduct
        |> Seq.concat
        |> Seq.sortBy snd  

    //res |> Seq.toList |> printfn "%A"
    res |> Seq.last |> printfn "%A"
    res |> Seq.last |> snd

[<TestCase(Result=31875000)>]
let p9() =
    let inline isAscending arr = 
        Array.pairwise arr
        |> Array.forall (fun (a, b) -> a < b)

    let inline isSum1000 a b c =
        a + b + c = 1000

    let inline isPyhtagoreanTriplet a b c =
        a*a + b*b = c*c

    let inline isSpecialPyhtagoreanTriplet (arr : int[]) =
        (isSum1000 arr.[0] arr.[1] arr.[2])
        && (isPyhtagoreanTriplet arr.[0] arr.[1] arr.[2])
        && (isAscending arr) 

    let n=1000

    let triplets = 
        seq { 
            for x in 1..n/3 do 
                for y in x+1..((n-x)/2) do 
                    let z = n-x-y
                    yield [|x; y; z|]
            }

    //printfn "%A" triplets

    let sw = System.Diagnostics.Stopwatch.StartNew()

    //triplets |> Seq.iter (printfn "%A")

    //printfn "test"

    let res = 
        triplets 
        //|> Seq.filter isPyhtagoreanTriplet
        |> Seq.filter isSpecialPyhtagoreanTriplet
        |> Seq.head
    sw.Stop()

    //printfn "%i ms" sw.ElapsedMilliseconds

    res |> Array.reduce (*)
//    let n = 11
//    let aLst = [1..n-2]
//    let bList = [2..n-1]
//    Seq.map2 (fun x y -> (x, y, 1000 - x - y)) [1..1000] [1..1000]

[<TestCase(Result=142913828922L)>]
let p10_1() =  // 2860ms
    let n = 2L * (pown 10L 6)

    let sieve1 = Array.append [|0L;0L|] [|2L..n|]

    //printfn "%A" sieve1

    let sieve2 = seq {
                    for x in 2L..n do
                        for y in (x*2L)..x..n do
                            yield y
                    }
    
    //printfn "%A" sieve2

    sieve2 |> Seq.iter (fun x -> sieve1.[int x] <- 0L)


    //printfn "%A" sieve1

    sieve1 |> Array.sum

[<TestCase(Result=142913828922L)>]
let p10_2() = // 2800ms
    let n = 2 * (pown 10 6)

    let sieve1 = Array.create (n+1) true
    sieve1.[0] <- false
    sieve1.[1] <- false

    //printfn "%A" sieve1

    let sieve2 = seq {
                    for x in 2..n do
                        for y in (x*2)..x..n do
                            yield y
                    }
    
    //printfn "%A" sieve2

    sieve2 |> Seq.iter (fun x -> sieve1.[int x] <- false)


    //printfn "%A" sieve1

    sieve1
        |> Array.mapi (fun i v -> if v then int64(i) else 0L) 
        |> Array.sum

[<TestCase(Result=142913828922L)>]
let p10_3() =  // 1000ms
    let n = 2 * (pown 10 6)
    let sieve = Array.append [|0;0|] [|2..n|]

    let rec filterPrime p = 
        seq {for mul in (p*2)..p..n do 
                yield mul}
            |> Seq.iter (fun mul -> sieve.[mul] <- 0)
    
        let nextPrime = 
            seq { 
                for i in p+1..n do 
                    if sieve.[i] <> 0 then 
                        yield sieve.[i]
            }
            |> Seq.tryHead

        match nextPrime with
            | None -> ()
            | Some np -> filterPrime np

    filterPrime 2

    sieve
        |> Array.toSeq 
        |> Seq.filter (fun x -> x <> 0)
        |> Seq.map int64
        |> Seq.sum

[<TestCase(Result=70600674)>]
let p11() =
    let lines = SolutionResources.p11_input.Split([|"\n"|], StringSplitOptions.None)
    let m = //matrix
        lines
        |> Array.map (fun x -> x.Split(' ')) 
        |> Array.map (Array.map int)

    let foo x y dx dy =
        [0..3]
        |> List.map (fun offset -> m.[y+(dy*offset)].[x+(dx*offset)]) 

    let adjNumbers = 
        [for x in 0..19 do
            for y in 0..15 do 
                //yield List.map (fun offset -> m.[y+offset].[x]) [0..3]
                yield foo x y 0 1
        ] @
        [for x in 0..15 do
            for y in 0..19 do 
                //yield List.map (fun offset -> m.[y].[x+offset]) [0..3]
                yield foo x y 1 0
        ] @
        [for x in 0..15 do
            for y in 0..15 do 
                //yield List.map (fun offset -> m.[y+offset].[x+offset]) [0..3]
                yield foo x y 1 1
        ] @
        [for x in 3..10 do
            for y in 0..15 do 
                //yield List.map (fun offset -> m.[y+offset].[x-offset]) [0..3]
                yield foo x y -1 1
        ]

    adjNumbers 
        |> List.map (List.reduce (*)) 
        |> List.max

[<TestCase(Result=76576500)>]
let p12() =
    let inline triangleNumber x =
        (x * x + x) >>> 1

    let triangleNumbers = 
        Seq.unfold (fun n -> Some(n, n + 1L)) 1L
        |> Seq.map triangleNumber

    printf "%A" triangleNumbers

    let res = 
        triangleNumbers
        |> Seq.skipWhile (fun x -> ((findDividersOf >> Seq.length) x < 501))
        |> Seq.head

    res

[<TestCase(Result=5537376230L)>]
let p13() = 
    let splitLines (s:string) = 
        List.ofSeq(s.Split([|'\n'|]))

    let sum = 
        SolutionResources.p13_input
        |> splitLines
        |> Seq.map bigint.Parse
        |> Seq.sum

    //(sum |> string).[..9]
    let res =
        sum 
        |> string 
        |> Seq.take 10
        |> String.Concat

    res |> int64

let p14_reverse max =
    let next x:int64 =
        if (x-1L) % 3L = 0L && (x-1L) / 3L > 1L then
            (x-1L) / 3L
        else 
            x * 2L

    let collatzSeq = 
        Seq.unfold (fun x -> 
            let state = fst x
            let index = snd x
            if state > max then
                None
            else
                Some ((state, index), (next state, index + 1L))
        ) (1L, 1L)

    collatzSeq

[<TestCase(Result=837799)>]
let p14() =
    let max = 1000000L

    let mutable cache = p14_reverse max |> Map.ofSeq

    let rec collatzLen (n:int64, depth:int64) =
        if n < 1L then
            failwith "N cannot be smaller then 1."

        if cache.ContainsKey(n) then
            cache.[n] + depth
        else 
            cache <- cache.Add(n, depth)

            if n = 1L then
                depth
            else if n % 2L = 0L then 
                collatzLen ((n/2L), (depth+1L))
            else 
                collatzLen ((3L*n + 1L), (depth+1L))

    let collatzes = seq {for i in 1L..1000000L -> (i, collatzLen (i, 1L))}

    let res =
        collatzes 
        |> Seq.sortByDescending (fun x -> snd x)
        |> Seq.head

    res

[<TestCase(Result=137846528820L)>]
let p15() =
    binomal_coefficient (40L, 20L)

[<TestCase(Result=1366)>]
let p16() = 
    2I ** 1000
    |> string 
    |> Seq.map (string >> int) 
    |> Seq.sum 

[<TestCase(Result=21124)>]
let p17() =
    [1..1000] 
    |> List.map Functions.toWord 
    //|> List.map debug
    |> List.reduce (+)
    |> Seq.where (fun c -> c <> '-' &&  c <> ' ')
    |> Seq.length

let p18_pyramid_max_path_sum (pyramidStr:string) = 
    let pyramid =
        let lines = pyramidStr.Split '\n'
        [for line in lines -> 
            [for c in line.Split ' ' -> int c]
        ]

    let inline max2 (x,y) =
        max x y

    let res = 
        pyramid
        |> List.reduceBack (fun row state -> 
            List.map2 (+) (state |> List.pairwise |> List.map max2) row
        )
        |> List.head

    res

[<TestCase(Result=1074)>]
let p18() =
    p18_pyramid_max_path_sum SolutionResources.p18_input

[<TestCase(Result=7273)>]    
let p67() =
    p18_pyramid_max_path_sum SolutionResources.p67_input

[<TestCase(Result=171)>]
let p19() = 
    let start = new DateTime(1901, 1, 1)
    let endDate = new DateTime(2000, 12, 31)
    let f x = 
        if x <= endDate then 
            Some (x, x.AddDays 1.0)
        else
            None
    let s = Seq.unfold f start |> Seq.filter (fun x -> x.DayOfWeek = DayOfWeek.Sunday && x.Day = 1)

    s |> Seq.length

[<TestCase(Result=648)>]
let p20() = 
    let facOf100 = [1I..100I] |> Seq.reduce (*)

    facOf100
    |> string
    |> Seq.map (string >> int)
    |> Seq.sum

[<TestCase(Result=31626)>]
let p21() = 
    let amic a =
        let b = properDivisorsOf a |> Seq.sum
        let c = properDivisorsOf b |> Seq.sum
        (a,b,c)

    let amici_numbers =
        seq {1L..9999L}
        |> Seq.map amic
        |> Seq.where (fun (a,b,c) -> a <> b && a=c)

    amici_numbers
    |> Seq.map (fun (a,b,c) -> a)
    |> Seq.sum

[<TestCase(Result=871198282)>]
let p22() = 
    let text = FSharp.Data.Http.RequestString("https://projecteuler.net/project/resources/p022_names.txt")

    let letterSum (str:string) =
        str
        |> Seq.map (fun c -> (int64 c) - 96L)
        |> Seq.toList
        |> List.sum

    let normalized =
        text.Split [|','|]
        |> Array.toList
        |> List.sort
        |> List.map (fun s -> s.ToLower()) 
        |> List.map (fun s -> s.Replace("\"", ""))
    
    let res =
        normalized
        |> List.map letterSum
        |> List.mapi (fun index rowSum -> ((int64 index) + 1L) * rowSum)
        |> List.sum
    res


[<TestCase(Result=4782)>]
let p25() = 
    let fib = Seq.unfold (fun (s,o) -> Some(s, (s,s+o))) (0,1)

    0

//
//[<TestCase(Result=)>]
//let p() = 