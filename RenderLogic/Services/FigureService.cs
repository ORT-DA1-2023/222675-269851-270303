using Render3D.BackEnd.Figures;
using Render3D.BackEnd;
using RenderLogic.RepoInterface;
using System;
using System.Collections.Generic;

namespace RenderLogic.Services
{
    public class FigureService
    {
        private readonly IFigureRepo _figureRepo;

        public FigureService(IFigureRepo figureRepo)
        {
            _figureRepo = figureRepo;
        }

        public void AddFigure(Figure figure)
        {
            _figureRepo.Add(figure);
        }
        public void RemoveFigure(Figure figure)
        {
            _figureRepo.Delete(int.Parse(figure.Id));
        }
        public Figure GetFigure(int Id)
        {
            return _figureRepo.Get(Id);
        }
        public Figure GetFigureByNameAndClient(string figureName, Client client)
        {
            return _figureRepo.GetByNameAndClient(figureName, client);
        }

        public List<Figure> GetFigureOfClient(Client client)
        {
           return _figureRepo.GetFiguresOfClient(client);
        }

        internal void UpdateName(string id, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
