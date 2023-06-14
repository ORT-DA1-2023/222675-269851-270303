using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;

namespace Render3D.RenderLogic.RepoInterface
{
    public interface IClientRepo
    {
        void Add(Client client);
        Client Get(int id);
        Client GetClientByName(string Name);
        void Remove(string name);
        void AddCamera(int id, Camera camera);
        Camera GetCamera(int id);
    }
}
