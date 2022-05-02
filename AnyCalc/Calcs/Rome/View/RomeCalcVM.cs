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
        public bool IsInputSymbolValid(string symbol)
        {
            throw new NotImplementedException();
        }
    }
}
