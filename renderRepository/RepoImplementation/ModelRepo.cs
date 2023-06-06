using Render3D.BackEnd;
using RenderLogic.RepoInterface;
using renderRepository.entities;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

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

        public Model GetByNameAndClient(string name, Client client)
        {
            using (var dbContext = new RenderContext())
            {
                var modelEntities = dbContext.ModelEntities
                    .Where(f => f.Name == name && f.ClientEntity == ClientEntity.FromDomain(client));
                return modelEntities.ElementAt(0).ToDomain();
            }
        }

        public List<Model> GetModelsOfClient(Client client)
        {
            using (var dbContext = new RenderContext())
            {
                var modelEntities = dbContext.ModelEntities
                    .Where(f => f.ClientEntity == ClientEntity.FromDomain(client))
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
    }
}
