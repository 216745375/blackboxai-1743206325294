using System;
using System.Windows.Input;

namespace WpfApp
{
    public class ViewModel
    {
        public ICommand ButtonCommand { get; }
        public string DisplayText { get; set; } = "Ready";

        public ViewModel()
        {
            ButtonCommand = new RelayCommand(ExecuteButtonClick);
        }

        private void ExecuteButtonClick(object parameter)
        {
            DisplayText = "Button clicked at " + DateTime.Now.ToString("HH:mm:ss");
            OnPropertyChanged(nameof(DisplayText));
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}