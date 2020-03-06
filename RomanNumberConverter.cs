using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies
{
    class RomanNumberConverter : INumberConverter
    {
        private static Dictionary<char, int> _romanMap = new Dictionary<char, int>
        {
           {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
        };
        public string ToLocalString(int fromNumber)
        {
            if (fromNumber < 1) return string.Empty;
            if (fromNumber >= 1000) return "M" + ToLocalString(fromNumber - 1000);
            if (fromNumber >= 900) return "CM" + ToLocalString(fromNumber - 900); //EDIT: i've typed 400 instead 900
            if (fromNumber >= 500) return "D" + ToLocalString(fromNumber - 500);
            if (fromNumber >= 400) return "CD" + ToLocalString(fromNumber - 400);
            if (fromNumber >= 100) return "C" + ToLocalString(fromNumber - 100);
            if (fromNumber >= 90) return "XC" + ToLocalString(fromNumber - 90);
            if (fromNumber >= 50) return "L" + ToLocalString(fromNumber - 50);
            if (fromNumber >= 40) return "XL" + ToLocalString(fromNumber - 40);
            if (fromNumber >= 10) return "X" + ToLocalString(fromNumber - 10);
            if (fromNumber >= 9) return "IX" + ToLocalString(fromNumber - 9);
            if (fromNumber >= 5) return "V" + ToLocalString(fromNumber - 5);
            if (fromNumber >= 4) return "IV" + ToLocalString(fromNumber - 4);
            if (fromNumber >= 1) return "I" + ToLocalString(fromNumber - 1);

            throw new ArgumentOutOfRangeException("something bad happened");
        }

        public int ToNumerical(string fromString)
        {
            int totalValue = 0, prevValue = 0;
            foreach (var c in fromString)
            {
                if (!_romanMap.ContainsKey(c))
                    return 0;
                var crtValue = _romanMap[c];
                totalValue += crtValue;
                if (prevValue != 0 && prevValue < crtValue)
                {
                    if (prevValue == 1 && (crtValue == 5 || crtValue == 10)
                        || prevValue == 10 && (crtValue == 50 || crtValue == 100)
                        || prevValue == 100 && (crtValue == 500 || crtValue == 1000))
                        totalValue -= 2 * prevValue;
                    else
                        return 0;
                }
                prevValue = crtValue;
            }
            return totalValue;
        }
    }
}
