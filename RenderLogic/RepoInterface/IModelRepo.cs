using Render3D.BackEnd;
using System.Collections.Generic;

namespace Render3D.RenderLogic.RepoInterface
{
    public interface IModelRepo
    {
        void Add(Model model);
        void Delete(int Id);
        void UpdateName(int Id, string newName);
        Model Get(int Id);
        Model GetByNameAndClient(string name, int clientId);
        List<Model> GetModelsOfClient(int clientId);
        void UpdatePreview(Model model);
        List<Model> GetModelsWithFigure(int figureId);
        List<Model> GetModelsWithMaterial(int materialId);
    }
}
