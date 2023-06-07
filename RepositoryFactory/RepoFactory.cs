using Render3D.RenderLogic.Controllers;
using RenderLogic.RepoInterface;
using RenderLogic.Services;
using renderRepository.RepoImplementation;

namespace RepositoryFactory
{
    public class RepoFactory
    {
        public IClientRepo clientRepo = new ClientRepo();
        public IFigureRepo figureRepo = new FigureRepo();
        public IMaterialRepo materialRepo = new MaterialRepo();
        public IModelRepo modelRepo = new ModelRepo();
        public ISceneRepo sceneRepo = new SceneRepo();

        public void Initialize()
        {
            ClientController.GetInstance().ClientService= new ClientService(clientRepo);
            FigureController.GetInstance().FigureService = new FigureService(figureRepo);
            MaterialController.GetInstance().MaterialService = new MaterialService(materialRepo);
            ModelController.GetInstance().ModelService = new ModelService(modelRepo);
            SceneController.GetInstance().SceneService = new SceneService(sceneRepo);
            SceneController.GetInstance().ModelService = new ModelService(modelRepo);
        }

    }
}
