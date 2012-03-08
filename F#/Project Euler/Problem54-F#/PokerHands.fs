module PokerHands

let fromFaceValue = function
    | 'A' -> 14
    | 'K' -> 13
    | 'Q' -> 12
    | 'J' -> 11
    | 'T' -> 10
    | c -> int c

let toFaceValue = function
    | 14 -> 'A'
    | 13 -> 'K'
    | 12 -> 'Q'
    | 11 -> 'J'
    | 10 -> 'T'
    | c -> char c
    
type Card(value:int, suit:char) =
    member x.Value
        with get() = value
    member x.Suit
        with get() = suit
    
    static member Create(n:string) = 
        Card(fromFaceValue n.[0], n.[1])

    override x.ToString() =
        sprintf "Rank: %c" (toFaceValue value) + sprintf " Suit: %c"  suit

    interface System.IComparable with
        member x.CompareTo(y) =
            let otherCard = y :?> Card in
            compare value otherCard.Value
            
type Ranking =
    | High of int list
    | Pair of int * int list
    | TwoPair of int * int * int
    | Three of int * int list
    | Straight of int list
    | Flush of int list
    | FullHouse of int * int
    | Four of int * int
    | StraightFlush of int list
    | RoyalFlush
with override x.ToString() =
        match x with
        | RoyalFlush _ -> "Royal Flush"
        | StraightFlush _ -> "Straight Flush"
        | Four _ -> "Four of a Kind"
        | FullHouse _ -> "Full House"
        | Flush _ -> "Flush"
        | Straight _ -> "Straight"
        | Three _ -> "Three of a Kind"
        | TwoPair _ -> "Two Pair"
        | Pair _ -> "Pair"
        | High _ -> "High Card"
    
type Hand(cards:seq<Card>) =
    member x.Cards
        with get() = cards
        
type Hands(p1:Hand, p2:Hand) =
    member x.Player1
        with get() = p1
    member x.Player2
        with get() = p2

    static member Create(s:string) = 
        let cards =  [for i in s.Split([|' '|]) -> Card.Create i]
        Hands(Hand(cards |> Seq.take 5), Hand(cards |> Seq.skip 5 |> Seq.take 5))
        
let value(c:Card) = c.Value
let suit(c:Card) = c.Suit

let group_values(h:Hand) =
    [for v, l in Seq.groupBy value h.Cards -> v, Seq.length l]
    |> List.sortBy (fun (v, l) -> l, v)
    |> List.rev

let test_same h =
    match group_values h with
    | (n, 4) :: l -> Four (n, fst l.[0])
    | (n, 3) :: (n2, 2) :: _ -> FullHouse (n, n2)
    | (n, 3) :: l -> Three (n, [fst l.[0]; fst l.[1]])
    | (n, 2) :: (n2, 2) :: l -> TwoPair (n, n2, fst l.[0])
    | (n, 2) :: l -> Pair (n, l |> Seq.take 3 |> Seq.toList |> List.map fst)
    | l -> High (l |> Seq.take 5 |> Seq.toList |> List.map fst)

//let test_sequence h =
//    Seq.map value
//    >> Seq.distinct
//    >> Seq.sortBy (~-)
//    >> Seq.windowed 5
//    >> Seq.tryFind (fun s -> s = [|s.[0] .. -1 .. s.[0]-4|])
//
//let get_highest n =
//    Seq.map value
// >> Seq.sortBy (~-)
// >> Seq.take 5
// >> Seq.toList
//
//let test_various h =
//    Seq.groupBy suit h
//    |> Seq.filter (fun (_,l) -> Seq.length l >= 5)
//    |> Seq.toList
//    |> function
//    | [_, cards] ->
//        match test_sequence cards with
//        | Some l when l.[0] = 14 -> RoyalFlush
//        | Some l -> StraightFlush (Seq.toList l)
//        | None -> Flush (cards |> get_highest 5)
//    | _ ->
//        match test_sequence h with
//        | Some l -> Straight (Seq.toList l)
//        | _ -> High []