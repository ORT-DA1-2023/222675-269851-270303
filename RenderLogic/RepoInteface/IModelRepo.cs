using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderLogic.RepoInterface
{
    public interface IModelRepo
    {
        int AddModel(Model model);
    }
}
