using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using System.Collections.Generic;

namespace RenderLogic.RepoInterface
{
    public interface IModelRepo
    {
        void Add(Model model);
        void Delete(int Id);
        void UpdateName(int Id, string newName);
        Model Get(int Id);
        Model GetByNameAndClient(string name, Client client);
        List<Model> GetModelsOfClient(Client client);
        void UpdatePreview(Model model);
        List<Model> GetModelsWithFigure(Figure figure);
        List<Model> GetModelsWithMaterial(Material material);
    }
}
