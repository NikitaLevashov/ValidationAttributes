using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class RangeAttribute : ValidationAttribute
    {
        public int MinNumber { get; }
        public int MaxNumber { get; }
        public RangeAttribute(int minnumber, int maxnumber)
        {
            MaxNumber = maxnumber;
            MinNumber = minnumber;
        }

        public override bool IsValid(object obj) => obj switch
        {
            int value when value >= MinNumber && value <= MaxNumber => true,
            _ => false,
        };
    }
}
