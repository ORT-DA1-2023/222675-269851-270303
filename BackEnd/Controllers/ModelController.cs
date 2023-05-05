using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd.Controllers
{
    public class ModelController
    {
        private DataWarehouse _dataWarehouse;
        private ClientController _clientController;
        private GraphicMotor _graphicMotor= new GraphicMotor();

        public DataWarehouse DataWarehouse { get => _dataWarehouse; set { _dataWarehouse = value; } }
        public ClientController ClientController { get => _clientController; set => _clientController = value; }
        public void AddAModelWithoutPreview(string clientName, string modelName, Figure figure, Material material)
        {
            
            if (GetModelByNameAndClient(clientName, modelName)==null)
            {
                try
                {
                    TransferModelForCreation(ClientController.GetClientByName(clientName), modelName, figure, material);

                }
                catch (Exception e)
                {
                }
            }  
        }
        public void AddAModelWithPreview(string clientName, string modelName, Figure figure, Material material)
        {
            AddAModelWithoutPreview(clientName, modelName, figure, material);
            AddPreviewToTheModel(clientName, modelName);
        }
        private void TransferModelForCreation(Client client, string modelName, Figure figure, Material material)
        {
            Model model = new Model() { Client = client, Name = modelName, Figure = figure, Material = material };
            _dataWarehouse.Models.Add(model);
        }
        private Model GetModelByNameAndClient(string clientName, string modelName)
        {
            Client client = ClientController.GetClientByName(clientName);
            foreach (Model model in _dataWarehouse.Models)
            {
                if (model.Name == modelName && model.Client.Equals(client))
                {
                    return model;
                }
            }
            return null;
        }
        private void AddPreviewToTheModel(string clientName, string modelName)
        {
            Model model = GetModelByNameAndClient(clientName, modelName);
            model.Preview = _graphicMotor.RenderModelPreview(model);
        }
        public void ChangeModelName(string clientName, string oldName, string newName)
        {
            Model model = GetModelByNameAndClient(clientName, oldName);
            if (model == null)
            {
                return;
            }
            if (GetModelByNameAndClient(clientName, newName) != null)
            {
                return;
            }
            model.Name = newName;
            return;
        }

        public void deleteModelInList(string clientName, string modelName)
        {
            Model model = GetModelByNameAndClient(clientName, modelName);
            if (model != null)
            {
                _dataWarehouse.Models.Remove(model);
            }
        }
    }

}
