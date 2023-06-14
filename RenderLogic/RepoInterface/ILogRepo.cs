using Render3D.BackEnd.Logs;
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
