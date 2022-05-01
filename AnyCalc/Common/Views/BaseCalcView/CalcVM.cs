using AnyCalc.Calcs.Decimal;
using AnyCalc.Common.CalcMath;
using AnyCalc.Common.Views.BaseCalcView.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnyCalc.Common.Views.BaseCalcView
{
    public class CalcVM : BaseNotified
    {
        // Consts & Configs
        private const string ClearCurrentValue = "0";

        private const string OpenBracket = "(";
        private const string CloseBracket = ")";

        // Fields

        // Properties
        private ObservableCollection<CalcAvailableItem> availableCalcs { get; set; }
        public ObservableCollection<CalcAvailableItem> AvailableCalcs
        {
            get => availableCalcs;
            set
            {
                availableCalcs = value;
                OnPropertyChanged(nameof(AvailableCalcs));
            }
        }

        private CalcAvailableItem currentSelectedCalc { get; set; }
        public CalcAvailableItem CurrentSelectedCalc
        {
            get => currentSelectedCalc;
            set
            {
                currentSelectedCalc = value;
                SelectedCalcChanged?.Invoke(currentSelectedCalc.CalcMathType);
                OnPropertyChanged(nameof(CurrentSelectedCalc));
            }
        }

        private ICalcVM currentSelectedCalcVM { get; set; }
        public ICalcVM CurrentSelectedCalcVM
        {
            get => currentSelectedCalcVM;
            set
            {
                currentSelectedCalcVM = value;
                OnPropertyChanged(nameof(CurrentSelectedCalcVM));
            }
        }
        public Action<Type> SelectedCalcChanged;

        private string currentValue { get; set; } = ClearCurrentValue;
        public string CurrentValue
        {
            get => currentValue;
            set
            {
                currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private string calcExpression { get; set; }
        public string CalcExpression
        {
            get => calcExpression;
            set
            {
                calcExpression = value;
                OnPropertyChanged(nameof(CalcExpression));
            }
        }

        private string answer { get; set; }
        public string Answer
        {
            get => answer;
            set
            {
                answer = value;
                OnPropertyChanged(nameof(Answer));
            }
        }

        private RelayCommand inputSymbolCommand { get; set; }
        public RelayCommand InputSymbolCommand
        {
            get => inputSymbolCommand ?? (inputSymbolCommand = new RelayCommand((o) =>
            {
                InputSymbolMethod(o as string);
            }));
            set
            {
                inputSymbolCommand = value;
                OnPropertyChanged(nameof(InputSymbolCommand));
            }
        }

        private RelayCommand backspaceCommand { get; set; }
        public RelayCommand BackspaceCommand
        {
            get => backspaceCommand ?? (backspaceCommand = new RelayCommand((o) =>
            {
                BackspaceMethod();
            }));
            set
            {
                backspaceCommand = value;
                OnPropertyChanged(nameof(BackspaceCommand));
            }
        }

        private RelayCommand clearCommand { get; set; }
        public RelayCommand ClearCommand
        {
            get => clearCommand ?? (clearCommand = new RelayCommand((o) =>
            {
                ClearMethod();
            }));
            set
            {
                clearCommand = value;
                OnPropertyChanged(nameof(ClearCommand));
            }
        }

        private RelayCommand plusMinusCommand { get; set; }
        public RelayCommand PlusMinusCommand
        {
            get => plusMinusCommand ?? (plusMinusCommand = new RelayCommand((o) =>
            {
                PlusMinusMethod();
            }));
            set
            {
                plusMinusCommand = value;
                OnPropertyChanged(nameof(PlusMinusCommand));
            }
        }

        private RelayCommand calcCommand { get; set; }
        public RelayCommand CalcCommand
        {
            get => calcCommand ?? (calcCommand = new RelayCommand((o) =>
            {
                CalcMethod();
            }));
            set
            {
                calcCommand = value;
                OnPropertyChanged(nameof(CalcCommand));
            }
        }

        // ctors
        public CalcVM()
        {
            AvailableCalcs = new ObservableCollection<CalcAvailableItem>();
        }

        // Methods
        public void InitVM()
        {
            foreach (var calc in CalcsStorage.Instance.GetAllRegistredCalcs())
            {
                CalcAvailableItem itemToAdd = new CalcAvailableItem
                {
                    CalcName = calc.CalcName,
                    CalcMathType = calc.CalcMathType,
                };

                AvailableCalcs.Add(itemToAdd);
            }

            CurrentSelectedCalc = AvailableCalcs.FirstOrDefault();
        }

        private void InputSymbolMethod(string symbol)
        {
            if (!string.IsNullOrEmpty(symbol))
            {
                bool isDigit = CurrentSelectedCalcVM.IsInputSymbolValid(symbol);

                if (isDigit)
                {
                    if (CurrentValue == ClearCurrentValue)
                    {
                        CurrentValue = string.Empty;
                    }
                    CurrentValue += symbol;
                }
                else
                {
                    CalcExpression += $"{CurrentValue}{symbol}";
                    CurrentValue = ClearCurrentValue;
                }
            }
        }

        private void BackspaceMethod()
        {
            if (!string.IsNullOrEmpty(CurrentValue))
            {
                CurrentValue = CurrentValue.Substring(0, CurrentValue.Length - 1);
                if (string.IsNullOrEmpty(CurrentValue))
                {
                    CurrentValue = ClearCurrentValue;
                }
            }
        }

        private void ClearMethod()
        {
            CurrentValue = ClearCurrentValue;
            CalcExpression = string.Empty;
            Answer = string.Empty;
        }

        private void PlusMinusMethod()
        {
            if (!string.IsNullOrEmpty(CurrentValue) && CurrentValue != ClearCurrentValue)
            {
                if (CurrentValue.StartsWith(OpenBracket))
                {
                    CurrentValue = CurrentValue.Substring(2, CurrentValue.Length - 3);
                }
                else
                {
                    CurrentValue = $"{OpenBracket}-{CurrentValue}{CloseBracket}";
                }
            }
        }

        private void CalcMethod()
        {
            if (string.IsNullOrEmpty(CalcExpression))
            {
                Answer = "Empty expression!";
            }
            else
            {
                CalcExpression += CurrentValue;

                ICalc calcMath = Activator.CreateInstance(CurrentSelectedCalcVM.CalcMathType) as ICalc;
                Calculator calculator = new Calculator(calcMath);

                try
                {
                    Answer = calculator.Calculate(CalcExpression);
                    CurrentValue = ClearCurrentValue;
                }
                catch (Exception error) // TODO: define own CalculateException type
                {
                    Answer = error.Message;
                }

                CalcExpression = string.Empty;
            }
        }
    }
}
