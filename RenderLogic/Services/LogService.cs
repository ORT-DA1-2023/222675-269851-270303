using Render3D.BackEnd;
using RenderLogic.RepoInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderLogic.Services
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

    }
}
