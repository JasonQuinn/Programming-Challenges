//A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91  99.
//
//Find the largest palindrome made from the product of two 3-digit numbers.
open System

let number = 999

let isPalindrome = fun x -> 
    let reverse (s:string) = new string(s |> Seq.toArray |> Array.rev)
    x.ToString() = reverse (x.ToString())

let rec allMultiples x y list = 
    if (x = 0 && y = 0) 
    then 
        list 
        |> List.toSeq
        |> Seq.distinct
        |> Seq.sort        
    else if (y = 0) 
    then 
        allMultiples (x - 1) number list
    else 
        allMultiples x (y - 1) ((x * y) :: list)

let maxPalindrome = 
        allMultiples number number []
        |> Seq.filter isPalindrome
        |> Seq.max

let main() =    
    printfn "Max Palindrome-%A" maxPalindrome
    Console.Read() |> ignore

main()