using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Render3D.BackEnd
{
    public class DataTransferObject
    {
        private DataWarehouse _dataWarehouse = new DataWarehouse();

        public DataWarehouse DataWareHouse { get => _dataWarehouse; }

        public bool ifPosibleSignIn(string clientName, string clientPassword)
        {
            transferClientForCreation(clientName, clientPassword); 
            return true;
        }



        public void transferClientForCreation(string clientName, string clientPassword)
        {
            Client client = new Client() { Name = clientName, Password = clientPassword };
            _dataWarehouse.Clients.Add(client);
        }
    }
}