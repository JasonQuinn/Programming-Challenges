﻿// The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:
// 
// 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
// 
// Let us list the factors of the first seven triangle numbers:
// 
//  1: 1
//  3: 1,3
//  6: 1,2,3,6
// 10: 1,2,5,10
// 15: 1,3,5,15
// 21: 1,3,7,21
// 28: 1,2,4,7,14,28
// We can see that 28 is the first triangle number to have over five divisors.
// 
// What is the value of the first triangle number to have over five hundred divisors?
open System
open System.Diagnostics

//Number Of Divisors
let rec numOfDivisorsRec n divisor count =
    let quotient = n / divisor
    if quotient > divisor then
        if n % divisor = 0 then
            numOfDivisorsRec n (divisor + 1) (count + 2)
        else
            numOfDivisorsRec n (divisor + 1) count
    else
        if quotient = divisor && n % divisor = 0 then
            (count + 1)
        else
            count

let numOfDivisors n = numOfDivisorsRec n 2 2
//end


let rec traingleNumbers num total =
    Debug.Assert(num >= 0)
    Debug.Assert (total >= 0)
    if numOfDivisors total >= 500 then
        total
    else
        traingleNumbers (num + 1) (total + num)

printfn "%A" (traingleNumbers 1 0)
Console.ReadKey() |> ignore