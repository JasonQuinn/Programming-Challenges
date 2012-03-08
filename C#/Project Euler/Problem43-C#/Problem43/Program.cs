using System;
using System.Collections.Generic;
using System.Linq;

// http://projecteuler.net/index.php?section=problems&id=43
//
// The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.
// 
// Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:
// 
// d2d3d4=406 is divisible by 2
// d3d4d5=063 is divisible by 3
// d4d5d6=635 is divisible by 5
// d5d6d7=357 is divisible by 7
// d6d7d8=572 is divisible by 11
// d7d8d9=728 is divisible by 13
// d8d9d10=289 is divisible by 17
// Find the sum of all 0 to 9 pandigital numbers with this property.
namespace Problem43
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine(NextNumber(NextNumber(2, NextNumber(3, NextNumber(5, NextNumber(7, NextNumber(11, NextNumber(13, Number(17)))))))).Select(u => long.Parse(u)).Sum());
            Console.ReadLine();
        }

        static List<string> Number(int targetNumber)
        {
            var numberList = new List<string>();
            for (var iOne = 0; iOne < 10; iOne++)
            {
                for (var iTwo = 0; iTwo < 10; iTwo++)
                {
                    if (iOne != iTwo)
                    {
                        for (var iThree = 0; iThree < 10; iThree++)
                        {
                            var number = iOne.ToString() + iTwo.ToString() + iThree.ToString();
                            if (number.ToList().Distinct().Count() == 3 && int.Parse(number) % targetNumber == 0)
                            {
                                numberList.Add(number);
                            }
                        }
                    }
                }
            }
            return numberList;
        }

        static List<string> NextNumber(int? targetNumber, List<string> currentList)
        {
            var newList = new List<string>();
            foreach (string currentNumber in currentList)
            {
                for (var iOne = 0; iOne < 10; iOne++)
                {
                    string number = iOne + currentNumber.Substring(0, 2);
                    if (!currentNumber.Contains(iOne.ToString()) && (int.Parse(number) % targetNumber == 0 || targetNumber == null))
                    {
                        newList.Add(iOne + currentNumber);
                    }
                }
            }
            return newList;
        }

        static List<string> NextNumber(List<string> currentList)
        {
            return NextNumber(null, currentList);
        }










        //    static void Main()
        //    {
        //        Console.WriteLine(SumDivisiblePandigital());
        //        Console.ReadLine();
        //    }

        //    private static long SumDivisiblePandigital()
        //    {
        //        long sum = 0;
        //        for (long i = 1023456789; i < 9876543210; i++)
        //        {
        //            if (FullDivisiblePandigital(i.ToString()))
        //            {
        //                sum += i;
        //            }
        //        }
        //        return sum;
        //    }

        //    private static bool FullDivisiblePandigital(string number)
        //    {
        //        if (Divisible(number, 8, 17))
        //        {
        //            if (Divisible(number, 7, 13))
        //            {
        //                if (Divisible(number, 6, 11))
        //                {
        //                    if (Divisible(number, 5, 7))
        //                    {
        //                        if (Divisible(number, 4, 5))
        //                        {
        //                            if (Divisible(number, 3, 3))
        //                            {
        //                                if (Divisible(number, 2, 2))
        //                                {
        //                                    if (IsPandigital(number))
        //                                    {
        //                                        return true;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return false;
        //    }

        //    private static bool Divisible(string number, int startDigit, int divisor)
        //    {
        //        return int.Parse(number.Substring(startDigit - 1, 3)) % divisor == 2;
        //    }

        //    static bool IsPandigital(string number)
        //    {
        //        if (number.Length == 10)
        //        {
        //            if (number.Contains('0') && number.Contains('1') && number.Contains('2') && number.Contains('3') && number.Contains('4') && number.Contains('5') &&
        //                number.Contains('6') && number.Contains('7') && number.Contains('8') && number.Contains('9'))
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
    }
}
