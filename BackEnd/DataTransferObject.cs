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
                if (AlreadyExistsThisClient(clientName, clientPassword))
                {
                    return false;
                }
                transferClientForCreation(clientName, clientPassword);
                return true;
            }catch (Exception ex) {
                return false;
            } 
        }
        public bool TryToAddAfigure(String clientName, string figureName, int figureRadius)
        {
            Client client=getClientGivenAName(clientName);
            if (alreadyExistsThisFigure(clientName, figureName)) 
            {
                return false;
            }
            try
            {
                transferFigureForCreation(client, figureName, figureRadius);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
           
        }

        private void transferClientForCreation(string clientName, string clientPassword)
        {
            Client client = new Client() { Name = clientName, Password = clientPassword };
            _dataWarehouse.Clients.Add(client);
        }

        private void transferFigureForCreation(Client client, String figureName, int figureRadius)
        {
            Figure figure = new Sphere() { Client = client, Name = figureName, Radius = figureRadius };
            _dataWarehouse.Figures.Add(figure);
        }
        private Client getClientGivenAName(String clientName)
        {
            foreach (Client client in _dataWarehouse.Clients)
            {
                if (client.Name == clientName)
                {
                    return client;
                }
            }
            return null;
        }

        public bool checkName(String clientName)
        {
            try
            {
                Client client = new Client() { Name = clientName, Password = "ThisPasswordIsS4fe" };
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool checkPassword(String clientPassword)
        {
            try
            {
                Client client = new Client() { Name = "validName", Password = clientPassword };
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool alreadyExistsThisFigure(String clientName,String figureName)
        {
            Client client = getClientGivenAName(clientName);
            foreach (Figure figure in _dataWarehouse.Figures)
            {
                if (figure.Name == figureName && figure.Client.Equals(client))
                {
                    return true;
                }
            }
            return false;
        }
        public bool ifPosibleChangeFigureName(String clientName,String oldName, String newName)
        {
            Client client = getClientGivenAName(clientName);
            if (!alreadyExistsThisFigure(clientName,newName)) 
            {
                foreach (Figure figure in _dataWarehouse.Figures)
                {
                    if (figure.Name == oldName && figure.Client.Equals(client))
                    {
                        figure.Name = newName;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ifPosibleDeleteFigure(string clientName, string figureName)
        {
            Client client= getClientGivenAName(clientName);
            int iterator = 0;
            foreach (Figure figure in _dataWarehouse.Figures)
            {
                if (figure.Name == figureName && figure.Client.Equals(client))
                {
                    _dataWarehouse.Figures.RemoveAt(iterator);
                    return true;
                }
                iterator++;
            }
            
            return false;
        }
    }
}