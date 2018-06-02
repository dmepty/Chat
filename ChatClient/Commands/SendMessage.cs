using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ChatClient.ViewModels;

namespace ChatClient.Commands
{
    class SendMessage : ICommand
    {
        private MainViewModel _mainViewModel;
        

        public SendMessage(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mainViewModel.Client?.SendMessage(_mainViewModel.Message, _mainViewModel.ID);
            _mainViewModel.Message = string.Empty;
        }

        public event EventHandler CanExecuteChanged;
    }
}
