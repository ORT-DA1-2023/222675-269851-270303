using Render3D.BackEnd;
using Render3D.RenderLogic.DataTransferObjects;
using Render3D.RenderLogic.RepoInterface;
using System;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Services
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
        public Scene GetSceneByNameAndClient(string sceneName, int clientId)
        {
            return _sceneRepo.GetByNameAndClient(sceneName, clientId);
        }

        public List<Scene> GetScenesOfClient(int clientId)
        {
            return _sceneRepo.GetScenesOfClient(clientId);
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

        internal List<Scene> GetScenesWithModel(Model model)
        {
           return _sceneRepo.GetScenesWithModel(model);
        }
    }
}
