﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies
{
    class NumericalNumberConverter : INumberConverter
    {
        public string ToLocalString(int fromNumber)
        {
            return fromNumber.ToString();
        }

        public int ToNumerical(string fromString)
        {
            return Int32.Parse(fromString);
        }
    }
}
