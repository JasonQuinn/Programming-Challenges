// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
// 
// What is the sum of the digits of the number 2^1000?
open System

let rec power (number: bigint) pow (value: bigint) =
    if pow = 0 then
        value
    else
        power number (pow - 1) (value * number)

let sumfDigits (number:bigint) =
    (number.ToString()).ToCharArray() |> Array.map (fun x -> int(x.ToString())) |> Array.sum

let main = 
    let answer = sumfDigits (power 2I 1000 1I)
    printfn "%A" answer
    Console.ReadKey() |> ignore

main