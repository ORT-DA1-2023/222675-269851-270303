using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using RenderLogic.RepoInterface;
using renderRepository.entities;
using System.Collections.Generic;
using System.Linq;
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
        public void Delete(int Id)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.FigureEntities.Find(Id);
                dbContext.FigureEntities.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public Figure Get(int Id)
        {
            using (var dbContext = new RenderContext())
            {
                FigureEntity figureEntity = dbContext.FigureEntities.Find(Id);
                return figureEntity.ToDomain();
            }
        }

        public Figure GetByNameAndClient(string name, Client client)
        {
            using (var dbContext = new RenderContext())
            {
                var figureEntity = dbContext.FigureEntities
                    .Where(f => f.Name == name && f.ClientEntity == ClientEntity.FromDomain(client));
                return figureEntity.ElementAt(0).ToDomain();
            }
        }
        public List<Figure> GetFiguresOfClient(Client client)
        {
            using (var dbContext = new RenderContext())
            {
                var FigureEntities = dbContext.FigureEntities
                    .Where(f=> f.ClientEntity == ClientEntity.FromDomain(client))
                    .ToList();
                List<Figure> clientFigures = new List<Figure>();
                foreach (var f in FigureEntities) 
                {
                    clientFigures.Add(f.ToDomain());
                }
                return clientFigures;
            }
        }

    }
}
