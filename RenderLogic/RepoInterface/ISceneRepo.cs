using Render3D.BackEnd;
using RenderLogic.DataTransferObjects;
using System.Collections.Generic;

namespace RenderLogic.RepoInterface
{
    public interface ISceneRepo
    {
        void Add(Scene scene);
        void Delete(int Id);
        void UpdateName(int Id, string newName);
        Scene Get(int Id);
        Scene GetByNameAndClient(string name, Client client);
        List<Scene> GetScenesOfClient(Client client);
        void UpdatePreview(Scene scene);
        void UpdateCamera(Scene scene);
        void AddModel(int id,Model model);
        void RemoveModel(int id, Model model);
        List<Scene> GetScenesWithModel(Model model);
    }
}
