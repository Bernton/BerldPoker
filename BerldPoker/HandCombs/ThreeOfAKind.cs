using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerldPoker
{
    public class ThreeOfAKind : IHandValue
    {
        public CardRank Value { get; private set; }
        public CardRank[] Kickers { get; private set; }

        public ThreeOfAKind(CardRank value, CardRank[] kickers)
        {
            if (kickers == null || kickers.Length != 2)
            {
                throw new ArgumentException("Values may not be null and must be length 2.");
            }

            Value = value;
            Kickers = kickers;
        }

        public int GetRank()
        {
            return 6;
        }

        public override string ToString()
        {
            string plural;

            if (Value == (CardRank)4)
            {
                plural = "es";
            }
            else
            {
                plural = "s";
            }

            return string.Format("Three Of A Kind With {0}{1}", Value.ToString(), plural);
        }
    }
}
