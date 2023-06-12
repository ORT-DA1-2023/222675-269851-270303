using Render3D.BackEnd;

namespace RenderLogic.RepoInterface
{
    public interface IClientRepo
    {
        void Add(Client client);
        Client Get(int id);
        Client GetClientByName(string Name);
        void Remove(string name);
    }
}
