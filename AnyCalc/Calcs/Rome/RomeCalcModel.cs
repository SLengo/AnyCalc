using AnyCalc.Calcs.Rome.View;
using AnyCalc.Common.CalcMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCalc.Calcs.Rome
{
    public class RomeCalcModel : ICalcModel
    {
        public string CalcName => "Rome";
        public Type CalcViewType => typeof(RomeCalcView);
        public Type CalcMathType => typeof(RomeCalc);
    }
}
