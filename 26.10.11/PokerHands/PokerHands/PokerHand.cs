using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands.PokerHands
{
    public enum Hands
    {
        Nothing = 0,
        HighCard = 1,
        Pair = 2,
        TwoPair =3
        

    }

    public class PokerHand
    {
        private string[] _hand;

        private Dictionary<String, int> values = new Dictionary<String, int>
                    {
                        {"2", 2},
                        {"3", 3},
                        {"4", 4},
                        {"5", 5},
                        {"6", 6},
                        {"7", 7},
                        {"8", 8},
                        {"9", 9},
                        {"T", 10},
                        {"J", 11},
                        {"Q", 12},
                        {"K", 13},
                        {"A", 14}
                    };

        public PokerHand(string hand)
        {
            _hand = hand.Split(' ');
        }

        public bool IsPair
        {
            get
            {
                return HasNumberOfEqualCards(2);
            }
        }

        private bool HasNumberOfEqualCards(int cards)
        {
            return GetGroupCount(cards);
        }

        public bool IsThreeOfaKind
        {
            get
            {
                return HasNumberOfEqualCards(3);
            }
        }

        public bool IsFullHouse
        {
            get { return IsPair && IsThreeOfaKind; }
        }

        public bool IsTwoPairs
        {
            get
            {
                return GetGroupCount(2, 2);
            }
        }

        public bool IsFourOfAKind
        {
            get { return HasNumberOfEqualCards(4); }
        }

        public bool IsFlush
        {
            get { return GetSuiteCount(5, 1); }
        }

        public bool IsStraight
        {
            get {
                for (int i = 0; i < _hand.Length-1; i++)
                {
                    if (GetCardValue(i + 1) - GetCardValue(i) != 1) 
                        return false;
                }
                return true;
            }
        }

        public bool IsStraightFlush
        {
            get { return IsStraight && IsFlush; }
        }

        public bool IsHighCard
        {
            get
            {
                return (!IsStraight && !IsStraightFlush && !IsFourOfAKind && !IsFlush 
                        && !IsFullHouse && !IsPair && !IsThreeOfaKind && !IsTwoPairs);
            }
        }

        private int GetCardValue(int i)
        {
            var cardToken = _hand[i].Substring(0,1);
            return values[cardToken];
        }

        private bool GetSuiteCount(int equalCount, int expectedGroupCount)
        {
            return GetGroupCount(equalCount, expectedGroupCount, 1);
        }

        private bool GetGroupCount(int equalCount, int expectedGroupCount = 1, int startPosition = 0)
        {
            IEnumerable<IGrouping<string, string>> groupBy = GetValueGroups(startPosition);
            return groupBy
                       .Count(grouping => grouping.Count() == equalCount) == expectedGroupCount;
        }

        private IEnumerable<IGrouping<string, string>> GetValueGroups(int startPosition = 0)
        {
            return _hand.Select(card => card.Substring(startPosition, 1))
                .GroupBy(number => number);
        }

        public bool BetterThan(PokerHand otherHand)
        {

            if (IsPair && otherHand.IsThreeOfaKind)
                return false;
            if (otherHand.IsPair && IsThreeOfaKind)
                return true;
            if( IsPair && otherHand.IsPair)
            {
                return GetPairValue() > otherHand.GetPairValue();
            }
            return false;
        }

        private int GetPairValue()
        {
            IEnumerable<IGrouping<string, string>> groupBy = GetValueGroups(0);
            return values[groupBy.First(group=> group.Count() == 2).First()];
        }
    }
}