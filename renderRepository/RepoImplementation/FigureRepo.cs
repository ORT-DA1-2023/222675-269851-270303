using Render3D.BackEnd.Figures;
using RenderLogic.RepoInterface;
using renderRepository.entities;
using System.Xml.Linq;

namespace renderRepository.RepoImplementation
{
    public class FigureRepo : IFigureRepo
    {
        public FigureRepo() { }

        public void Add(Figure figure)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = FigureEntity.FromDomain(figure);

                dbContext.FigureEntities.Add(entity);

                dbContext.SaveChanges();
            }    
        }
        public void Delete(string name, string clientName)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(string name, string clientName)
        {
            throw new System.NotImplementedException();
        }

        public Figure Get(string name, string clientName)
        {
            using (var dbContext = new RenderContext())
            {
                FigureEntity figureEntity = dbContext.FigureEntities.Find(name,clientName);
                return figureEntity.ToDomain();
            }
        }
    }
}
