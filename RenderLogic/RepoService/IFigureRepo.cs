using Render3D.BackEnd.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderLogic.RepoService
{
    public interface IFigureRepo
    {
        int AddFigure(Figure figure);
    }
}
