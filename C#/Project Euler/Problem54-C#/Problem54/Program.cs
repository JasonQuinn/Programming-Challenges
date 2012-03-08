using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Problem54
{
    //http://projecteuler.net/problem=54
    class Program
    {
        static void Main()
        {
            var timer = new Stopwatch();
            timer.Start();

            TextReader tr = new StreamReader("../../poker.txt");
            var line = tr.ReadLine();

            var player1Count = 0;
            var player2Count = 0;

            while (line != null)
            {
                var winner = CompareHands(line);
                if (winner == Winner.Player1)
                {
                    player1Count++;
                }
                else if (winner == Winner.Player2)
                {
                    player2Count++;
                }
                line = tr.ReadLine();
            }
            timer.Stop();
            Console.WriteLine("Player1 won - " + player1Count);
            Console.WriteLine("Player2 won - " + player2Count);
            Console.WriteLine("Time taken - " + timer.Elapsed);
            Console.ReadLine();
        }

        private static Winner CompareHands(string handString)
        {
            var handStringArray = handString.Split(' ');
            var hand1 = new PokerHand(handStringArray.Take(5));
            var hand2 = new PokerHand(handStringArray.Skip(5).Take(5));

            return CompareHands(hand1, hand2);
        }

        private static Winner CompareHands(PokerHand hand1, PokerHand hand2)
        {
            var hand1Result = hand1.HighestHand();
            var hand2Result = hand2.HighestHand();

            if (hand1Result.ResultType > hand2Result.ResultType)
            {
                return Winner.Player1;
            }
            if (hand1Result.ResultType < hand2Result.ResultType)
            {
                return Winner.Player2;
            }
            for (var i = 0; i < hand1Result.ResultCards.Count(); i++)
            {
                if (hand1Result.ResultCards.ElementAt(i) > hand2Result.ResultCards.ElementAt(i))
                {
                    return Winner.Player1;
                }
                if (hand1Result.ResultCards.ElementAt(i) < hand2Result.ResultCards.ElementAt(i))
                {
                    return Winner.Player2;
                }
            }
            for (var i = 0; i < hand1Result.OtherCards.Count(); i++)
            {
                if (hand1Result.OtherCards.ElementAt(i) > hand2Result.OtherCards.ElementAt(i))
                {
                    return Winner.Player1;
                }
                if (hand1Result.OtherCards.ElementAt(i) < hand2Result.OtherCards.ElementAt(i))
                {
                    return Winner.Player2;
                }
            }

            throw new Exception("Should never get here as");
        }
    }

    enum Winner
    {
        Player1,
        Player2
    }
}
