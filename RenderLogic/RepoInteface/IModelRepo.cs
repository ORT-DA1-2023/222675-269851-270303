using Render3D.BackEnd;
using System.Collections.Generic;

namespace RenderLogic.RepoInterface
{
    public interface IModelRepo
    {
        void Add(Model model);
        void Delete(int Id);
        void ChangeName(int Id, string newName);
        Model Get(int Id);
        Model GetByNameAndClient(string name, Client client);
        List<Model> GetModelsOfClient(Client client);
    }
}
