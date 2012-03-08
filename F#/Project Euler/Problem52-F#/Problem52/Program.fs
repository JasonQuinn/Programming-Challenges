// It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.
// 
// Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.

open System

let startTime = DateTime.Now

let sameDigits (n: int) numOfTimes=
    let isSame n1 multiplier = (n1.ToString().ToCharArray() |> Array.sort) = ((n1 * multiplier).ToString().ToCharArray() |> Array.sort)
    let rec sameDigitsRec x multiplier numOfTimes =
        if multiplier > numOfTimes then true
        else
            if (int(n.ToString().ToCharArray().[0].ToString()) * numOfTimes) < 10 && isSame x multiplier then sameDigitsRec x (multiplier + 1) numOfTimes
            else false
    sameDigitsRec n 2 6

let getNumber =
    let rec getNumberRec n =
        if sameDigits n 6 then n
        else getNumberRec (n + 1)
    getNumberRec 1
    
printfn "Answer-%A" getNumber
printfn "Time-%A" (DateTime.Now - startTime)
Console.ReadKey() |> ignore