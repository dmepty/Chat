using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChatClient.ServiceChat;
using ChatClient.ViewModels;

namespace ChatClient.Commands
{
    class ConnectCommand : ICommand
    {
        private MainViewModel _mainViewModel;
        private int _id;

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
                _mainViewModel.Client = new ServiceChatClient(new InstanceContext(_mainViewModel));

                _id = _mainViewModel.Client.Connect(_mainViewModel.UserName);
                _mainViewModel.ID = _id;

                _mainViewModel.IsConnected = true;
                _mainViewModel.ButtonContent = "Disconnect";
            }
            else
            {
                _mainViewModel.Client.Disconect(_id);
                _mainViewModel.Client = null;

                _mainViewModel.IsConnected = false;
                _mainViewModel.ButtonContent = "Connect";
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
