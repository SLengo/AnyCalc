using AnyCalc.Calcs.Rome.View;
using AnyCalc.Common.CalcMath;
using AnyCalc.Common.Views.BaseCalcView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnyCalc.Calcs.Rome
{
    public class RomeCalcModel : ICalcModel
    {
        private static RomeCalc RomeCalc { get; set; }

        public string CalcName => "Rome";
        public Type CalcMathType => typeof(RomeCalc);

        public ICalc GetCalc() => RomeCalc ?? (RomeCalc = new RomeCalc());

        public ICalcView GetView()
        {
            return new RomeCalcView();
        }
    }
}
