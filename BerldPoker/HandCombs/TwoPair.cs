namespace BerldPoker
{
    public class TwoPair : IHandValue
    {
        public CardRank HigherPair { get; private set; }
        public CardRank LowerPair { get; private set; }
        public CardRank Kicker { get; private set; }

        public TwoPair(CardRank pair1, CardRank pair2, CardRank kicker)
        {
            if ((int)pair1 > (int)pair2)
            {
                HigherPair = pair1;
                LowerPair = pair2;
            }
            else
            {
                HigherPair = pair2;
                LowerPair = pair1;
            }

            Kicker = kicker;
        }

        public int GetRank()
        {
            return 7;
        }

        public override string ToString()
        {
            string pluralHigher;
            string pluralLower;

            if (HigherPair == (CardRank)4)
            {
                pluralHigher = "es";
            }
            else
            {
                pluralHigher = "s";
            }

            if (LowerPair == (CardRank)4)
            {
                pluralLower = "es";
            }
            else
            {
                pluralLower = "s";
            }

            return string.Format("Two Pair, {0}{1} Up With {2}{3}", HigherPair.ToString(), pluralHigher, LowerPair.ToString(), pluralLower);
        }
    }
}
