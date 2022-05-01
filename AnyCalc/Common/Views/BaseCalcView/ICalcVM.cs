using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnyCalc.Common.Views.BaseCalcView
{
    public interface ICalcVM
    {
        string CalcName { get; }
        Type CalcViewType { get; }
        Type CalcMathType { get; }

        ICommand InputSymbolCommand { get; set; }

        bool IsInputSymbolValid(string symbol);
    }
}
