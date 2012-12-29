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
            Hand = hand;
        }

        public HandResult HighestHand()
        {
            var result = IsRoyalFlush(Hand);
            if (result != null)
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
            return result ?? HighCard(Hand);
        }

        private static HandResult IsRoyalFlush(Card[] hand)
        {
            if (hand.Any(u => u.CardType == CardValue.Ace) && hand.Any(u => u.CardType == CardValue.Jack))
            {
                var straightFlush = IsStraightFlush(hand);
                if (straightFlush != null)
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
            var groupedCards = hand.GroupBy(c => c.CardType).FirstOrDefault(c => c.Count() == 4);
            if (groupedCards != null)
            {
                return new HandResult(PossiblePokerHands.FourOfAKind, new[]
                                                                      {
                                                                          groupedCards.Key,
                                                                          groupedCards.Key,
                                                                          groupedCards.Key,
                                                                          groupedCards.Key
                                                                      }, hand);
            }
            return null;
        }

        private static HandResult IsFullHouse(Card[] hand)
        {
            var threeOfAKind = IsThreeOfAKind(hand);
            if (threeOfAKind != null)
            {
                var pair = IsOnePair(hand);
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
            return hand.Count(u => u.CardSuit == hand.First().CardSuit) == 5
                       ? new HandResult(PossiblePokerHands.Flush, hand.Select(u => u.CardType), hand)
                       : null;
        }

        private static HandResult IsStraight(Card[] hand)
        {
            var sum = hand.Sum(u => (int)u.CardType);
            var straightSum = (int)HighestCard(hand) * 5 - 10;

            return sum == straightSum
                       ? new HandResult(PossiblePokerHands.Straight, hand.Select(u => u.CardType), hand)
                       : null;
        }

        private static HandResult IsThreeOfAKind(Card[] hand)
        {
            var groupedCards = hand.GroupBy(c => c.CardType).FirstOrDefault(c => c.Count() == 3);
            if (groupedCards != null)
            {
                return new HandResult(PossiblePokerHands.ThreeOfAKind, new[]
                    {
                        groupedCards.Key,
                        groupedCards.Key,
                        groupedCards.Key,
                    }, hand);
            }
            return null;
        }

        private static HandResult IsTwoPairs(Card[] hand)
        {
            var groupedCards = hand.GroupBy(c => c.CardType).Where(c => c.Count() == 2);
            if (groupedCards.Count() == 2)
            {
                var firstPairValue = groupedCards.First().Key;
                var secondPairValue = groupedCards.ElementAt(1).Key;
                return new HandResult(PossiblePokerHands.TwoPairs, new[]
                    {
                        firstPairValue,
                        firstPairValue,
                        secondPairValue,
                        secondPairValue
                    }, hand);
            }
            return null;
        }

        private static HandResult IsOnePair(IEnumerable<Card> hand)
        {
            var groupedCards = hand.GroupBy(c => c.CardType).Where(c => c.Count() == 2);
            if (groupedCards.Count() == 1)
            {
                var cardValue = groupedCards.First().Key;
                return new HandResult(PossiblePokerHands.OnePair, new[]
                    {
                        cardValue,
                        cardValue
                    }, hand);
            }
            return null;
        }

        private static HandResult HighCard(IList<Card> hand)
        {
            return new HandResult(PossiblePokerHands.HighCard,
                                  new[] { HighestCard(hand) },
                                  hand);
        }

        private static CardValue HighestCard(IEnumerable<Card> hand)
        {
            return hand.Max(u => u.CardType);
        }

        public static IEnumerable<Card> RemoveFromHand(IEnumerable<Card> hand, IEnumerable<CardValue> cardValues)
        {
            var newHandValues = new List<Card>(hand);
            foreach (var cardValue in cardValues)
            {
                newHandValues.Remove(newHandValues.First(u => u.CardType == cardValue));
            }
            return newHandValues;
        }
    }
}
