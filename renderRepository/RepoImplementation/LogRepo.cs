using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using Render3D.RenderLogic.RepoInterface;
using renderRepository.entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace renderRepository.RepoImplementation
{
    public class LogRepo : ILogRepo
    {
        public void Add(Log log)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = LogEntity.FromDomain(log);
                int clientId = int.Parse(log.Client.Id);
                var client = dbContext.ClientEntities.Find(clientId);
                entity.ClientEntity = client;
                dbContext.LogEntities.Add(entity);
                dbContext.SaveChanges();
                log.Id = entity.Id.ToString();
            }
        }

        public List<Log> GetLogs()
        {
            using (var dbContext = new RenderContext())
            {
                var logEntities = dbContext.LogEntities
                    .ToList();
                List<Log> logs = new List<Log>();
                foreach (var logE in logEntities)
                {
                    Client client = logE.ClientEntity.ToDomain();
                    Log log = logE.ToDomain();
                    log.Client = client;
                    logs.Add(log);
                }
                return logs;
            }
        }
    }
}
