using Render3D.BackEnd;
using RenderLogic.RepoInteface;
using renderRepository.entities;
using System;
using System.Collections.Generic;

namespace renderRepository.RepoImplementation
{
    public class SceneRepo : ISceneRepo
    {
        public void Add(Scene scene)
        {
            using (var dbContext = new RenderContext())
            {
            }
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Scene Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Scene GetByNameAndClient(string name, Client client)
        {
            throw new NotImplementedException();
        }

        public List<Scene> GetScenesOfClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void UpdateName(int Id, string newName)
        {
            throw new NotImplementedException();
        }

        public void UpdatePreview(Scene scene)
        {
            throw new NotImplementedException();
        }
    }
}
