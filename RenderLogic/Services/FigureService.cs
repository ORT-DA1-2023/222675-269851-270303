using Render3D.BackEnd.Figures;
using Render3D.BackEnd;
using RenderLogic.RepoInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Figure GetFigure(string name, string clientName)
        {
            return _figureRepo.Get(name, clientName);
        }
        public void GetFigureByNameAndClient(Client client, string figureName)
        {

        }
    }
}
