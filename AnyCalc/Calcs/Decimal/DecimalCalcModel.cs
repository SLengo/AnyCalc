using AnyCalc.Calcs.Decimal.View;
using AnyCalc.Common.CalcMath;
using AnyCalc.Common.Views.BaseCalcView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnyCalc.Calcs.Decimal
{
    public class DecimalCalcModel : ICalcModel
    {
        private static DecimalCalc DecimalCalc { get; set; }

        public string CalcName => "Decimal";
        public Type CalcMathType => typeof(DecimalCalc);

        public ICalc GetCalc() => DecimalCalc ?? (DecimalCalc = new DecimalCalc());

        public ICalcView GetView()
        {
            return new DecimalCalcView();
        }
    }
}
