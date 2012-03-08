// Learn more about F# at http://fsharp.net

open System    

// making an infinite list (sequence)

let fibSet =
   (1,1) |> Seq.unfold ( fun (sqEntry, acc) -> Some (acc, (acc, acc + sqEntry)) )

let rec  fib n = if n < 2 then 1 else  fib (n-2) + fib(n-1) 
 

// utility functions

let isEven i = (i%2=0) 

let isLessThan x y = x < y

 

// making an infinite list (sequence)

let euler2 = fibSet
                |> Seq.takeWhile (fun x -> (isLessThan x 4000000))
                |> Seq.filter (fun x -> isEven x)
                |> Seq.sum

let main() = 
    printfn "%A" euler2
    Console.ReadLine() |> ignore    

let printfibNumberSet c =
    for x in 1..c do
        printf "%A," (fib x)

main()