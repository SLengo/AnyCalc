using System.Windows.Input;

namespace AnyCalc.Common.Views.BaseCalcView
{
    public interface ICalcVM
    {
        ICommand InputSymbolCommand { get; set; }

        bool IsInputSymbolIsNumber(string symbol);
    }
}
