namespace BerldPoker
{
    public class Card
    {
        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public CardRank Rank { get; private set; }
        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} of {1}s", Rank.ToString(), Suit.ToString());
        }
    }
}
