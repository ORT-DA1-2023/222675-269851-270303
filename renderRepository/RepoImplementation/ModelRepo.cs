using Render3D.BackEnd;
using Render3D.BackEnd.Materials;
using RenderLogic.RepoInterface;
using renderRepository.entities;

namespace renderRepository.RepoImplementation
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
                return 0;
            }
        }
    }
}
