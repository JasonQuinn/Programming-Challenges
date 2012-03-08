// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
// 
// Find the sum of all the primes below two million.
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
    let primeSum = getPrimes|> Seq.takeWhile (fun x -> x < int64(2000000)) |> Seq.sum
    printfn "%A" primeSum
    Console.ReadKey() |> ignore

main()