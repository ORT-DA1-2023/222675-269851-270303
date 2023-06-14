using Render3D.BackEnd.Figures;
using System.Collections.Generic;

namespace Render3D.RenderLogic.RepoInterface
{
    public interface IFigureRepo
    {
        void Add(Figure figure);
        void Delete(int Id);
        void ChangeName(int Id, string newName);
        Figure Get(int Id);
        Figure GetByNameAndClient(string name, int clientId);
        List<Figure> GetFiguresOfClient(int clientId);

    }
}
