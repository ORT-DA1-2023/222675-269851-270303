using Render3D.BackEnd;
using RenderLogic.RepoInterface;
using renderRepository.entities;
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

                int clientId = int.Parse(scene.Client.Id);
                var client = dbContext.ClientEntities.Find(clientId);
                entity.ClientEntity = client;
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
                var scene = sceneEntity.ToDomain();
                var models = sceneEntity.ModelEntities;
                foreach (var modelEntity in models)
                {
                    var material = modelEntity.MaterialEntity.ToDomain();
                    var figure = modelEntity.FigureEntity.ToDomain();
                    var model = modelEntity.ToDomain();
                    model.Figure = figure;
                    model.Material = material;
                    scene.PositionedModels.Add(model);
                }
                return scene;
            }
        }

        public Scene GetByNameAndClient(string name, int clientId)
        {
            using (var dbContext = new RenderContext())
            {
                var sceneEntity = dbContext.SceneEntities
                    .Where(s => s.Name == name && s.ClientEntity.Id == clientId)
                    .FirstOrDefault();
                var scene = sceneEntity.ToDomain();
                var models = sceneEntity.ModelEntities;
                foreach (var modelEntity in models)
                {
                    var material = modelEntity.MaterialEntity.ToDomain();
                    var figure = modelEntity.FigureEntity.ToDomain();
                    var model = modelEntity.ToDomain();
                    model.Figure = figure;
                    model.Material = material;
                    scene.PositionedModels.Add(model);
                }
                return scene;
            }
        }

        public List<Scene> GetScenesOfClient(int clientId)
        {
            using (var dbContext = new RenderContext())
            {
                var sceneEntities = dbContext.SceneEntities
                    .Where(s => s.ClientEntity.Id == clientId)
                    .ToList();
                List<Scene> clientScene = new List<Scene>();
                foreach (var s in sceneEntities)
                {
                    var scene= s.ToDomain();
                    var models = s.ModelEntities;
                    foreach (var modelEntity in models)
                    {
                        var material = modelEntity.MaterialEntity.ToDomain();
                        var figure = modelEntity.FigureEntity.ToDomain();
                        var model = modelEntity.ToDomain();
                        model.Figure = figure;
                        model.Material = material;
                        scene.PositionedModels.Add(model);
                    }
                    clientScene.Add(s.ToDomain());
                }
                return clientScene;
            }
        }

        public void UpdateCamera(Scene scene)
        {
            SceneEntity sceneEntity = SceneEntity.FromDomain(scene);
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.SceneEntities.Find(sceneEntity.Id);
                entity.LookFromX = sceneEntity.LookFromX;
                entity.LookFromY = sceneEntity.LookFromY;
                entity.LookFromZ = sceneEntity.LookFromZ;
                entity.LookAtX = sceneEntity.LookAtX;
                entity.LookAtY = sceneEntity.LookAtY;
                entity.LookAtZ = sceneEntity.LookAtZ;
                entity.Fov = sceneEntity.Fov;
                entity.Aperture = sceneEntity.Aperture;
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

        public void AddModel(Scene scene, Model model)
        {
            SceneEntity sceneEntity = SceneEntity.FromDomain(scene);
            ModelEntity modelEntity = ModelEntity.FromDomain(model);
            FigureEntity figureEntity = FigureEntity.FromDomain(model.Figure);
            MaterialEntity materialEntity = MaterialEntity.FromDomain(model.Material);
            modelEntity.MaterialEntity = materialEntity;
            modelEntity.FigureEntity = figureEntity;
            using (var dbContext = new RenderContext())
            {
                dbContext.FigureEntities.Add(figureEntity);
                dbContext.MaterialEntities.Add(materialEntity);
                dbContext.ModelEntities.Add(modelEntity);
                var entity = dbContext.SceneEntities.Find(sceneEntity.Id);
                entity.LastModificationDate = sceneEntity.LastModificationDate;
                entity.ModelEntities.Add(modelEntity);
                dbContext.SaveChanges();
            }
        }

        public void UpdatePreview(Scene scene)
        {
            SceneEntity sceneEntity = SceneEntity.FromDomain(scene);
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.SceneEntities.Find(sceneEntity.Id);
                entity.Preview = sceneEntity.Preview;
                entity.LastRenderizationDate = sceneEntity.LastRenderizationDate;
                dbContext.SaveChanges();
            }
        }

        public void RemoveModel(Scene scene, Model model)
        {
            SceneEntity sceneEntity = SceneEntity.FromDomain(scene);
            using (var dbContext = new RenderContext())
            {
                SceneEntity entity = dbContext.SceneEntities.Find(sceneEntity.Id);
                ModelEntity modelEntity = ModelEntity.FromDomain(model);
                dbContext.ModelEntities.Remove(modelEntity);
                entity.LastModificationDate= sceneEntity.LastModificationDate;
                dbContext.SaveChanges();
            }
        }

        public List<Scene> GetScenesWithModel(Model model)
        {
            ModelEntity modelEntity = ModelEntity.FromDomain(model);
            using (var dbContext = new RenderContext())
            {
                var sceneEntities = dbContext.SceneEntities
                    .Where(s => s.ModelEntities.Any(m => m.Id == modelEntity.Id))
                    .ToList();
                List<Scene> scenes = new List<Scene>();
                foreach (var s in sceneEntities)
                {
                    scenes.Add(s.ToDomain());
                }
                return scenes;
            }
        }
    }
}
