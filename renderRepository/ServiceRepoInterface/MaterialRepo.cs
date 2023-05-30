using Render3D.BackEnd.Materials;
using RenderLogic.RepoService;
using renderRepository.entities;

namespace renderRepository.ServiceRepoInterface
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

                material.Id = entity.Id.ToString();

                return entity.Id;
            }
        }
    }
}
