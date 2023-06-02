using Render3D.BackEnd.Materials;
using RenderLogic.RepoInterface;
using renderRepository.entities;
using System.Data;

namespace renderRepository.RepoImplementation
{
    public class MaterialRepo : IMaterialRepo
    {
        public MaterialRepo() { }
        public int AddMaterial(Material material)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = MaterialEntity.FromDomain(material);
                dbContext.MaterialEntities.Add(entity);
                dbContext.SaveChanges();
                return 0;
            }
        }
    }
}
