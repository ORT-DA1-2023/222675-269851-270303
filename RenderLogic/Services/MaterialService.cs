using Render3D.BackEnd;
using System.Collections.Generic;
using Render3D.BackEnd.Materials;
using RenderLogic.RepoInterface;

namespace RenderLogic.Services
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
        public Material GetMaterialByNameAndClient(string MaterialName, Client client)
        {
            return _materialRepo.GetByNameAndClient(MaterialName, client);
        }

        public List<Material> GetMaterialsOfClient(Client client)
        {
            return _materialRepo.GetMaterialsOfClient(client);
        }

        internal void UpdateName(int id, string newName)
        {
            _materialRepo.ChangeName(id, newName);
        }
    }
}

