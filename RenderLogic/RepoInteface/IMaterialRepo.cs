using Render3D.BackEnd.Figures;
using Render3D.BackEnd;
using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderLogic.RepoInterface
{
    public interface IMaterialRepo
    {
        void Add(Material material);
        void Delete(int Id);
        void ChangeName(int Id, string newName);
        Material Get(int Id);
        Material GetByNameAndClient(string name, Client client);
        List<Material> GetMaterialsOfClient(Client client);

    }
}
