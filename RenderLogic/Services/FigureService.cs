using Render3D.BackEnd.Figures;
using Render3D.BackEnd;
using Render3D.RenderLogic.RepoInterface;
using System;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Services
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
        public void RemoveFigure(int Id)
        {
            _figureRepo.Delete(Id);
        }
        public Figure GetFigure(int Id)
        {
            return _figureRepo.Get(Id);
        }
        public Figure GetFigureByNameAndClient(string figureName, int clientId)
        {
            return _figureRepo.GetByNameAndClient(figureName, clientId);
        }

        public List<Figure> GetFigureOfClient(int clientId)
        {
           return _figureRepo.GetFiguresOfClient(clientId);
        }

        internal void UpdateName(int id, string newName)
        {
            _figureRepo.ChangeName(id, newName);
        }
    }
}
