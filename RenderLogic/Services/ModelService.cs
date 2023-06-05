using Render3D.BackEnd.Materials;
using Render3D.BackEnd;
using System.Collections.Generic;
using RenderLogic.RepoInterface;

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
        public Model GetMaterialByNameAndClient(string modelName, Client client)
        {
            return _modelRepo.GetByNameAndClient(modelName, client);
        }

        public List<Model> GetMaterialOfClient(Client client)
        {
            return _modelRepo.GetModelsOfClient(client);
        }

        internal void UpdateName(string id, string newName)
        {
            _modelRepo.ChangeName(int.Parse(id), newName);
        }

    }
}
