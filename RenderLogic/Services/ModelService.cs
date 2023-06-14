using Render3D.BackEnd.Materials;
using Render3D.BackEnd;
using System.Collections.Generic;
using Render3D.RenderLogic.RepoInterface;
using Render3D.BackEnd.Figures;
using System;

namespace Render3D.RenderLogic.Services
{
    public class ModelService
    {
        private readonly IModelRepo _modelRepo;

        public ModelService(IModelRepo modelRepo)
        {
            _modelRepo = modelRepo;
        }

        public void AddModel(Model model)
        {
            _modelRepo.Add(model);
        }
        public void RemoveModel(int Id)
        {
            _modelRepo.Delete(Id);
        }
        public Model GetModel(int Id)
        {
            return _modelRepo.Get(Id);
        }
        public Model GetModelByNameAndClient(string modelName, int clientId)
        {
            return _modelRepo.GetByNameAndClient(modelName, clientId);
        }

        public List<Model> GetModelsOfClient(int clientId)
        {
            return _modelRepo.GetModelsOfClient(clientId);
        }

        public void UpdateName(int id, string newName)
        {
            _modelRepo.UpdateName(id, newName);
        }

        public void UpdatePreview(Model model)
        {
            _modelRepo.UpdatePreview(model);
        }

        public List<Model> GetModelsWithFigure(int figureId)
        {
            return _modelRepo.GetModelsWithFigure(figureId);
        }

        public List<Model> GetModelsWithMaterial(int materialId)
        {
            return _modelRepo.GetModelsWithMaterial(materialId);
        }
    }
}
