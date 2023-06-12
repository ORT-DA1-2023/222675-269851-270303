using Render3D.BackEnd;
using RenderLogic.RepoInterface;
using renderRepository.entities;
using System;
using System.Collections.Generic;

namespace renderRepository.RepoImplementation
{
    public class LogRepo : ILogRepo
    {
        public void Add(Log log)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = LogEntity.FromDomain(log);

                dbContext.ClientEntities.Add(entity);

                dbContext.SaveChanges();
                client.Id = entity.Id.ToString();
            }
        }

        public List<Log> GetLogs()
        {
            throw new NotImplementedException();
        }
    }
}
