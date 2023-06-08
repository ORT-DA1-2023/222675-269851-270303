using Render3D.BackEnd;
using Render3D.BackEnd.Utilities;
using RenderLogic.Services;
using System;

namespace Render3D.RenderLogic.Controllers
{
    public class ClientController
    {
        protected static ClientController clientController;
        public Client Client { get; set; }
        public DataWarehouse DataWarehouse { get; set; }
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
            _ = new Client() { Name = clientName, Password = "ThisPasswordIsS4fe" };
        }

        public void CheckPassword(string clientPassword)
        {
            _ = new Client() { Name = "validName", Password = clientPassword };
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
                throw new Exception("a Client with that name does not exist");
            }
            if (client.Password == clientPassword)
            {
                Client = client;
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
