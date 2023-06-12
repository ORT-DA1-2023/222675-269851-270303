using Render3D.BackEnd;

namespace Render3D.RenderLogic.RepoInterface
{
    public interface IClientRepo
    {
        void Add(Client client);
        Client Get(int id);
        Client GetClientByName(string Name);
        void Remove(string name);
    }
}
