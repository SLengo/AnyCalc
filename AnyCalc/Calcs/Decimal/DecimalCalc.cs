using AnyCalc.Common.CalcMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCalc.Calcs.Decimal
{
    public class DecimalCalc : ICalc
    {
        // Consts & Configs

        // Fields

        // Properties

        // ctors

        // Methods
        public string Add(string left, string right)
        {
            return ResultToString(double.Parse(left) + double.Parse(right));
        }

        public string Devide(string left, string right)
        {
            if (right == "0")
            {
                throw new Exception("Devision by zero!");
            }

            return ResultToString(double.Parse(left) / double.Parse(right));
        }

        public string Multiple(string left, string right)
        {
            return ResultToString(double.Parse(left) * double.Parse(right));
        }

        public string Substruct(string left, string right)
        {
            return ResultToString(double.Parse(left) - double.Parse(right));
        }

        public double ConvertToNum(string input)
        {
            return double.Parse(input);
        }

        private string ResultToString(double result)
        {
            if (result < 0)
            {
                return $"({Convert.ToString(result)})";
            }

            return Convert.ToString(result);
        }
    }
}
