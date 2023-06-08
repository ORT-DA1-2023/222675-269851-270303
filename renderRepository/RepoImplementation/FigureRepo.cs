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
                int clientId = int.Parse(figure.Client.Id);
                var client = dbContext.ClientEntities.Find(clientId);
                entity.ClientEntity = client;
                dbContext.FigureEntities.Add(entity);
                dbContext.SaveChanges();
                figure.Id = entity.Id.ToString();
            }    
        }

        public void ChangeName(int Id, string newName)
        {
            using (var dbContext = new RenderContext())
            {
                var entity =  dbContext.FigureEntities.Find(Id);
                entity.Name = newName;
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

        public Figure GetByNameAndClient(string name, int clientId)
        {
            using (var dbContext = new RenderContext())
            {
                var figureEntity = dbContext.FigureEntities
                    .Where(f => f.Name == name && f.ClientEntity.Id == clientId);
                return figureEntity.ElementAt(0).ToDomain();
            }
        }
        public List<Figure> GetFiguresOfClient(int clientId)
        {
            using (var dbContext = new RenderContext())
            {
                var FigureEntities = dbContext.FigureEntities
                    .Where(f=> f.ClientEntity.Id == clientId)
                    .GroupBy(f =>f.Name)
                    .Select(f=> f.FirstOrDefault())
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
