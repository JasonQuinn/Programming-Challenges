// The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.
// 
// Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.

open System

let rec pow num power =
    if power <= 1I then num
    else
        num * (pow num (power - 1I))

let sumPowers max =
    let list = [1I..max]
    list |> List.map (fun x -> pow x x) |> List.sum

let last10Digits max = 
    let digitsString = (sumPowers max).ToString()
    digitsString.Substring(digitsString.Length - 10, 10)

printfn "%A" (last10Digits 1000I)
Console.ReadKey() |> ignore