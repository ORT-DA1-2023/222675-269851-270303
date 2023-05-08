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
        public DataWarehouse DataWarehouse { get; set; }
        public ClientController ClientController { get; set; }
        public GraphicMotor GraphicMotor { get; set; } = new GraphicMotor();
        public void AddAModelWithoutPreview(string clientName, string modelName, Figure figure, Material material)
        {

            try
            {
                GetModelByNameAndClient(clientName, modelName);

            }
            catch (Exception)
            {
                CreateAndAddModel(ClientController.GetClientByName(clientName), modelName, figure,material);
                return;
            }
            throw new BackEndException("model already exists");
        }
        public void AddAModelWithPreview(string clientName, string modelName, Figure figure, Material material)
        {
            AddAModelWithoutPreview(clientName, modelName, figure, material);
            AddPreviewToTheModel(clientName, modelName);
        }
        private void CreateAndAddModel(Client client, string modelName, Figure figure, Material material)
        {
            Model model = new Model() { Client = client, Name = modelName, Figure = figure, Material = material };
            DataWarehouse.Models.Add(model);
        }
        public Model GetModelByNameAndClient(string clientName, string modelName)
        {
            Client client = ClientController.GetClientByName(clientName);
            foreach (Model model in DataWarehouse.Models)
            {
                if (model.Name == modelName && model.Client.Equals(client))
                {
                    return model;
                }
            }
            throw new BackEndException("model doesnt exist");
        }
        private void AddPreviewToTheModel(string clientName, string modelName)
        {
            Model model = GetModelByNameAndClient(clientName, modelName);
            model.Preview = GraphicMotor.RenderModelPreview(model);
        }
        public void ChangeModelName(string clientName, string oldName, string newName)
        {
            Model model;
            try
            {
                model = GetModelByNameAndClient(clientName, oldName);
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                GetModelByNameAndClient(clientName, newName);
            }
            catch (Exception)
            {
                model.Name = newName;
            }
        }

        public void DeleteModelInList(string clientName, string modelName)
        {
            try
            {
                Model model = GetModelByNameAndClient(clientName, modelName);
                DataWarehouse.Models.Remove(model);
            }
            catch (Exception)
            {
            }

        }
    }

}
