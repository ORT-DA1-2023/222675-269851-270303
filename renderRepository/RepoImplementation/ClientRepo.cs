using Render3D.BackEnd;
using Render3D.BackEnd.Materials;
using Render3D.RenderLogic.RepoInterface;
using renderRepository.entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace renderRepository.RepoImplementation
{
    public class ClientRepo : IClientRepo
    {
        public ClientRepo() { }
        public void Add(Client client)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = ClientEntity.FromDomain(client);

                dbContext.ClientEntities.Add(entity);

                dbContext.SaveChanges();
                client.Id = entity.Id.ToString();
            }
        }

        public Client Get(int id)
        {
            using (var dbContext = new RenderContext())
            {
                try
                {
                    ClientEntity clientEntity = dbContext.ClientEntities.Find(id);
                    return clientEntity.ToDomain();
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
        public Client GetClientByName(string name)
        {    
                try
                {
                using (var dbContext = new RenderContext())
                {
                    var ClientEntites = dbContext.ClientEntities
                        .Where(f => f.Name == name)
                        .ToList();
                    List<Client> clients = new List<Client>();
                    foreach (var m in ClientEntites)
                    {
                        clients.Add(m.ToDomain());
                    }
                    return clients[0];
                }
            }
                catch (Exception e)
                {
                    throw e;
                }
        }

        public void Remove(string name)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = dbContext.ClientEntities
                    .Where(c => c.Name== name)
                    .FirstOrDefault();
                dbContext.ClientEntities.Remove(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
