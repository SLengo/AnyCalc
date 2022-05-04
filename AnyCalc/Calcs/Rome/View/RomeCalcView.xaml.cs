using AnyCalc.Common.Views.BaseCalcView;
using System.Windows;
using System.Windows.Controls;

namespace AnyCalc.Calcs.Rome.View
{
    /// <summary>
    /// Interaction logic for RomeCalcView.xaml
    /// </summary>
    public partial class RomeCalcView : UserControl, ICalcView
    {
        // Consts & Configs

        // Fields

        // Properties

        // PropDPs
        public ICalcVM ViewModel
        {
            get { return (RomeCalcVM)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ICalcVM), typeof(RomeCalcView), new PropertyMetadata(null));

        // ctors
        public RomeCalcView(RomeCalcVM viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public RomeCalcView()
        {
            InitializeComponent();
            if (ViewModel == null)
            {
                ViewModel = new RomeCalcVM();
            }
        }

        // Methods
        public FrameworkElement GetView()
        {
            return this;
        }
    }
}
