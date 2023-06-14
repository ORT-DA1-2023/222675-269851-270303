using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Logs;
using Render3D.RenderLogic.DataTransferObjects;
using System.Collections.Generic;

namespace Render3D.RenderLogic.RepoInterface
{
    public interface ILogRepo
    {
        void Add(Log log);
        void DeleteLog(Log log);
        List<Log> GetLogs();

    }
}
