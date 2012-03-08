// The decimal number, 585 = 1001001001 (binary), is palindromic in both bases.
// 
// Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
// 
// (Please note that the palindromic number, in either base, may not include leading zeros.)

open System

let isPalindromeBothBase = fun (x: int) -> 
    let reverse (s:string) = new string(s |> Seq.toArray |> Array.rev)
    x.ToString() = reverse (x.ToString()) && Convert.ToString(x, 2) = reverse (Convert.ToString(x, 2))

let answer = 
    [1..1000000]
    |> List.filter (isPalindromeBothBase)
    |> List.sum

printfn "%A" answer
Console.ReadKey() |> ignore