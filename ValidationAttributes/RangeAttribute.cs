using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class RangeAttribute : BaseAttribute
    {
        public int MinNumber { get; }
        public int MaxNumber { get; }
        public RangeAttribute(int minnumber, int maxnumber)
        {
            MaxNumber = maxnumber;
            MinNumber = minnumber;
        }
    }
}
