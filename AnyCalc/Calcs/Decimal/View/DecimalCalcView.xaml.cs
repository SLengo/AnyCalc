using AnyCalc.Common.Views.BaseCalcView;
using System.Windows;
using System.Windows.Controls;

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
