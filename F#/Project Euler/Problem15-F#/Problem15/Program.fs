// Starting in the top left corner of a 2x2 grid, there are 6 routes (without backtracking) to the bottom right corner.
//  
// How many routes are there through a 20x20 grid?
open System

//Factorial
let rec factorial n =
    if n = 0I then 1I
    else n * factorial (n - 1I)

//

let numberOFWyas x y =
    (factorial (x + y)) / (factorial x * factorial y) 

printfn "%A" (numberOFWyas 2I 20I)
Console.ReadKey() |> ignore