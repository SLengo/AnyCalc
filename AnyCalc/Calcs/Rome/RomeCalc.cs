using AnyCalc.Common.CalcMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCalc.Calcs.Rome
{
    public class RomeCalc : ICalc
    {
        // Consts & Configs
        private static readonly Dictionary<char, double> CharsAvailable
            = new Dictionary<char, double>
            {
                ['i'] = 1,
                ['v'] = 5,
                ['x'] = 10,
                ['l'] = 50,
                ['c'] = 100,
                ['d'] = 500,
                ['m'] = 1000,
            };

        // Fields

        // Properties

        // ctors

        // Methods
        public string Add(string left, string right)
        {
            throw new NotImplementedException();
        }

        public string Devide(string left, string right)
        {
            throw new NotImplementedException();
        }

        public string Multiple(string left, string right)
        {
            throw new NotImplementedException();
        }

        public string Substruct(string left, string right)
        {
            throw new NotImplementedException();
        }

        public double ConvertToNum(string input)
        {
            throw new NotImplementedException();
        }
    }
}
