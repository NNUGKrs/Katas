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
        public void It_should_say_straight_is_better_than_threeofakind()
        {
            var three = new PokerHand(threeOfaKind);
            var straightHand = new PokerHand(straight);
            Assert.IsTrue(straightHand.BetterThan(three));
            Assert.IsFalse(three.BetterThan(straightHand));
        }

        [Test]
        public void It_should_say_flush_is_better_than_straight()
        {
            var straightHand = new PokerHand(straight);
            var flushHand = new PokerHand(flush);
            Assert.IsTrue(flushHand.BetterThan(straightHand));
            Assert.IsFalse(straightHand.BetterThan(flushHand));
        }

        [Test]
        public void It_should_say_full_house_is_better_than_flush()
        {
            var flushHand = new PokerHand(flush);
            var fullHouseHand = new PokerHand(fullHouse);
            Assert.IsTrue(fullHouseHand.BetterThan(flushHand));
            Assert.IsFalse(flushHand.BetterThan(fullHouseHand));
        }

        [Test]
        public void It_should_say_four_of_a_kind_is_better_than_full_house()
        {
            var fullHouseHand = new PokerHand(fullHouse);
            var fourOfaKindHand = new PokerHand(fourOfaKind);
            Assert.IsTrue(fourOfaKindHand.BetterThan(fullHouseHand));
            Assert.IsFalse(fullHouseHand.BetterThan(fourOfaKindHand));
        }

        [Test]
        public void It_should_say_straight_flush_is_better_than_foure_of_a_kind()
        {
            var fourOfaKindHand = new PokerHand(fourOfaKind);
            var straightFlushHand = new PokerHand(straightFlush);
            Assert.IsTrue(straightFlushHand.BetterThan(fourOfaKindHand));
            Assert.IsFalse(fourOfaKindHand.BetterThan(straightFlushHand));
        }
    }
}