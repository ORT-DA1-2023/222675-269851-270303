using Render3D.BackEnd;
using System.Collections.Generic;

namespace Render3D.RenderLogic.RepoInterface
{
    public interface ISceneRepo
    {
        void Add(Scene scene);
        void Delete(int Id);
        void UpdateName(int Id, string newName);
        Scene Get(int Id);
        Scene GetByNameAndClient(string name, int clientId);
        List<Scene> GetScenesOfClient(int clientId);
        void UpdatePreview(Scene scene);
        void UpdateCamera(Scene scene);
        void AddModel(int id,Model model);
        void RemoveModel(int id, Model model);
        List<Scene> GetScenesWithModel(Model model);
    }
}
