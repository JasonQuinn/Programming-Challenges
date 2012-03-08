using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Problem54
{
    public enum CardValue
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum CardSuit
    {
        Clubs,
        Spades,
        Hearts,
        Diamonds
    }

    public class Card
    {
        public CardValue CardType {get;private set;}
        public CardSuit CardSuit { get; private set; }

        public Card(string cardString)
        {
            var type = cardString[0];
            var suit = cardString[1];

            switch (type)
            {
                case '2':
                    {
                        CardType = CardValue.Two;
                        break;
                    }
                case '3':
                    {
                        CardType = CardValue.Three;
                        break;
                    }
                case '4':
                    {
                        CardType = CardValue.Four;
                        break;
                    }
                case '5':
                    {
                        CardType = CardValue.Five;
                        break;
                    }
                case '6':
                    {
                        CardType = CardValue.Six;
                        break;
                    }
                case '7':
                    {
                        CardType = CardValue.Seven;
                        break;
                    }
                case '8':
                    {
                        CardType = CardValue.Eight;
                        break;
                    }
                case '9':
                    {
                        CardType = CardValue.Nine;
                        break;
                    }
                case 'T':
                    {
                        CardType = CardValue.Ten;
                        break;
                    }
                case 'J':
                    {
                        CardType = CardValue.Jack;
                        break;
                    }
                case 'Q':
                    {
                        CardType = CardValue.Queen;
                        break;
                    }
                case 'K':
                    {
                        CardType = CardValue.King;
                        break;
                    }
                case 'A':
                    {
                        CardType = CardValue.Ace;
                        break;
                    }
                default:
                    {
                        throw new InvalidDataException("Not a valid card value");
                    }
            }
            switch (suit)
            {
                case 'C':
                    {
                        CardSuit = CardSuit.Clubs;
                        break;
                    }
                case 'H':
                    {
                        CardSuit = CardSuit.Hearts;
                        break;
                    }
                case 'S':
                    {
                        CardSuit = CardSuit.Spades;
                        break;
                    }
                case 'D':
                    {
                        CardSuit = CardSuit.Diamonds;
                        break;
                    }
                default:
                    {
                        throw new InvalidDataException("Not a valid suit");
                    }
            }
        }
    }
}
