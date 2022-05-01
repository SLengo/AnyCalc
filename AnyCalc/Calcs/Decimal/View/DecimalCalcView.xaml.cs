using AnyCalc.Common.Views.BaseCalcView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnyCalc.Calcs.Decimal.View
{
    /// <summary>
    /// Interaction logic for DecimalCalcView.xaml
    /// </summary>
    public partial class DecimalCalcView : UserControl, ICalcView
    {
        // Consts & Configs

        // Fields

        // Properties

        // PropDPs
        public ICalcVM ViewModel
        {
            get { return (DecimalCalcVM)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ICalcVM), typeof(DecimalCalcView), new PropertyMetadata(null));

        // ctors
        public DecimalCalcView(DecimalCalcVM viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public DecimalCalcView()
        {
            InitializeComponent();
            if (ViewModel == null)
            {
                ViewModel = new DecimalCalcVM();
            }
        }

        // Methods
        public FrameworkElement GetView()
        {
            return this;
        }
    }
}
