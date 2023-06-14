using Render3D.BackEnd.Logs;
using Render3D.RenderLogic.RepoInterface;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Services
{
    public class LogService
    {
        private readonly ILogRepo _logRepo;

        public LogService(ILogRepo logRepo)
        {
            _logRepo = logRepo;
        }
        public void AddLog(Log log)
        {
            _logRepo.Add(log);
        }
        public List<Log> GetLogs()
        {
            return _logRepo.GetLogs();
        }

        public void DeleteLog(Log log)
        {
            _logRepo.DeleteLog(log);
        }
    }
}
