using AnyCalc.Common.CalcMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace AnyCalc.Calcs.Rome
{
    public class RomeCalc : ICalc
    {
        // Consts & Configs
        private const string RomeNull = "N";
        private const int MaxRomeNum = 3999;

        public static readonly Dictionary<char, double> SingleRomeToNumResolver
            = new Dictionary<char, double>
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000,
            };

        public static readonly Dictionary<double, char> NumToRomeResolver
            = new Dictionary<double, char>
            {
                [1] = 'I',
                [5] = 'V',
                [10] = 'X',
                [50] = 'L',
                [100] = 'C',
                [500] = 'D',
                [1000] = 'M',
            };

        // Fields

        // Properties

        // ctors

        // Methods
        public string Add(string left, string right)
        {
            return ResultToString(ConvertToNum(left) + ConvertToNum(right));
        }

        public string Devide(string left, string right)
        {
            if (right == RomeNull)
            {
                throw new Exception("Devision by zero!");
            }

            return ResultToString(ConvertToNum(left) / ConvertToNum(left));
        }

        public string Multiple(string left, string right)
        {
            return ResultToString(ConvertToNum(left) * ConvertToNum(right));
        }

        public string Substruct(string left, string right)
        {
            return ResultToString(ConvertToNum(left) - ConvertToNum(right));
        }

        public double ConvertToNum(string input)
        {
            bool isNegative = input[0] == '-';
            if (isNegative)
            {
                input = input.Substring(1);
            }

            double numConverted = 0;

            if (input.Contains("."))
            {
                string[] numParts = input.Split('.');
                
                numConverted += RomeToDouble(numParts[0]);
                
                if (numParts[1].Length > 0)
                {
                    double answ = RomeToDouble(numParts[1]);
                    numConverted += answ / Math.Pow(10, GetCountOfDigits(Convert.ToInt32(answ)));
                }
            }
            else
            {
                numConverted = RomeToDouble(input);
            }

            return isNegative ? numConverted * -1 : numConverted;
        }

        public double RomeToDouble(string input)
        {
            double numConverted = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char inputChar = char.ToUpper(input[i]);
                char nextChar = '\0';
                if (i + 1 < input.Length)
                {
                    nextChar = char.ToUpper(input[i + 1]);
                }

                double charToNum = SingleRomeToNumResolver[inputChar];
                double nextCharToNum = nextChar == '\0' ? -1 : SingleRomeToNumResolver[nextChar];

                if (nextCharToNum < 0 || nextCharToNum <= charToNum)
                {
                    numConverted += charToNum;
                }
                else if (nextCharToNum > charToNum)
                {
                    numConverted += nextCharToNum - charToNum;
                    i++;
                }
            }

            return numConverted;
        }

        public string ConvertToNotation(double input)
        {
            if (Math.Abs((int)input) > MaxRomeNum)
            {
                throw new Exception("Too large to convert to rome number");
            }

            if (input < 0)
            {
                input *= -1;
            }

            string romeResult;
            if (input % 1 == 0) // w/o decimal places
            {
                romeResult = DoubleToRome(input);
            }
            else
            {
                double decPart = int.Parse((input % 1)
                    .ToString()
                    .Replace($"0{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}", string.Empty));
                double intPart = (int)(input - decPart);
                romeResult = $"{DoubleToRome(intPart)}.{DoubleToRome(decPart)}";
            }

            return romeResult;
        }

        public string DoubleToRome(double input)
        {
            StringBuilder romeResult = new StringBuilder();

            List<int> numberParts = new List<int>();

            int intInput = (int)input;
            while (intInput > 0)
            {
                numberParts.Add((int)(intInput % 10));
                intInput /= 10;
            }

            for (int i = 0; i < numberParts.Count; i++)
            {
                int tenMargin = i == 0 ? 1 : (int)Math.Pow(10, i);
                int fiveMargin = i == 0 ? 5 : tenMargin * 5;

                switch (numberParts[i])
                {
                    case 1:
                        {
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            break;
                        }
                    case 2:
                        {
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            break;
                        }
                    case 3:
                        {
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            break;
                        }
                    case 4:
                        {
                            romeResult.Insert(0, NumToRomeResolver[fiveMargin]);
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            break;
                        }
                    case 5:
                        {
                            romeResult.Insert(0, NumToRomeResolver[fiveMargin]);
                            break;
                        }
                    case 6:
                        {
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            romeResult.Insert(0, NumToRomeResolver[fiveMargin]);
                            break;
                        }
                    case 7:
                        {
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            romeResult.Insert(0, NumToRomeResolver[fiveMargin]);
                            break;
                        }
                    case 8:
                        {
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            romeResult.Insert(0, NumToRomeResolver[fiveMargin]);
                            break;
                        }
                    case 9:
                        {
                            romeResult.Insert(0, NumToRomeResolver[10 * (i + 1)]); // unreachable for index out of range because of throw new Exception("Too large to convert to rome number");
                            romeResult.Insert(0, NumToRomeResolver[tenMargin]);
                            break;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }

            return romeResult.ToString();
        }

        private string ResultToString(double result)
        {
            if (result < 0)
            {
                return $"(-{ConvertToNotation(result)})";
            }

            return ConvertToNotation(result);
        }

        private int GetCountOfDigits(int number)
        {
            int result = 0;

            while (number > 0)
            {
                number /= 10;
                result++;
            }

            return result;
        }

        public string GetNullSymbol() => RomeNull;
    }
}
