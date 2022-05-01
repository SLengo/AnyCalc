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
