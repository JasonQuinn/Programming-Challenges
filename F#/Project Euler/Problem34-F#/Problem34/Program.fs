// 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
// 
// Find the sum of all numbers which are equal to the sum of the factorial of their digits.
// 
// Note: as 1! = 1 and 2! = 2 are not sums they are not included.

open System

//Factorial
let rec factorial n =
    if n = 0I then 1I
    else n * factorial (n - 1I)
//

let isCuriousNumber (n: bigint) = 
    n = (n.ToString().ToCharArray() |> Array.map (fun y -> factorial (bigint.Parse(y.ToString()))) |> Array.sum)

let upperBound =
    let rec upperBoundRec max =
        if max > (max.ToString().ToCharArray() |> Array.map (fun y -> factorial (bigint.Parse(y.ToString()))) |> Array.sum) then
            max
        else
            upperBoundRec (bigint.Parse("9" + max.ToString()))
    upperBoundRec 9I 

let answer =
    [3I..upperBound]
    |> List.filter (fun x -> isCuriousNumber x)
    |> List.sum

printfn "%A" answer
Console.ReadKey() |> ignore