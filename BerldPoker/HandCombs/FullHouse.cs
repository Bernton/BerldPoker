using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerldPoker
{
    public class FullHouse : IHandValue
    {
        public CardRank ThreeOfAKind { get; private set; }
        public CardRank Pair { get; private set; }

        public FullHouse(CardRank set, CardRank pair)
        {
            ThreeOfAKind = set;
            Pair = pair;
        }

        public int GetRank()
        {
            return 3;
        }

        public override string ToString()
        {
            string pluralSet;
            string pluralPair;

            if (ThreeOfAKind == (CardRank)4)
            {
                pluralSet = "es";
            }
            else
            {
                pluralSet = "s";
            }

            if (Pair == (CardRank)4)
            {
                pluralPair = "es";
            }
            else
            {
                pluralPair = "s";
            }

            return string.Format("Full House, {0}{1} Full Of {2}{3}", ThreeOfAKind.ToString(), pluralSet, Pair.ToString(), pluralPair);
        }
    }
}
