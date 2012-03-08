// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
// 
// What is the 10001st prime number?
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

let main() =
    let prime = Seq.nth (10001 - 1) getPrimes
    printfn "%A" prime
    Console.Read() |> ignore

main()