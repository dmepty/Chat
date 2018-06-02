using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChatClient.Annotations;
using ChatClient.Commands;
using ChatClient.ServiceChat;

namespace ChatClient.ViewModels
{
    class MainViewModel : INotifyPropertyChanged, IServiceChatCallback
    {
        private bool _isConnected;
        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                OnPropertyChanged();
            }
        }

        private string _buttonConnect = "'Connect";
        public string ButtonContent
        {
            get => _buttonConnect;
            set
            {
                _buttonConnect = value;
                OnPropertyChanged();
            }

        }

        private string _userName = "User name";
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        private int _id;
        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _messsage;
        public string Message
        {
            get => _messsage;
            set
            {
                _messsage = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _messages;
        public ObservableCollection<string> Messages
        {
            get => _messages;
            set
            {
                _messages = value;
                OnPropertyChanged();
            }
        }

        private ICommand _connectCommand;
        private ICommand _sendMessageCommand;


        public ServiceChatClient Client;


        public MainViewModel()
        {
           
        }

        public ICommand ConnectCommand => _connectCommand ?? (_connectCommand = new ConnectCommand(this));
        public ICommand SendMessageCommand => _sendMessageCommand ?? (_sendMessageCommand = new SendMessage(this));


        public void MessageCallback(string msg)
        {
            Messages.Add(msg);
        }




        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
