// Learn more about F# at http://fsharp.net
open System



let getPrimes =
    let isPrime n =
        let maxFactor = int64(sqrt(float n))
        let rec loop testPrime tog =
            if testPrime > maxFactor then true
            elif n % testPrime = 0L then false
            else loop (testPrime + tog) (6L - tog)
        if n = 2L || n = 3L || n = 5L then true
        elif n <= 1L || n % 2L = 0L || n % 3L = 0L || n % 5L = 0L then false
        else loop 7L 4L
    seq {
        yield 2L;
        yield 3L;
        yield 5L;
        yield! (7L, 4L) |> Seq.unfold (fun (p, tog) -> Some(p, (p + tog, 6L - tog)))
    }
    |> Seq.filter isPrime

let main()=
    let startTime = DateTime.Now
    let primes = getPrimes|> Seq.takeWhile (fun x -> x < int64(Math.Sqrt 600851475143.0))|> Seq.filter(fun x -> 600851475143L % x = 0L) |> Seq.max
    printfn "%A" primes
    let endTime = DateTime.Now;
    let diffTime = endTime-startTime
    printfn "%A" diffTime
    Console.Read() |> ignore
    

main()