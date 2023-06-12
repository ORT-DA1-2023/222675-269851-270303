using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using System.Collections.Generic;

namespace Render3D.RenderLogic.RepoInterface
{
    public interface ILogRepo
    {
        void Add(Log log);
        List<Log> GetLogs();

    }
}
