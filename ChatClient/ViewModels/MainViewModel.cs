using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChatClient.Commands;

namespace ChatClient.ViewModels
{
    class MainViewModel
    {
        public bool IsConnected { get; set; } = false;
        public string ButtonContent { get; set; } = "Connect";

        private ICommand _connectCommand;

        public MainViewModel()
        {
            
        }

        public ICommand ConnectCommand => _connectCommand ?? (_connectCommand = new ConnectCommand(this));
    }
}
