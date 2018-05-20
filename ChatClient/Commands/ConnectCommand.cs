using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChatClient.ViewModels;

namespace ChatClient.Commands
{
    class ConnectCommand : ICommand
    {
        private MainViewModel _mainViewModel;

        public ConnectCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!_mainViewModel.IsConnected)
            {
                _mainViewModel.IsConnected = true;
                _mainViewModel.ButtonContent = "Connect";
            }
            else
            {
                _mainViewModel.IsConnected = false;
                _mainViewModel.ButtonContent = "Disconnect";
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
