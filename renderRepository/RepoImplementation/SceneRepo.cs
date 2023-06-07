using Render3D.BackEnd;
using RenderLogic.RepoInterface;
using renderRepository.entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace renderRepository.RepoImplementation
{
    public class SceneRepo : ISceneRepo
    {
        public void Add(Scene scene)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = SceneEntity.FromDomain(scene);
                dbContext.SceneEntities.Add(entity);
                dbContext.SaveChanges();
                scene.Id = entity.Id.ToString();
            }
        }

        public void Delete(int Id)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.SceneEntities.Find(Id);
                dbContext.SceneEntities.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public Scene Get(int Id)
        {
            using (var dbContext = new RenderContext())
            {
                SceneEntity sceneEntity = dbContext.SceneEntities.Find(Id);
                return sceneEntity.ToDomain();
            }
        }

        public Scene GetByNameAndClient(string name, Client client)
        {
            using (var dbContext = new RenderContext())
            {
                var sceneEntity = dbContext.SceneEntities
                    .Where(f => f.Name == name && f.ClientEntity == ClientEntity.FromDomain(client));
                return sceneEntity.ElementAt(0).ToDomain();
            }
        }

        public List<Scene> GetScenesOfClient(Client client)
        {
            using (var dbContext = new RenderContext())
            {
                var sceneEntities = dbContext.SceneEntities
                    .Where(f => f.ClientEntity == ClientEntity.FromDomain(client))
                    .ToList();
                List<Scene> clientScene = new List<Scene>();
                foreach (var m in sceneEntities)
                {
                    clientScene.Add(m.ToDomain());
                }
                return clientScene;
            }
        }

        public void UpdateCamera(Scene scene)
        {
            SceneEntity SceneEntity = SceneEntity.FromDomain(scene);
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.SceneEntities.Find(scene.Id);
                entity.LookFromX = SceneEntity.LookFromX;
                entity.LookFromY = SceneEntity.LookFromY;
                entity.LookFromZ = SceneEntity.LookFromZ;
                entity.LookAtX = SceneEntity.LookAtX;
                entity.LookAtY = SceneEntity.LookAtY;
                entity.LookAtZ = SceneEntity.LookAtZ;
                entity.Fov = SceneEntity.Fov;
                entity.Aperture = SceneEntity.Aperture;
                dbContext.SaveChanges();
            }
        }

        public void UpdateName(int Id, string newName)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.SceneEntities.Find(Id);
                entity.Name = newName;
                dbContext.SaveChanges();
            }
        }

        public void UpdatePreview(Scene scene)
        {
            SceneEntity SceneEntity = SceneEntity.FromDomain(scene);
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.SceneEntities.Find(scene.Id);
                entity.Preview = SceneEntity.Preview;
                dbContext.SaveChanges();
            }
        }
    }
}
