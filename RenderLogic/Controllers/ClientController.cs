using Render3D.BackEnd;
using Render3D.BackEnd.Utilities;
using System;

namespace Render3D.RenderLogic.Controllers
{
    public class ClientController
    {
        public DataWarehouse DataWarehouse { get; set; }

        public void SignIn(string clientName, string clientPassword)
        {
            try
            {
                GetClientByName(clientName);
                throw new Exception("client already exists");
            }
            catch (Exception)
            {
                SignUp(clientName, clientPassword);
            }
        }
        private void SignUp(string clientName, string clientPassword)
        {
            Client client = new Client() { Name = clientName, Password = clientPassword };
            DataWarehouse.Clients.Add(client);
        }
        public Client GetClientByName(string clientName)
        {
            foreach (Client client in DataWarehouse.Clients)
            {
                if (client.Name == clientName)
                {
                    return client;
                }
            }
            throw new BackEndException("The client doesnt exist");
        }
        public void CheckName(string clientName)
        {
            _ = new Client() { Name = clientName, Password = "ThisPasswordIsS4fe" };
        }

        public void CheckPassword(string clientPassword)
        {
            _ = new Client() { Name = "validName", Password = clientPassword };
        }

    }
}
