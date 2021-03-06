using AnyCalc.Common.Views;
using AnyCalc.Common.Views.BaseCalcView;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace AnyCalc.Calcs.Decimal.View
{
    public class DecimalCalcVM : BaseNotified, ICalcVM
    {
        // Consts & Configs
        private static readonly Regex IsDigitReg = new Regex("\\d+");

        // Fields

        // Properties
        private ICommand inputSymbolCommand { get; set; }
        public ICommand InputSymbolCommand
        {
            get => inputSymbolCommand;
            set
            {
                inputSymbolCommand = value;
                OnPropertyChanged(nameof(InputSymbolCommand));
            }
        }

        // ctors

        // Methods
        public bool IsInputSymbolIsNumber(string symbol)
        {
            return IsDigitReg.IsMatch(symbol);
        }
    }
}
