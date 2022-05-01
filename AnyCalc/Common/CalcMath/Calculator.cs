using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnyCalc.Common.CalcMath
{
    public class Calculator
    {
        // Consts & Configs
        private const string SplitWithOperatorsInputRegPattern = "(?>\\(-([^{0}]+)\\)([^(?R)]|))|(?>([^{1}]+)([^(?R)]|))";
        private static readonly Dictionary<string, int> OperatorOrderResolver = new Dictionary<string, int>
        {
            ["+"] = 0,
            ["-"] = 0,
            ["*"] = 10,
            ["/"] = 10,
        };

        private const string OpenBracket = "(";
        private const string CloseBracket = ")";

        // Fields
        private Dictionary<string, Func<string, string, string>> OperationsAvailable;
        private Regex devideExpressionReg;

        // Properties
        public ICalc CalcBase { get; set; }

        // ctors
        public Calculator(ICalc calcBase)
        {
            if (calcBase == null)
            {
                throw new NullReferenceException("CalcBase was null!");
            }

            CalcBase = calcBase;

            OperationsAvailable = new Dictionary<string, Func<string, string, string>>();

            OperationsAvailable.Add("+", CalcBase.Add);
            OperationsAvailable.Add("-", CalcBase.Substruct);
            OperationsAvailable.Add("*", CalcBase.Multiple);
            OperationsAvailable.Add("/", CalcBase.Devide);

            string devideExpressionRegStr = string.Empty;
            foreach (var item in OperatorOrderResolver.Keys)
            {
                devideExpressionRegStr += $"\\{item}";
            }

            devideExpressionRegStr = string.Format(SplitWithOperatorsInputRegPattern, devideExpressionRegStr, devideExpressionRegStr, CultureInfo.InvariantCulture);
            devideExpressionReg = new Regex(devideExpressionRegStr);
        }

        // Methods
        public string Calculate(string inputString)
        {
            string result = string.Empty;

            MatchCollection matchCollection = devideExpressionReg.Matches(inputString);

            if (IsAllBraketsClosed(matchCollection))
            {
                while (matchCollection.Count > 1 && !string.IsNullOrEmpty(GetOperatorFromMatch(matchCollection[0])))
                {
                    string upper = OperatorOrderResolver.Keys.ElementAt(0);
                    int leftOperandIdx = -1;
                    for (int i = matchCollection.Count - 1; i >= 0; i--)
                    {
                        string operatorToCheck = GetOperatorFromMatch(matchCollection[i]);

                        if (string.IsNullOrEmpty(operatorToCheck))
                        {
                            continue;
                        }

                        if (OperatorOrderResolver.ContainsKey(operatorToCheck))
                        {
                            if (OperatorOrderResolver[operatorToCheck] >= OperatorOrderResolver[upper])
                            {
                                upper = operatorToCheck;
                                leftOperandIdx = i;
                            }
                        }
                        else
                        {
                            throw new Exception("Unsupported operation");
                        }
                    }

                    if (leftOperandIdx + 1 >= matchCollection.Count)
                    {
                        throw new Exception("Expression not finished");
                    }

                    string leftOperand = GetOperandFromMatch(matchCollection[leftOperandIdx]);
                    string rightOperand = GetOperandFromMatch(matchCollection[leftOperandIdx + 1]);

                    int indexMargin = 0;
                    if (matchCollection[leftOperandIdx].Groups[0].Value.StartsWith(OpenBracket))
                    {
                        leftOperand = $"-{leftOperand}";
                    }

                    if (matchCollection[leftOperandIdx + 1].Groups[0].Value.StartsWith(OpenBracket))
                    {
                        rightOperand = $"-{rightOperand}";
                        indexMargin = 3;
                    }

                    result = OperationsAvailable[GetOperatorFromMatch(matchCollection[leftOperandIdx])](leftOperand, rightOperand);

                    inputString = inputString.Substring(0, matchCollection[leftOperandIdx].Index)
                        + result
                        + inputString.Substring(matchCollection[leftOperandIdx + 1].Index + GetOperandFromMatch(matchCollection[leftOperandIdx + 1]).Length + indexMargin);

                    matchCollection = devideExpressionReg.Matches(inputString);
                }
            }
            else
            {
                throw new Exception("Check closing brakets!");
            }

            return result;
        }

        private string GetOperandFromMatch(Match match)
        {
            if (match.Groups.Count != 5)
            {
                throw new Exception("Unexpected count of reg groups");
            }

            string result = match.Groups[3].Value;
            if (string.IsNullOrEmpty(result))
            {
                result = match.Groups[1].Value;
            }

            return result;
        }

        private string GetOperatorFromMatch(Match match)
        {
            if (match.Groups.Count != 5)
            {
                throw new Exception("Unexpected count of reg groups");
            }

            string result = match.Groups[4].Value;
            if (string.IsNullOrEmpty(result))
            {
                result = match.Groups[2].Value;
            }

            return result;
        }

        public void CheckBraketsTst(string inputString)
        {
            MatchCollection matchCollection = devideExpressionReg.Matches(inputString);
            bool res = IsAllBraketsClosed(matchCollection);
        }

        private bool IsAllBraketsClosed(MatchCollection matchCollection)
        {
            Stack<bool> braketsPairs = new Stack<bool>();

            // check for closing brackets
            if (matchCollection.Count > 1 && matchCollection.Cast<Match>().Any(o => o.Groups.Count > 2
                &&
                (o.Groups[1].Value.StartsWith(OpenBracket) || o.Groups[1].Value.EndsWith(CloseBracket))))
            {
                foreach (Match item in matchCollection)
                {
                    if (item.Groups[1].Value.StartsWith(OpenBracket))
                    {
                        braketsPairs.Push(true);
                    }

                    if (item.Groups[1].Value.EndsWith(CloseBracket))
                    {
                        int braketsCount = 0;
                        for (int i = item.Groups[1].Value.Length - 1; i >= 0; i--) // if there are more than one closed brakets
                        {
                            if (item.Groups[1].Value[i] == CloseBracket[0])
                            {
                                braketsCount++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        for (int i = 0; i < braketsCount; i++)
                        {
                            if (braketsPairs.Count > 0)
                            {
                                _ = braketsPairs.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return braketsPairs.Count == 0;
        }
    }
}
