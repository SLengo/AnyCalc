using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnyCalc.Common.Views.BaseCalcView
{
    public interface ICalcView
    {
        ICalcVM ViewModel { get; set; }
        FrameworkElement GetView();
    }
}
