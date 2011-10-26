using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq.Expressions;
using PokerHands.PokerHands;

namespace PokerHands.Test
{
    [TestFixture]
    public class PokerHandSpec
    {
        private string highCard = "9H 7S 5C 2D 4H";
        private string pair1 = "2H 7S 5C 2D 4H";
        private string pair2 = "2H 7S 5C 7D 4H";
        private string threeOfaKind = "2H 2D 2C 4D 5D";
        private string fullHouse = "2H 2D 2C 4D 4C";
        private string twoPairs = "2H 2D 5C 4D 4C";
        private string fourOfaKind = "2H 2D 2C 2S 4C";
        private string flush = "2H 3H 8H 9H KH";
        private string straight = "2H 3D 4H 5H 6H";
        private string straightWithT = "6H 7D 8H 9H TH";
        private string straightFlush = "2H 3H 4H 5H 6H";

        [Test]
        public void It_should_identify_pair()
        {
            PokerHand hand = new PokerHand(pair1);
            Assert.IsTrue(hand.IsPair);
            Assert.IsFalse(hand.IsThreeOfaKind);
        }
        

        [Test]
        public void It_should_identify_three_of_a_kind()
        {
            var pokerHand = new PokerHand(threeOfaKind);
            Assert.IsTrue(pokerHand.IsThreeOfaKind);
            Assert.IsFalse(pokerHand.IsPair);
        }

        [Test]
        public void It_should_identify_full_house()
        {
            var hand = new PokerHand(fullHouse);
            Assert.IsTrue(hand.IsFullHouse);
        }

        [Test]
        public void It_should_identify_two_pairs()
        {
            var hand = new PokerHand(twoPairs);
            Assert.IsTrue(hand.IsTwoPairs);
        }

        [Test]
        public void It_should_identify_four_of_a_kind()
        {
            Assert.IsTrue(new PokerHand(fourOfaKind).IsFourOfAKind);
        }

        [Test]
        public void It_should_identify_flush()
        {
            Assert.IsTrue(new PokerHand(flush).IsFlush);
        }

        [Test]
        public void It_should_identify_straight()
        {
            Assert.IsTrue(new PokerHand(straight).IsStraight);
            Assert.IsTrue(new PokerHand(straightWithT).IsStraight);
        }


        [Test]
        public void It_should_identify_straight_flush()
        {
            Assert.IsTrue(new PokerHand(straightFlush).IsStraightFlush);
          
        }

        [Test]
        public void It_should_identify_highcard()
        {
            Assert.IsTrue(new PokerHand(highCard).IsHighCard);
        }
        [Test]
        public void It_should_say_threeofakind_is_better_than_pair()
        {
            PokerHand pair = new PokerHand(this.pair1);
            var three = new PokerHand(threeOfaKind);

            Assert.IsTrue(three.BetterThan(pair));
            Assert.IsFalse(pair.BetterThan(three));
        }

        [Test]
        public void It_should_rank_One_Pair_Over_Another()
        {
            PokerHand hand1= new PokerHand(pair1);
            PokerHand hand2 = new PokerHand(pair2);
            Assert.IsTrue(hand2.BetterThan(hand1));
            Assert.IsFalse(hand1.BetterThan(hand2));
        }



    }
}