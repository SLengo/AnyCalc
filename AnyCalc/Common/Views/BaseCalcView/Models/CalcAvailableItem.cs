using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCalc.Common.Views.BaseCalcView.Models
{
    public class CalcAvailableItem : BaseNotified
    {
        private string calcName { get; set; }
        public string CalcName
        {
            get => calcName;
            set
            {
                calcName = value;
                OnPropertyChanged(nameof(CalcName));
            }
        }

        public Type CalcMathType { get; set; }

        public override string ToString() => CalcName;
    }
}
