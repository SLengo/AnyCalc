using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AnyCalc.Common.Views.BaseCalcView
{
    /// <summary>
    /// Interaction logic for CalcView.xaml
    /// </summary>
    public partial class CalcView : UserControl
    {
        // Consts & Configs

        // Fields

        // Properties
        private Dictionary<Type, ICalcView> _initialized_calcs_views { get; set; }

        // PropDPs
        public CalcVM ViewModel
        {
            get { return (CalcVM)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(CalcVM), typeof(CalcView), new PropertyMetadata(null));



        // ctors
        public CalcView()
        {
            InitializeComponent();
            _initialized_calcs_views = new Dictionary<Type, ICalcView>();

            if (ViewModel == null)
            {
                ViewModel = new CalcVM();
            }

            Loaded += CalcView_Loaded;
        }
        public CalcView(CalcVM viewModel)
        {
            InitializeComponent();
            _initialized_calcs_views = new Dictionary<Type, ICalcView>();

            ViewModel = viewModel;
            Loaded += CalcView_Loaded;
        }

        private void CalcView_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= CalcView_Loaded;
            ViewModel.SelectedCalcChanged = SelectedCalcChanged;
            ViewModel.InitVM();
        }

        // Methods
        private void SelectedCalcChanged(Type selectedCalc)
        {
            foreach (var item in SelectedCalcView.Children)
            {
                (item as FrameworkElement).Visibility = Visibility.Collapsed;
            }

            if (!_initialized_calcs_views.ContainsKey(selectedCalc))
            {
                ICalcView calcView = CalcsStorage.Instance.GetCalcModelViewByType(selectedCalc).GetView();
                calcView.ViewModel.InputSymbolCommand = ViewModel.InputSymbolCommand;

                _initialized_calcs_views[selectedCalc] = calcView;

                SelectedCalcView.Children.Add(_initialized_calcs_views[selectedCalc].GetView());
            }

            ViewModel.CurrentSelectedCalcVM = _initialized_calcs_views[selectedCalc].ViewModel;
            _initialized_calcs_views[selectedCalc].GetView().Visibility = Visibility.Visible;
        }
    }
}
