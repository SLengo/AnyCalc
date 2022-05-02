using AnyCalc.Calcs.Decimal.View;
using AnyCalc.Common.CalcMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCalc.Calcs.Decimal
{
    public class DecimalCalcModel : ICalcModel
    {
        public string CalcName => "Decimal";
        public Type CalcViewType => typeof(DecimalCalcView);
        public Type CalcMathType => typeof(DecimalCalc);
    }
}
