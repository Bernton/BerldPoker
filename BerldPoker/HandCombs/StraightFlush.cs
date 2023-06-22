namespace BerldPoker
{
    public class StraightFlush : IHandValue
    {
        public CardRank Highest { get; private set; }

        public StraightFlush(CardRank highest)
        {
            Highest = highest;
        }

        public int GetRank()
        {
            return 1;
        }

        public override string ToString()
        {
            if(Highest == CardRank.Ace)
            {
                return "Royal Flush";
            }

            return string.Format("{0} High Straight Flush", Highest.ToString());
        }
    }
}
