using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerldPoker
{
    public class Flush : IHandValue
    {
        public CardRank[] Values { get; private set; }

        public Flush(CardRank[] values)
        {
            if(values == null || values.Length != 5)
            {
                throw new ArgumentException("Values may not be null and must be length 5.");
            }

            Values = values;
        }

        public int GetRank()
        {
            return 4;
        }

        public override string ToString()
        {
            return string.Format("{0} High Flush", Values[0].ToString());
        }
    }
}
