using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCalc.Common.CalcMath
{
    public interface ICalcModel
    {
        string CalcName { get; }
        Type CalcViewType { get; }
        Type CalcMathType { get; }
    }
}
