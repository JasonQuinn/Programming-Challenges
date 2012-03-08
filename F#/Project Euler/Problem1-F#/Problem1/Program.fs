// Learn more about F# at http://fsharp.net

open System
    

let calc n = 
    [1..n]
    |> List.filter (fun x -> x % 3 = 0 || x % 5 = 0)
    |> List.sum;;

   

let main() = 
    printfn "result = %d" (calc 999)
    Console.ReadKey(true) |> ignore 
    

main()