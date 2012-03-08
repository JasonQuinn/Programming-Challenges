// A Pythagorean triplet is a set of three natural numbers, a  b  c, for which,
// 
// a^2 + b^2 = c^2
// For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
// 
// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
// Find the product abc.
open System

let targetSum = 1000

let isPythagoreanTriplet (a:int) (b:int) (c:int) = Math.Pow(float a , 2.0) + Math.Pow(float b , 2.0) = Math.Pow(float c , 2.0)

let isTargetSum a b c = a + b + c = targetSum

let rec tryNumbers a b c =
    if isTargetSum a b c && isPythagoreanTriplet a b c then
        a * b * c
    else if c >= 1000 then
        tryNumbers a (b + 1) 0
    else if b >= 1000 && b >= c then
        tryNumbers (a + 1) 0 0
    else 
        tryNumbers a b (c+1)

let main() = 
    let answer = tryNumbers 1 1 1
    printfn "%A" answer
    Console.ReadKey() |> ignore

main()