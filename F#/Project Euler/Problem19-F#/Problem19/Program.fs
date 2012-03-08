// You are given the following information, but you may prefer to do some research for yourself.
// 
// 1 Jan 1900 was a Monday.
// Thirty days has September,
// April, June and November.
// All the rest have thirty-one,
// Saving February alone,
// Which has twenty-eight, rain or shine.
// And on leap years, twenty-nine.
// A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
//
// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?

open System

let rec numberOfSundays (date: DateTime) (endDate: DateTime) count =
    if date >= endDate then
        count
    else
        let day = new TimeSpan(1, 0, 0, 0)
        let nextDate = date + day
        if date.Day = 1 && date.DayOfWeek = DayOfWeek.Sunday then
            numberOfSundays nextDate endDate (count + 1)
        else
            numberOfSundays nextDate endDate (count)

let answer =
    let startDate = new DateTime(1901, 1 , 1)
    let endDate = new DateTime(2000, 12 , 31)
    numberOfSundays startDate endDate 0

printfn "%A" answer
Console.ReadKey() |> ignore