using System;
using System.Collections.Generic;

namespace DPINT_Wk1_Strategies
{
    internal class ConverterFactory
    {
        public IEnumerable<String> ConverterNames
        {
            get { return _converterNames.Keys; }
        }

        public Dictionary<string, INumberConverter> _converterNames;

        public ConverterFactory()
        {
            _converterNames = new Dictionary<string, INumberConverter>();

            _converterNames["Numerical"] = new NumericalNumberConverter();
            _converterNames["Roman"] = new RomanNumberConverter();
            _converterNames["Binary"] = new BinaryNumberConverter();
            _converterNames["Hexadecimal"] = new HexadecimalNumberConverter();
            _converterNames["Octal"] = new OctalNumberConverter();
        }

        public INumberConverter getConverter(string name)
        {
            return _converterNames[name];
        }
    }
}