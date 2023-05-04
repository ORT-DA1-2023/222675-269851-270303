using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;

namespace Render3D.BackEnd
{
    public class DataTransferObject
    {
        private DataWarehouse _dataWarehouse = new DataWarehouse();

        public DataWarehouse DataWarehouse { get => _dataWarehouse; }

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
        public bool tryToAddAFigure(String clientName, string figureName, double figureRadius)
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

        private void transferFigureForCreation(Client client, String figureName, double figureRadius)
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
            Vector3D color= new Vector3D(materialColors[0], materialColors[1], materialColors[2]);
           Material material= new LambertianMaterial() { Client =client, Name = materialName, Color=color};
           _dataWarehouse.Materials.Add(material);
        }

        public bool ifPosibleChangeMaterialName(string clientName, string oldName, string newName)
        {
            Client client = getClientGivenAName(clientName);
            if (!alreadyExistsThisMaterial(clientName, newName))
            {
                foreach (Material material in _dataWarehouse.Materials)
                {
                    if (material.Name == oldName && material.Client.Equals(client))
                    {
                        material.Name = newName;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ifPosibleDeleteMaterial(string clientName, string materialName)
        {
            Client client = getClientGivenAName(clientName);
            int iterator = 0;
            foreach (Material material in _dataWarehouse.Materials)
            {
                if (material.Name == materialName && material.Client.Equals(client))
                {
                    _dataWarehouse.Materials.RemoveAt(iterator);
                    return true;
                }
                iterator++;
            }

            return false;
        }

        public bool tryToAddAModelWithoutPreview(string clientName, string modelName, Figure figure, Material material)
        {
            Client client = getClientGivenAName(clientName);
                try
                {
                    transferModelForCreation(client, modelName, figure, material);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
        }

        private void transferModelForCreation(Client client, string modelName, Figure figure, Material material)
        {
            Model model= new Model() { Client = client, Name=modelName,Figure=figure,Material=material};
            _dataWarehouse.Models.Add(model);
        }

        private bool alreadyExistsThisModel(string clientName, string modelName)
        {
            throw new NotImplementedException();
        }

        public void tryToAddAModelWithPreview(string clientName, string modelName, Figure figure, Material material)
        {
            throw new NotImplementedException();
        }
    }
}
