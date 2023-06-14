using Render3D.BackEnd.Materials;
using System.Collections.Generic;

namespace Render3D.RenderLogic.RepoInterface
{
    public interface IMaterialRepo
    {
        void Add(Material material);
        void Delete(int Id);
        void ChangeName(int Id, string newName);
        Material Get(int Id);
        Material GetByNameAndClient(string name, int clientId);
        List<Material> GetMaterialsOfClient(int clientId);
    }
}
