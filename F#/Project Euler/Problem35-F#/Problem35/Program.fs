// The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
// 
// There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
// 
// How many circular primes are there below one million?

open System
open System.Collections.Generic

let primes = 
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
    getPrimes|> Seq.takeWhile (fun x -> x < int64(1000000)) |> Seq.toList


let isCircularPrime (n: string) =
    let rec isCircularPrimeRec (n: string) start =
        if n.Length > 1 && (n.Contains("0") || n.Contains("2") || n.Contains("4") || n.Contains("5") || n.Contains("6") || n.Contains("8")) then 
                false
        else if n = start then
            if (primes |> List.tryFind(fun x -> x = int64(n))) <> None then
                true
            else
                false
        else
            if (primes |> List.tryFind(fun x -> x = int64(n))) <> None then
                isCircularPrimeRec (n.Substring(1) + n.Substring(0, 1)) start
            else
                false
    isCircularPrimeRec (n.Substring(1) + n.Substring(0, 1)) n

let answer =
    [2..1000000]
    |> List.filter (fun x -> isCircularPrime (x.ToString()))
    |> List.length

printfn "%A" answer
Console.ReadKey() |> ignore