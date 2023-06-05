using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using System.Collections.Generic;

namespace RenderLogic.RepoInterface
{
    public interface IFigureRepo
    {
        void Add(Figure figure);
        void Delete(int Id);
        Figure Get(int Id);
        Figure GetByNameAndClient(string name, Client client);
        List<Figure> GetFiguresOfClient(Client client);
    }
}
