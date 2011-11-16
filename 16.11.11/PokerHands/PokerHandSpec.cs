using NUnit.Framework;

namespace PokerHands
{
    [TestFixture]
    public class PokerHandSpec
    {
        [Test]
        public void It_should_identify_pair_hand()
        {
            var pair = new PokerHand("2C 2H 4S 8C AH");
            Assert.AreEqual(Rank.Pair, pair.Rank);
        }

        [Test]
        public void It_should_identify_non_pair_hand_as_non_pair()
        {
            var nonPair = new PokerHand("2C 3H 4S 8C AH");
            Assert.AreNotEqual(Rank.Pair, nonPair.Rank);
        }

        [Test]
        public void It_should_identify_2_pair_hand()
        {
            var twoPairs = new PokerHand("2C 2H 4S 4D KD");
            Assert.AreEqual(Rank.TwoPairs, twoPairs.Rank);
        }

        [Test]
        public void It_should_identify_full_house()
        {
            var fullHouse = new PokerHand("2C 2D 2H QC QD");
            Assert.AreEqual(Rank.FullHouse, fullHouse.Rank);
        }

        [Test]
        public void It_should_identify_straight()
        {
            var fullHouse = new PokerHand("2C 3D 4H 5C 6D");
            Assert.AreEqual(Rank.Straight, fullHouse.Rank);
        }

        [Test]
        public void It_should_rank_two_pairs_greater_than_pair()
        {
            var twoPairs = new PokerHand("2C 2D 3H QC QD");
            var pair = new PokerHand("2C 2D 3H QC KD");
            Assert.Greater(twoPairs, pair);
        }

    }
}