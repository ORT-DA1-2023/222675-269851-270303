using Render3D.BackEnd;
using Render3D.BackEnd.Utilities;
using RenderLogic.Services;
using System;

namespace Render3D.RenderLogic.Controllers
{
    public class ClientController
    {
        private const string _passwordSafe = "ThisPasswordIsS4fe";
        private const string _validName = "validName";
        protected static ClientController clientController;
        public Client Client { get; set; }
        public ClientService ClientService { get; set; }
        public static ClientController GetInstance()
        {
            if(clientController == null)
            {
                clientController = new ClientController();  
            }
            return clientController;
        }

        public void SignIn(string clientName, string clientPassword)
        {
            try{
                GetClientByName(clientName);            
            }
            catch
            {
                CreateAndAddClient(clientName, clientPassword);
                return;
            }
            throw new Exception("Client already exists");
           
        }
        private void CreateAndAddClient(string clientName, string clientPassword)
        {
           Client = new Client() { Name = clientName, Password = clientPassword };
           ClientService.AddClient(Client);

        }
        public void CheckName(string clientName)
        {
            _ = new Client() { Name = clientName, Password = _passwordSafe };
        }

        public void CheckPassword(string clientPassword)
        {
            _ = new Client() { Name = _validName, Password = clientPassword };
        }

        public Client GetClientByName(string clientName)
        {
            return ClientService.GetClientWithName(clientName);
        }

        public void Login(string clientName, string clientPassword)
        {
            Client client;
            try
            {
              client = ClientService.GetClientWithName(clientName);    
            }
            catch 
            {
                throw new Exception("A Client with that name does not exist");
            }
            if (client.Password == clientPassword)
            {
                Client = client;
            }
            else
            {
                throw new Exception("Password Incorrect");
            }
        }

        public void LogOut()
        {
           Client =null;
        }

        public string GetClient()
        {
            return Client.Name;
        }
    }
}
