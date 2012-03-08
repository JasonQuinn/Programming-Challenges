// Learn more about F# at http://fsharp.net
open System

//BruteForce
//
//
//let divisibleByList list n =
//    Seq.forall (fun x -> n % x = 0) list
//
//let rec getAnswer i = 
//    if (divisibleByList [1 .. 20] i) 
//    then i
//    else getAnswer (i + 20)
//
//let answer = getAnswer 20
//
//let main()=
//    printfn "%A" (answer)
//    Console.Read() |> ignore
//
//main()



//using lowest common dinominator

// Greater Common Divisor
let rec gcd x y =
  if y = 0I then x
  else gcd y (x%y)

// Least Common Multiple
let lcm x y =
  if x = 0I || y = 0I then 0I
  else (x / (gcd x y)) * y

let answer = [1I..20I] |> List.reduce lcm

let main()=
    printfn "%A" answer
    Console.Read() |> ignore

main()