using NUnit.Framework;

namespace PokerHands
{
    [TestFixture]
    public class PokerCardSpec
    {
        [Test]
        public void It_should_rank_9ofhearts_higher_than_8ofspades()
        {
            var heartAce = new PokerCard("9H");
            var spadesKing = new PokerCard("8S");
            Assert.Greater(heartAce, spadesKing);
        }

        [Test]
        public void It_should_rank_8ofspades_less_than_9ofhearts()
        {
            var nine = new PokerCard("9H");
            var eight = new PokerCard("8S");
            Assert.Less(eight, nine);
        }

        [Test]
        public void It_should_rank_King_as_higher_than_queen()
        {
            var king = new PokerCard("KS");
            var queen = new PokerCard("QS");
            Assert.Greater(king, queen);
        }

        [Test]
        public void It_should_rank_non_number_cards()
        {
            Assert.Greater(new PokerCard("JS"), new PokerCard("TS"));
            Assert.Greater(new PokerCard("QS"), new PokerCard("JS"));
            Assert.Greater(new PokerCard("KS"), new PokerCard("QS"));
            Assert.Greater(new PokerCard("AS"), new PokerCard("KS"));
        }
    }
}