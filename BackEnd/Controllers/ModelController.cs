using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using System;
using System.Collections.Generic;

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
                CreateAndAddModel(ClientController.GetClientByName(clientName), modelName, figure, material);
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
        public List<Model> GetModelsWithFigure(string figureName)
        {
            List<Model> modelsWithFigure = new List<Model>();
            foreach (Model model in DataWarehouse.Models)
            {
                if (model.Figure.Name.Equals(figureName))
                {
                    modelsWithFigure.Add(model);
                }
            }
            if (modelsWithFigure.Count == 0)
            {
                throw new BackEndException("No models found");
            }

            return modelsWithFigure;
        }
			
        public List<Model> GetModelWithMaterial(string materialName)
        {
            List<Model> modelsWithMaterial = new List<Model>();
           foreach(Model model in DataWarehouse.Models)
            {
                if(model.Material.Name.Equals(materialName))
                {
                    modelsWithMaterial.Add(model);
                }
            }
            if (modelsWithMaterial.Count == 0)
            {
                throw new BackEndException("No models with this material");
            }
            return modelsWithMaterial;
        }
    }

}
