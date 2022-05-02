using AnyCalc.Common.Views;
using AnyCalc.Common.Views.BaseCalcView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnyCalc.Calcs.Rome.View
{
    public class RomeCalcVM : BaseNotified, ICalcVM
    {
        // Consts & Configs

        // Fields

        // Properties
        public ICommand InputSymbolCommand { get; set; }

        // ctors

        // Methods
        public bool IsInputSymbolIsNumber(string symbol)
        {
            return RomeCalc.SingleRomeToNumResolver.ContainsKey(char.ToUpper(symbol[0]));
        }
    }
}
