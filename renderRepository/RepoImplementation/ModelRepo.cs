using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using RenderLogic.RepoInterface;
using renderRepository.entities;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace renderRepository.RepoImplementation
{
    public class ModelRepo :IModelRepo
    {
        public ModelRepo() { }

        public void Add(Model model)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = ModelEntity.FromDomain(model);
                int clientId = int.Parse(model.Client.Id);
                var client = dbContext.ClientEntities.Find(clientId);
                entity.ClientEntity = client;
                int figureId = int.Parse(model.Figure.Id);
                var figure = dbContext.FigureEntities.Find(figureId);
                entity.FigureEntity = figure;
                int materialId = int.Parse(model.Material.Id);
                var material = dbContext.MaterialEntities.Find(materialId);
                entity.MaterialEntity = material;   
                dbContext.ModelEntities.Add(entity);
                dbContext.SaveChanges();
                model.Id = entity.Id.ToString();
            }
        }

        public void UpdateName(int Id, string newName)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.ModelEntities.Find(Id);
                entity.Name = newName;
                dbContext.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.ModelEntities.Find(Id);
                dbContext.ModelEntities.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public Model Get(int Id)
        {
            using (var dbContext = new RenderContext())
            {
                ModelEntity modelEntity = dbContext.ModelEntities.Find(Id);
                return modelEntity.ToDomain();
            }
        }

        public Model GetByNameAndClient(string name, int clientId)
        {
            using (var dbContext = new RenderContext())
            {
                var modelEntities = dbContext.ModelEntities
                   .Where(m => m.Name == name && m.ClientEntity.Id == clientId)
                    .FirstOrDefault();
                return modelEntities.ToDomain();
            }
        }

        public List<Model> GetModelsOfClient(int clientId)
        {
            using (var dbContext = new RenderContext())
            {
                var modelEntities = dbContext.ModelEntities
                    .Where(m => m.ClientEntity.Id == clientId)
                    .GroupBy(m => m.Name)
                    .Select(m => m.FirstOrDefault())
                    .ToList();
                List<Model> clientModels = new List<Model>();
                foreach (var m in modelEntities)
                {
                    clientModels.Add(m.ToDomain());
                }
                return clientModels;
            }
        }

        public void UpdatePreview(Model model)
        {
           ModelEntity modelEntity= ModelEntity.FromDomain(model);
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.ModelEntities.Find(model.Id);
                entity.Preview = modelEntity.Preview;
                dbContext.SaveChanges();
            }
        }

        public List<Model> GetModelsWithFigure(int figureId)
        {
            using (var dbContext = new RenderContext())
            {
                var modelEntities = dbContext.ModelEntities
                    .Where(m => m.FigureEntity.Id == figureId)
                    .ToList();
                List<Model> Models = new List<Model>();
                foreach (var m in modelEntities)
                {
                    Models.Add(m.ToDomain());
                }
                return Models;
            }

        }

        public List<Model> GetModelsWithMaterial(int materialId)
        {
            using (var dbContext = new RenderContext())
            {
                var modelEntities = dbContext.ModelEntities
                    .Where(m => m.MaterialEntity.Id == materialId)
                    .ToList();
                List<Model> Models = new List<Model>();
                foreach (var m in modelEntities)
                {
                    Models.Add(m.ToDomain());
                }
                return Models;
            }

        }
    }
}
