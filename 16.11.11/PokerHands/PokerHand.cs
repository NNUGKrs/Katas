using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class PokerHand : IComparable
    {
        public Rank Rank;

        public PokerHand(string cards)
        {
            var pokerCards = cards.Split(' ').Select(cardValue => new PokerCard(cardValue)).ToList();
            pokerCards.Sort();
            var groups = from card in pokerCards group card by card.Denomination;
            switch (groups.Count())
            {
                case 4:
                    Rank = Rank.Pair;
                    break;
                case 3:
                    Rank = Rank.TwoPairs;
                    break;
                case 2:
                    Rank = Rank.FullHouse;
                    break;
                case 5:
                    Rank = Rank.Straight;
                    for (int i = 1; i < pokerCards.Count; i++)
                    {
                        if (pokerCards[i].Denomination - pokerCards[i - 1].Denomination != 1)
                        {
                            Rank = Rank.UNKNOWN;
                            break;
                        }
                    }
                    break;
                default:
                    Rank = Rank.UNKNOWN;
                    break;
            }
        }

        public bool IsPair()
        {
            return true;
        }

        public int CompareTo(object obj)
        {
            return Rank.CompareTo(((PokerHand) obj).Rank);
        }
    }
}