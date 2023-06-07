using Render3D.BackEnd;
using Render3D.BackEnd.Materials;
using RenderLogic.RepoInterface;
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
    }
}
