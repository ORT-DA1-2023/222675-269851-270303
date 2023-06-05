using Render3D.BackEnd.Materials;
using Render3D.BackEnd;
using System.Collections.Generic;

namespace RenderLogic.Services
{
    public class ModelService
    {
        void Add(Model model);
        void Delete(int Id);
        void ChangeName(int Id, string newName);
        Material Get(int Id);
        Material GetByNameAndClient(string name, Client client);
        List<Material> GetMaterialsOfClient(Client client);

    }
}
