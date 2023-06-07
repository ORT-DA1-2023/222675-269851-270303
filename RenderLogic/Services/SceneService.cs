using Render3D.BackEnd;
using RenderLogic.DataTransferObjects;
using RenderLogic.RepoInterface;
using System;
using System.Collections.Generic;

namespace RenderLogic.Services
{
    public class SceneService
    {
        private readonly ISceneRepo _sceneRepo;

        public SceneService(ISceneRepo SceneRepo)
        {
            _sceneRepo = SceneRepo;
        }

        public void AddScene(Scene scene)
        {
            _sceneRepo.Add(scene);
        }
        public void RemoveScene(int Id)
        {
            _sceneRepo.Delete(Id);
        }
        public Scene GetScene(int Id)
        {
            return _sceneRepo.Get(Id);
        }
        public Scene GetSceneByNameAndClient(string sceneName, Client client)
        {
            return _sceneRepo.GetByNameAndClient(sceneName, client);
        }

        public List<Scene> GetScenesOfClient(Client client)
        {
            return _sceneRepo.GetScenesOfClient(client);
        }

        internal void UpdateName(int id, string newName)
        {
            _sceneRepo.UpdateName(id, newName);
        }

        internal void UpdatePreview(Scene scene)
        {
            _sceneRepo.UpdatePreview(scene);
        }

        internal void UpdateCamera(Scene scene)
        {
            _sceneRepo.UpdateCamera(scene);
        }

        internal void AddModel(int id, Model model)
        {
            _sceneRepo.AddModel(id, model);
        }

        internal void RemoveModel(int id, Model model)
        {
            _sceneRepo.RemoveModel(id,model);
        }
    }
}
