using Render3D.BackEnd;
using Render3D.BackEnd.Materials;
using RenderLogic.RepoService;
using renderRepository.entities;

namespace renderRepository.ServiceRepoInterface
{
    public class ModelIRepo :IModelRepo
    {
        public ModelIRepo() { }
        public int AddModel(Model model)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = ModelEntity.FromDomain(model);

                dbContext.ModelEntities.Add(entity);

                dbContext.SaveChanges();

                model.Id = entity.Id.ToString();

                return entity.Id;
            }
        }
    }
}
