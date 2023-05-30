using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderLogic.RepoService
{
    public interface IClientRepo
    {
        void AddClient(Client client);
    }
}
