using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.Controllers
{
    public class ClientController
    {
        private DataWarehouse _dataWarehouse;
        public DataWarehouse DataWarehouse { get => _dataWarehouse; set { _dataWarehouse=value;} }

        public void SignIn(string clientName, string clientPassword)
        {
            Client client;
            try
            {
               client= GetClientByName(clientName);
                throw new Exception("client already exists");
            }
            catch (Exception ex)
            {
                CreateAndAddAClient(clientName, clientPassword);
            }        
        }
        private void CreateAndAddAClient(string clientName, string clientPassword)
        {
            Client client = new Client() { Name = clientName, Password = clientPassword };
            _dataWarehouse.Clients.Add(client);
        }
        public Client GetClientByName(string clientName)
        {
            foreach (Client client in _dataWarehouse.Clients)
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
                Client client = new Client() { Name = clientName, Password = "ThisPasswordIsS4fe" };
        }

        public void CheckPassword(string clientPassword)
        {
                Client client = new Client() { Name = "validName", Password = clientPassword };
        }

    }
}
