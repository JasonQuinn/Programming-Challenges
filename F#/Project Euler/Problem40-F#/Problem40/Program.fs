// An irrational decimal fraction is created by concatenating the positive integers:
// 
// 0.123456789101112131415161718192021...
// 
// It can be seen that the 12th digit of the fractional part is 1.
// 
// If dn represents the nth digit of the fractional part, find the value of the following expression.
// 
// d1 x d10 x d100 x d1000 x d10000 x d100000 x d1000000

open System
open System.Text

let start = DateTime.Now

let concatInts max =
    let rec concatIntRec max current (str: StringBuilder) =
        if str.Length >= max then
            str
        else
            concatIntRec max (current + 1) (str.Append(current))
    concatIntRec max 1 (new StringBuilder())    

let getAt (str: StringBuilder) n = int(str.Chars(n - 1).ToString())

let answer =
    let number = concatInts 1000000
    getAt number 1 * getAt number 10 * getAt number 100 * getAt number 1000 * getAt number 10000 * getAt number 100000 * getAt number 1000000

printfn "%A" answer
let finish = DateTime.Now
printfn "%A" (finish - start)
Console.ReadKey() |> ignore