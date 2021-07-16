﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class RequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object obj) => !(obj == null);
    }
}
