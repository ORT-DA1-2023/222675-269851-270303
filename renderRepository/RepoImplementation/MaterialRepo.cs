using Render3D.BackEnd;
using Render3D.BackEnd.Materials;
using RenderLogic.RepoInteface;
using renderRepository.entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace renderRepository.RepoImplementation
{
    public class MaterialRepo : IMaterialRepo
    {
        public MaterialRepo() { }

        public void Add(Material material)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = MaterialEntity.FromDomain(material);
                dbContext.MaterialEntities.Add(entity);
                dbContext.SaveChanges();
                material.Id = entity.Id.ToString();
            }
        }

        public void ChangeName(int Id, string newName)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.MaterialEntities.Find(Id);
                entity.Name = newName;
                dbContext.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.MaterialEntities.Find(Id);
                dbContext.MaterialEntities.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public Material Get(int Id)
        {
            using (var dbContext = new RenderContext())
            {
                MaterialEntity materialEntity = dbContext.MaterialEntities.Find(Id);
                return materialEntity.ToDomain();
            }
        }

        public Material GetByNameAndClient(string name, Client client)
        {
            using (var dbContext = new RenderContext())
            {
                var materialEntities = dbContext.MaterialEntities
                    .Where(f => f.Name == name && f.ClientEntity == ClientEntity.FromDomain(client));
                return materialEntities.ElementAt(0).ToDomain();
            }
        }

        public List<Material> GetMaterialsOfClient(Client client)
        {
            using (var dbContext = new RenderContext())
            {
                var materialEntities = dbContext.MaterialEntities
                    .Where(f => f.ClientEntity == ClientEntity.FromDomain(client))
                    .ToList();
                List<Material> clientMaterials = new List<Material>();
                foreach (var m in materialEntities)
                {
                    clientMaterials.Add(m.ToDomain());
                }
                return clientMaterials;
            }
        }
    }
}
