using System;

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
