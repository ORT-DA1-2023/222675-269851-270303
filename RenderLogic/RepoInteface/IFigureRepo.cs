using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using System.Collections.Generic;

namespace RenderLogic.RepoInterface
{
    public interface IFigureRepo
    {
        void Add(Figure figure);
        void Delete(int Id);
        void ChangeName(int Id, string newName);
        Figure Get(int Id);
        Figure GetByNameAndClient(string name, Client client);
        List<Figure> GetFiguresOfClient(Client client);
       
    }
}
