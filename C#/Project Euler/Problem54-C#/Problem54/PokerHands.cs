using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem54
{
    public enum PossiblePokerHands
    {
        HighCard,
        OnePair,
        TwoPairs,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind, 
        StraightFlush,
        RoyalFlush
    }

    public class HandResult
    {
        public PossiblePokerHands ResultType { get; private set; }
        public CardValue[] ResultCards { get; private set; }
        public CardValue[] OtherCards { get; private set; }

        public HandResult(PossiblePokerHands resultType, IEnumerable<CardValue> resultCards, IEnumerable<Card> hand)
        {
            ResultType = resultType;
            ResultCards = resultCards.ToArray();
            OtherCards = PokerHand.RemoveFromHand(hand, ResultCards).Select(u => u.CardType).ToArray();
        }
    }

    public class PokerHand
    {
        public Card[] Hand { get; private set; }

        public PokerHand(IEnumerable<string> handStringArray)
        {
            var hand = handStringArray.Select(u => new Card(u)).ToArray();

            if (hand.Count() != 5)
            {
                throw new InvalidDataException("A hand should have 5 cards");
            }
            Hand = OrderCards(hand);
        }

        public HandResult HighestHand()
        {
            var result = IsRoyalFlush(Hand);
            if(result!=null)
            {
                return result;
            }
            result = IsStraightFlush(Hand);
            if (result != null)
            {
                return result;
            }
            result = IsFourOfAKind(Hand);
            if (result != null)
            {
                return result;
            }
            result = IsFullHouse(Hand);
            if (result != null)
            {
                return result;
            }
            result = IsFlush(Hand);
            if (result != null)
            {
                return result;
            }
            result = IsStraight(Hand);
            if (result != null)
            {
                return result;
            }
            result = IsThreeOfAKind(Hand);
            if (result != null)
            {
                return result;
            }
            result = IsTwoPairs(Hand);
            if (result != null)
            {
                return result;
            }
            result = IsOnePair(Hand);
            if (result != null)
            {
                return result;
            }
            return HighCard(Hand);
        }


        private static Card[] OrderCards(IEnumerable<Card> hand)
        {
            return hand.OrderByDescending(u => u.CardType).ToArray();
        }

        private static HandResult IsRoyalFlush(Card[] hand)
        {
            if (hand.Any(u => u.CardType == CardValue.Ace))
            {
                var straightFlush = IsStraightFlush(hand);
                if(straightFlush!=null)
                {
                    return new HandResult(PossiblePokerHands.RoyalFlush, straightFlush.ResultCards, hand);
                }
            }
            return null;
        }

        private static HandResult IsStraightFlush(Card[] hand)
        {
            var straight = IsStraight(hand);
            if (straight != null)
            {
                var flush = IsFlush(hand);
                if (flush != null)
                {
                    return new HandResult(PossiblePokerHands.StraightFlush, straight.ResultCards, hand);
                }
            }
            return null;
        }

        private static HandResult IsFourOfAKind(Card[] hand)
        {
            for (int i = 0; i < hand.Count() - 3; i++)
            {
                if (hand.Count(u => u.CardType == hand.ElementAt(i).CardType) == 4)
                {
                    return new HandResult(PossiblePokerHands.FourOfAKind,
                                      new[]
                                          {
                                              hand.ElementAt(i).CardType, 
                                              hand.ElementAt(i).CardType,
                                              hand.ElementAt(i).CardType,
                                              hand.ElementAt(i).CardType
                                          }, hand);
                }
            }
            return null;
        }

        private static HandResult IsFullHouse(Card[] hand)
        {
            var threeOfAKind = IsThreeOfAKind(hand);
            if (threeOfAKind != null)
            {
                var pair = IsOnePair(RemoveFromHand(hand, threeOfAKind.ResultCards));
                if (pair != null)
                {
                    var resultCards = threeOfAKind.ResultCards.Concat(pair.ResultCards);
                    return new HandResult(PossiblePokerHands.FullHouse, resultCards, hand);
                }
            }
            return null;
        }

        private static HandResult IsFlush(Card[] hand)
        {
            if( hand.Count(u => u.CardSuit == hand.First().CardSuit) == 5)
            {
                return new HandResult(PossiblePokerHands.Flush, hand.Select(u => u.CardType), hand);
            }
            return null;
        }

        private static HandResult IsStraight(Card[] hand)
        {
            var sum = hand.Sum(u => (int)u.CardType);
            var straightSum = (int)hand.First().CardType * 5 - 10;

            if( sum == straightSum)
            {
                return new HandResult(PossiblePokerHands.Straight, hand.Select(u => u.CardType), hand);
            }
            return null;
        }

        private static HandResult IsThreeOfAKind(Card[] hand)
        {
            for (int i = 0; i < hand.Count() - 2; i++)
            {
                if (hand.Count(u => u.CardType == hand.ElementAt(i).CardType) == 3)
                {
                    return new HandResult(PossiblePokerHands.ThreeOfAKind,
                                      new[]
                                          {
                                              hand.ElementAt(i).CardType, 
                                              hand.ElementAt(i).CardType,
                                              hand.ElementAt(i).CardType
                                          }, hand);
                }
            }
            return null;
        }

        private static HandResult IsTwoPairs(Card[] hand)
        {
            var pair1 = IsOnePair(hand);
            if(pair1!=null)
            {
                var pair2 = IsOnePair(RemoveFromHand(hand, pair1.ResultCards));
                if(pair2!=null)
                {
                    var resultCards = pair1.ResultCards.Concat(pair2.ResultCards);
                    return new HandResult(PossiblePokerHands.TwoPairs, resultCards, hand);
                }
            }
            return null;
        }

        private static HandResult IsOnePair(IEnumerable<Card> hand)
        {
            for (int i = 0; i < hand.Count() - 1; i++)
            {
                if (hand.Count(u => u.CardType == hand.ElementAt(i).CardType) == 2)
                {
                    return new HandResult(PossiblePokerHands.OnePair, new[]
                                                                      {
                                                                          hand.ElementAt(i).CardType,
                                                                          hand.ElementAt(i).CardType
                                                                      }, hand);
                }
            }
            return null;
        }

        private static HandResult HighCard(Card[] hand)
        {
            return new HandResult(PossiblePokerHands.HighCard,
                              new [] {hand[0].CardType},
                              hand);
        }

        public static IEnumerable<Card> RemoveFromHand(IEnumerable<Card> hand, IEnumerable<CardValue> cardValue)
        {
            var newHandValues = new List<Card>(hand);
            for (int i = 0; i < cardValue.Count(); i++)
            {
                newHandValues.Remove(newHandValues.First(u => u.CardType == cardValue.ElementAt(i)));
            }
            return newHandValues;
        }
    }
}
