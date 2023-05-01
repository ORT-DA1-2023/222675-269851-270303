using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;

namespace Render3D.BackEnd
{
    public class DataTransferObject
    {
        private DataWarehouse _dataWarehouse = new DataWarehouse();

        public DataWarehouse DataWareHouse { get => _dataWarehouse; }

        public bool alreadyExistsThisClient(string clientName, string clientPassword)
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
                if (alreadyExistsThisClient(clientName, clientPassword))
                {
                    return false;
                }
                transferClientForCreation(clientName, clientPassword);
                return true;
            }catch (Exception ex) {
                return false;
            } 
        }
        public bool tryToAddAfigure(String clientName, string figureName, decimal figureRadius)
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

        private void transferFigureForCreation(Client client, String figureName, decimal figureRadius)
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

        public bool tryToAddAMaterial(String clientName,string materialName, int[] materialColors)
        {
            Client client =getClientGivenAName(clientName);
            if (alreadyExistsThisMaterial(clientName, materialName))
            {
                return false;
            }
            else
            {
                try
                {
                    transferMaterialForCreation(client, materialName, materialColors);
                    return true;
                }catch (Exception e)
                {
                    return false;
                }
               
            }
        }

        public bool alreadyExistsThisMaterial(String clientName, string materialName)
        {
            Client client = getClientGivenAName(clientName);
            foreach (Material material in _dataWarehouse.Materials)
            {
                if (material.Name == materialName && material.Client.Equals(client))
                {
                    return true;
                }
            }
            return false;
        }

        private void transferMaterialForCreation(Client client, string materialName, int[] materialColors)
        {
           Material material= new LambertianMaterial() { Client =client, Name = materialName, Color=materialColors};
           _dataWarehouse.Materials.Add(material);
        }
    }
}