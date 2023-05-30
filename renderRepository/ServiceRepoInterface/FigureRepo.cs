using Render3D.BackEnd.Figures;
using RenderLogic.RepoService;
using renderRepository.entities;

namespace renderRepository.ServiceRepoInterface
{
    public class FigureRepo : IFigureRepo
    {
        public FigureRepo() { }
        public int AddFigure(Figure figure)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = FigureEntity.FromDomain(figure);

                dbContext.FigureEntities.Add(entity);

                dbContext.SaveChanges();

                figure.Id = entity.Id.ToString();

                return entity.Id;
            }
        }
    }
}
