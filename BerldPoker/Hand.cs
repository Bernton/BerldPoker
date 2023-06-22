namespace BerldPoker
{
    public class Hand
    {
        public double Count { get; set; }
        public double Won { get; set; }
        public bool IsSuited { get; }

        public double RatioPercent
        {
            get
            {
                return Won / Count * 100.0;
            }
        }

        public CardRank CardRank1 { get; }
        public CardRank CardRank2 { get; }

        public Hand(int count, bool isSuited, CardRank cardRank1, CardRank cardRank2)
        {
            Count = count;
            IsSuited = isSuited;
            CardRank1 = cardRank1;
            CardRank2 = cardRank2;
        }

        public override string ToString()
        {
            if ((int)CardRank1 == (int)CardRank2)
            {
                string plural;

                if (CardRank1 == (CardRank)4)
                {
                    plural = "es";
                }
                else
                {
                    plural = "s";
                }

                return string.Format("Pocket {0}{1}", CardRank1, plural);
            }

            string afterText;

            if (IsSuited)
            {
                afterText = "Suited";
            }
            else
            {
                afterText = "Offsuit";
            }

            return string.Format("{0} {1} {2}", CardRank1, CardRank2, afterText);
        }
    }
}
