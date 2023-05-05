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
            if (GetClientByName(clientName).Name != "")
            {
                CreateAndAddAClient(clientName, clientPassword);
            }
            else
            {
                throw new Exception( "client already exists");
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
            return new Client();
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
