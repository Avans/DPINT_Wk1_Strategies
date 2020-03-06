using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies
{
    class BinaryNumberConverter : INumberConverter
    {
        public string ToLocalString(int fromNumber)
        {
            return Convert.ToString(fromNumber, 2);
        }

        public int ToNumerical(string fromString)
        {
            return Convert.ToInt32(fromString, 2);
        }
    }
}
