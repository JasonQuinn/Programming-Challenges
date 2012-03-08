// Learn more about F# at http://fsharp.net

module Program
open System
open System.IO
open System.Diagnostics

let hands =  
    let getStringFromFile =  
        use s = File.OpenRead("../../poker.txt")
        use r = new StreamReader(s)
        r.ReadToEnd()
    [for i in getStringFromFile.Split([| "\r\n" |], StringSplitOptions.RemoveEmptyEntries) -> PokerHands.Hands.Create i]

[<EntryPoint>]
let Main(args) = 
    
    let card = PokerHands.Card.Create("KC")
    printfn "%s" (card.ToString())
    timer.Stop()
    printfn "Timer - %s" (timer.Elapsed.ToString())
    Console.ReadLine() |> ignore 
    0