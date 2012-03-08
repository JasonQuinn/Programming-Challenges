// The following iterative sequence is defined for the set of positive integers:
// 
// n -> n/2 (n is even)
// n -> 3n + 1 (n is odd)
// 
// Using the rule above and starting with 13, we generate the following sequence:
// 
// 13 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1
// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
// 
// Which starting number, under one million, produces the longest chain?
// 
// NOTE: Once the chain starts the terms are allowed to go above one million.
open System

let rec collatzAnswer (number:bigint) count =
    if number <= 1I then 
        count
    else
        if number % 2I = 0I then
            collatzAnswer (number / 2I) (count + 1)
        else
            collatzAnswer ((number * 3I) + 1I) (count + 1)

let rec numberUnderOneMillion count maxSeqCount maxSeqNumber =
    if count >= 1000000 then
        maxSeqNumber
    else
        let seqCount = collatzAnswer (bigint count) 1
        if seqCount > maxSeqCount then
            numberUnderOneMillion (count + 2) seqCount count
        else
            numberUnderOneMillion (count + 2) maxSeqCount maxSeqNumber

printfn "%A" (numberUnderOneMillion 1 0 0)
Console.ReadKey() |> ignore