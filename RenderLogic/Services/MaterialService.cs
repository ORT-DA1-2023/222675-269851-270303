using Render3D.BackEnd.Figures;
using Render3D.BackEnd;
using RenderLogic.RepoInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Render3D.BackEnd.Materials;

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

        public List<Material> GetMaterialOfClient(Client client)
        {
            return _materialRepo.GetMaterialsOfClient(client);
        }

        internal void UpdateName(string id, string newName)
        {
            _materialRepo.ChangeName(int.Parse(id), newName);
        }
    }
}
}
