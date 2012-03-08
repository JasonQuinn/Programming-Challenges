// Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
// 
// 1634 = 1^4 + 6^4 + 3^4 + 4^4
// 8208 = 8^4 + 2^4 + 0^4 + 8^4
// 9474 = 9^4 + 4^4 + 7^4 + 4^4
// As 1 = 1^4 is not a sum it is not included.
// 
// The sum of these numbers is 1634 + 8208 + 9474 = 19316.
// 
// Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.

open System

let isSumOfFith (n: int) =
    let sum = n.ToString().ToCharArray() |> Array.map (fun x -> Math.Pow(float(x.ToString()), 5.0)) |> Array.sum
    float(n) = sum

let sum =
    [2..1000000]
    |> List.filter (fun x -> isSumOfFith x)
    |> List.sum

printfn "%A" sum

Console.ReadKey() |> ignore