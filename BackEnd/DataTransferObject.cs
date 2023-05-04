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
        private GraphicMotor graphicMotor= new GraphicMotor();

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
        public bool tryToAddAFigure(string clientName, string figureName, double figureRadius)
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

        private void transferFigureForCreation(Client client, string figureName, double figureRadius)
        {
            Figure figure = new Sphere() { Client = client, Name = figureName, Radius = figureRadius };
            _dataWarehouse.Figures.Add(figure);
        }
        private Client getClientGivenAName(string clientName)
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

        public bool checkName(string clientName)
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

        public bool checkPassword(string clientPassword)
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
        private Figure searchFigureInList(string clientName, string figureName)
        {
            Client client = getClientGivenAName(clientName);
            foreach (Figure figure in _dataWarehouse.Figures)
            {
                if (figure.Name == figureName && figure.Client.Equals(client))
                {
                    return figure;
                }
            }
            return null;
        }

        public bool alreadyExistsThisFigure(string clientName,string figureName)
        {
            if (searchFigureInList(clientName, figureName) != null)
            {
                return true;
            }
            return false;
        }
        public bool ifPosibleChangeFigureName(string clientName,string oldName, string newName)
        {
            Figure figure=searchFigureInList(clientName, oldName);
            if(figure == null)
            {
                return false;
            }
            if (searchFigureInList(clientName, newName) != null)
            {
                return false;
            }
            figure.Name= newName;
            return true;
        }
        

        public void deleteFigureInList(string clientName, string figureName)
        {
            
            Figure figure= searchFigureInList(clientName,figureName);
            if (figure != null)
            {
                _dataWarehouse.Figures.Remove(figure);
            }
        }

        public bool tryToAddAMaterial(string clientName,string materialName, int[] materialColors)
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

        public bool alreadyExistsThisMaterial(string clientName, string materialName)
        {
                if (searchMaterialInList(clientName,materialName)!=null)
                {
                    return true;
                }
            return false;
        }

        private void transferMaterialForCreation(Client client, string materialName, int[] materialColors)
        {
            Vector3D color= new Vector3D(materialColors[0], materialColors[1], materialColors[2]);
           Material material= new LambertianMaterial() { Client =client, Name = materialName, Color=color};
           _dataWarehouse.Materials.Add(material);
        }
        private Material searchMaterialInList(string clientName, string materialName)
        {
            Client client = getClientGivenAName(clientName);
            foreach (Material material in _dataWarehouse.Materials)
            {
                if (material.Name ==materialName && material.Client.Equals(client))
                {
                    return material;
                }
            }
            return null;
        }

        public bool ifPosibleChangeMaterialName(string clientName, string oldName, string newName)
        {
           Material material= searchMaterialInList(clientName, oldName);
           if(material== null)
            {
                return false;
            }
            if (searchMaterialInList(clientName, newName) != null)
            {
                return false;
            }
            material.Name= newName;
            return  true;
        }


        public void deleteMaterialInList(string clientName, string materialName)
        {
            Material material = searchMaterialInList(clientName, materialName);
            _dataWarehouse.Materials.Remove(material);
        }

        public void tryToAddAModelWithoutPreview(string clientName, string modelName, Figure figure, Material material)
        {
            Client client = getClientGivenAName(clientName);
            if (alreadyExistsThisModel(clientName, modelName))
            {
               // return new Exception ("model already exists");
            }
                try
                {
                    transferModelForCreation(client, modelName, figure, material);
                  //  return null;
                }
                catch (Exception e)
                {
                   // return e;
                }
        }
        public void tryToAddAModelWithPreview(string clientName, string modelName, Figure figure, Material material)
        {
         tryToAddAModelWithoutPreview(clientName, modelName, figure, material);
         addPreviewToTheModel(clientName, modelName);
        }

        private void transferModelForCreation(Client client, string modelName, Figure figure, Material material)
        {
            Model model= new Model() { Client = client, Name=modelName,Figure=figure,Material=material};
            _dataWarehouse.Models.Add(model);
        }
        private Model searchModelInList(string clientName,string modelName)
        {
            Client client = getClientGivenAName(clientName);
            foreach (Model model in _dataWarehouse.Models)
            {
                if (model.Name == modelName && model.Client.Equals(client))
                {
                    return model;
                }
            }
            return null;
        }

        public bool alreadyExistsThisModel(string clientName, string modelName)
        {
           if(searchModelInList(clientName, modelName)!=null)
            {
                return true;
            }
            return false;
        }

        


        private void addPreviewToTheModel(string clientName, string modelName)
        {
            Model model = searchModelInList(clientName, modelName);      
            model.Preview=graphicMotor.RenderModelPreview(model);
        }

        public bool ifPosibleChangeModelName(string clientName,string oldName, string newName)
        {
            Model model= searchModelInList(clientName, oldName);
            if (model == null)
            {
                return false;
            }
            if (searchModelInList(clientName, newName) != null)
            {
                return false;
            }
            model.Name=newName;
            return true;
        }

        public void deleteModelInList(string clientName, string modelName)
        {
            Model model = searchModelInList(clientName, modelName);
            if (model != null)
            {
                _dataWarehouse.Models.Remove(model);
            }
        }
    }
}
