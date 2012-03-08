// Learn more about F# at http://fsharp.net
open System

let square x = x * x

let sumOfSquares list = List.map (fun x -> x * x) list
                        |> List.sum
                        
let squareOfSum (list: List<int>) = List.sum list
                                    |> square

let main() = 
    let list = [1 .. 100]
    printfn "%A" (squareOfSum list - sumOfSquares list)
    Console.ReadLine() |> ignore

main()

       
                                      