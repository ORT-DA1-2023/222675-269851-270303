using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Render3D.BackEnd.Figures;

namespace Render3D.BackEnd
{
    public class DataTransferObject
    {
        private DataWarehouse _dataWarehouse = new DataWarehouse();

        public DataWarehouse DataWareHouse { get => _dataWarehouse; }

        public bool AlreadyExistsThisClient(string clientName, string clientPassword)
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

        public bool ifPosibleSignIn(string clientName, string clientPassword)
        {
            try
            {
                transferClientForCreation(clientName, clientPassword);
                return true;
            }catch (Exception ex) {
                return false;
            }
           
            
        }



        public void transferClientForCreation(string clientName, string clientPassword)
        {
            Client client = new Client() { Name = clientName, Password = clientPassword };
            _dataWarehouse.Clients.Add(client);
        }

        public void transferFigureForCreation(Client client, string figureName, int figureRadius)
        {
            Figure figure = new Sphere() { Client = client, Name = figureName, Radius = figureRadius };
            _dataWarehouse.Figures.Add(figure);
        }
    }
}