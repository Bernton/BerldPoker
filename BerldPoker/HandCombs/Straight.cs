using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerldPoker
{
    public class Straight : IHandValue
    {
        public CardRank Highest { get; private set; }

        public Straight(CardRank highest)
        {
            Highest = highest;
        }

        public int GetRank()
        {
            return 5;
        }

        public override string ToString()
        {
            if(Highest == CardRank.Ace)
            {
                return "Broadway (Ace Hight Straight)";
            }
            else if(Highest == CardRank.Five)
            {
                return "Wheel (Five High Straight)";
            }

            return string.Format("{0} High Straight", Highest.ToString());
        }
    }
}
