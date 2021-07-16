using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class StringLenghtAttribute : ValidationAttribute
    {
        public int MaxLenght { get; }
        public StringLenghtAttribute(int maxLenght)
        {
            MaxLenght = maxLenght;
        }
        public override bool IsValid(object obj) => !(obj.ToString().Length > MaxLenght);
    }
}
