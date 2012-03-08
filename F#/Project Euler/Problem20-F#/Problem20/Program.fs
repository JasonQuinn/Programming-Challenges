// n! means n x (n  1) x ... x 3 x 2 x 1
// 
// Find the sum of the digits in the number 100!
open System


let rec factorial n =
    if n = 0I then 1I
    else n * factorial (n - 1I)

let sumOfDigits (number: bigint) = (number.ToString()).ToCharArray() |> Array.map (fun x -> int (x.ToString())) |> Array.sum

let main =
    let answer = sumOfDigits (factorial 100I)
    printfn "%A" answer
    Console.ReadKey() |> ignore