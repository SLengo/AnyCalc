using AnyCalc.Common.Views;
using AnyCalc.Common.Views.BaseCalcView;
using System.Windows.Input;

namespace AnyCalc.Calcs.Rome.View
{
    public class RomeCalcVM : BaseNotified, ICalcVM
    {
        // Consts & Configs

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
            return RomeCalc.SingleRomeToNumResolver.ContainsKey(char.ToUpper(symbol[0]));
        }
    }
}
