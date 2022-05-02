using AnyCalc.Common.CalcMath;
using System;

namespace AnyCalc.Calcs.Decimal
{
    public class DecimalCalc : ICalc
    {
        // Consts & Configs
        private const string DecimalNull = "0";

        // Fields

        // Properties

        // ctors

        // Methods
        public string Add(string left, string right)
        {
            return DoubleToString(double.Parse(left) + double.Parse(right));
        }

        public string Devide(string left, string right)
        {
            if (right == DecimalNull)
            {
                throw new Exception("Devision by zero!");
            }

            return DoubleToString(double.Parse(left) / double.Parse(right));
        }

        public string Multiple(string left, string right)
        {
            return DoubleToString(double.Parse(left) * double.Parse(right));
        }

        public string Substruct(string left, string right)
        {
            return DoubleToString(double.Parse(left) - double.Parse(right));
        }

        public double ConvertToNum(string input)
        {
            return double.Parse(input);
        }

        private string DoubleToString(double result)
        {
            if (result < 0)
            {
                return $"({ConvertToNotation(result)})";
            }

            return ConvertToNotation(result);
        }

        public string GetNullSymbol() => DecimalNull;

        public string ConvertToNotation(double input)
        {
            return Convert.ToString(input);
        }
    }
}
