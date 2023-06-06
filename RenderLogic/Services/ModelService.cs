using Render3D.BackEnd.Materials;
using Render3D.BackEnd;
using System.Collections.Generic;
using RenderLogic.RepoInterface;
using System;
using System.Drawing;

namespace RenderLogic.Services
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
        public Model GetModelByNameAndClient(string modelName, Client client)
        {
            return _modelRepo.GetByNameAndClient(modelName, client);
        }

        public List<Model> GetModelsOfClient(Client client)
        {
            return _modelRepo.GetModelsOfClient(client);
        }

        internal void UpdateName(string id, string newName)
        {
            _modelRepo.UpdateName(int.Parse(id), newName);
        }

        internal void UpdatePreview(Model model)
        {
            _modelRepo.UpdatePreview(model);
        }
    }
}
