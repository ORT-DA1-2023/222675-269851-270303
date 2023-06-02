using Render3D.BackEnd.Figures;

namespace RenderLogic.RepoInterface
{
    public interface IFigureRepo
    {
        void Add(Figure figure);
        void Delete(string name, string clientName);
        Figure Get(string name, string clientName);
        bool Exists(string name, string clientName);

    }
}
