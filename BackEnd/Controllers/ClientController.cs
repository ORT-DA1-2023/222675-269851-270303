using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.Controllers
{
    public class ClientController
    {
        private DataWarehouse _dataWarehouse = new DataWarehouse();
        public DataWarehouse DataWarehouse { get; }

        public bool ExistsThisClient(string clientName, string clientPassword)
        {
            foreach (Client client in _dataWarehouse.Clients)
            {
                if (client.Name == clientName && client.Password == clientPassword)
                {
                    return true;
                }
            }
            return false;
        }
        public void TryToSignIn(string clientName, string clientPassword)
        {
            try
            {
                if (!ExistsThisClient(clientName, clientPassword))
                {
                    CreateAndAddAClient(clientName, clientPassword);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void CreateAndAddAClient(string clientName, string clientPassword)
        {
            Client client = new Client() { Name = clientName, Password = clientPassword };
            _dataWarehouse.Clients.Add(client);
        }
        private Client GetClientGivenAName(string clientName)
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
        public bool CheckName(string clientName)
        {
            try
            {
                Client client = new Client() { Name = clientName, Password = "ThisPasswordIsS4fe" };
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CheckPassword(string clientPassword)
        {
            try
            {
                Client client = new Client() { Name = "validName", Password = clientPassword };
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
