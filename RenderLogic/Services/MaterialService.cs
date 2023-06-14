using Render3D.BackEnd;
using System.Collections.Generic;
using Render3D.BackEnd.Materials;
using Render3D.RenderLogic.RepoInterface;

namespace Render3D.RenderLogic.Services
{
    public class MaterialService
    {
        private readonly IMaterialRepo _materialRepo;

        public MaterialService(IMaterialRepo materialRepo)
        {
            _materialRepo = materialRepo;
        }

        public void AddMaterial(Material material)
        {
            _materialRepo.Add(material);
        }
        public void RemoveMaterial(int Id)
        {
            _materialRepo.Delete(Id);
        }
        public Material GetFigure(int Id)
        {
            return _materialRepo.Get(Id);
        }
        public Material GetMaterialByNameAndClient(string MaterialName, int clientId)
        {
            return _materialRepo.GetByNameAndClient(MaterialName, clientId);
        }

        public List<Material> GetMaterialsOfClient(int clientId)
        {
            return _materialRepo.GetMaterialsOfClient(clientId);
        }

        public void UpdateName(int id, string newName)
        {
            _materialRepo.ChangeName(id, newName);
        }
    }
}

