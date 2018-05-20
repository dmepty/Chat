using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChatClient.ViewModels;

namespace ChatClient.Commands
{
    class DisconnectCommand : ICommand
    {
        private MainViewModel _mainViewModel;

        public DisconnectCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_mainViewModel.IsConnected)
            {
                _mainViewModel.IsConnected = false;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
