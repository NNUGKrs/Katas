using System;
using System.Collections.Generic;

namespace PokerHands
{
    public class PokerCard : IComparable
    {
        private int denomination;
        private char suit;

        private Dictionary<char, int> cardValues =
            new Dictionary<char, int>
                {
                    {'2', 2},
                    {'3', 3},
                    {'4', 4},
                    {'5', 5},
                    {'6', 6},
                    {'7', 7},
                    {'8', 8},
                    {'9', 9},
                    {'T', 10},
                    {'J', 11},
                    {'Q', 12},
                    {'K', 13},
                    {'A', 14},
                };

        public PokerCard(string cardString)
        {
            suit = cardString[1];
            denomination = cardValues[cardString[0]];
        }

        public int Denomination
        {
            get {
                return denomination;
            }
        }

        public int CompareTo(object obj)
        {
            return denomination.CompareTo(((PokerCard)obj).denomination);
        }
    }

}