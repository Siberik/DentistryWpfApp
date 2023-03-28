/// <Summary>
/// Author : R. Arun Mutharasu
/// Created :17-01-2022
/// YouTube Channel : C# Design Pro 
/// </Summary>   

using System;
using System.ComponentModel;
using System.Windows.Input;

namespace DentistryWpfApp.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private bool _isPanelVisible;
        private ICommand _showPanelCommand;
        private ICommand _hidePanelCommand;

        public AppViewModel()
        {
            // Set Default Panel Visibility //
            IsPanelVisible = false;
        }

        // Panel Visibility Property //
        public bool IsPanelVisible
        {
            get
            {
                return _isPanelVisible;
            }
            set
            {
                _isPanelVisible = value;
                OnPropertyChanged("IsPanelVisible");
            }
        }

        // Show Panel Method //
        public void ShowPanel()
        {
            IsPanelVisible = true;
        }

        // Show Panel Command //
        public ICommand ShowPanelCommand
        {
            get
            {
                if (_showPanelCommand == null)
                {
                    _showPanelCommand = new RelayCommand.Command.RelayCommand(p => ShowPanel());
                }
                return _showPanelCommand;
            }
        }

        // Hide Panel Method //
        public void HidePanel()
        {
            IsPanelVisible = false;
        }

        // Hide Panel Command //
        public ICommand HidePanelCommand
        {
            get
            {
                if (_hidePanelCommand == null)
                {
                    _hidePanelCommand = new RelayCommand.Command.RelayCommand(p => HidePanel());
                }
                return _hidePanelCommand;
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }



    }
}
