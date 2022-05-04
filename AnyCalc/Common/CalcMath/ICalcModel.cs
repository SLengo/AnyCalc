using AnyCalc.Common.Views.BaseCalcView;
using System;

namespace AnyCalc.Common.CalcMath
{
    public interface ICalcModel
    {
        string CalcName { get; }
        Type CalcMathType { get; }

        ICalcView GetView();
        ICalc GetCalc();
    }
}
