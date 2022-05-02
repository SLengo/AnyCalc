using AnyCalc.Common.Views.BaseCalcView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
