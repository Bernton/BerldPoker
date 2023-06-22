using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerldPoker
{
    public class FourOfAKind : IHandValue
    {
        public CardRank Value { get; private set; }
        public CardRank Kicker { get; private set; }

        public FourOfAKind(CardRank value, CardRank kicker)
        {
            Value = value;
            Kicker = kicker;
        }

        public int GetRank()
        {
            return 2;
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

            return string.Format("Four Of A Kind With {0}{1}", Value.ToString(), plural);
        }
    }
}
