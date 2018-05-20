using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chat
{
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        List<User> Users = new List<User>();
        private int nextId = 1;

        public int Connect(string name)
        {
            User user = new User
            {
                ID = nextId,
                Name = name,
                OperationContext = OperationContext.Current
            };
            nextId++;


            SendMessage(user.Name + " подключился", 0);


            Users.Add(user);
            return user.ID;
        }

        public void Disconect(int id)
        {
            var user = Users.FirstOrDefault(i => i.ID == id);

            if (user != null)
            {
                Users.Remove(user);
                SendMessage(user.Name + " отключился", 0);
            }
        }

        public void SendMessage(string msg, int id)
        {
            foreach (var itemUser in Users)
            {
                string answer = DateTime.Now.ToShortTimeString();

                var user = Users.FirstOrDefault(i => i.ID == id);

                if (user != null)
                {
                    answer += ": " + user.Name + " ";
                }

                answer += msg;

                itemUser.OperationContext.GetCallbackChannel<IServerChatCallback>().MessageCallback(answer);
            }
        }
    }
}
