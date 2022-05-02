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
        ICommand InputSymbolCommand { get; set; }

        bool IsInputSymbolIsNumber(string symbol);
    }
}
