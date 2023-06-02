using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderLogic.RepoInterface
{
    public interface IMaterialRepo
    {
        int AddMaterial(Material material);
    }
}
