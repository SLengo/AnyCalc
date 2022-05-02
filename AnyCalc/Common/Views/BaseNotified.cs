using System.ComponentModel;

namespace AnyCalc.Common.Views
{
    public abstract class BaseNotified : INotifyPropertyChanged
    {
        // Consts & Configs

        // Fields

        // Properties

        // ctors

        // Methods
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
