using Render3D.BackEnd;
using RenderLogic.RepoInterface;
using renderRepository.entities;
using System;

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
            using (var dbContext = new RenderContext())
            {
                try
                {
                    ClientEntity clientEntity = dbContext.ClientEntities.Find(name);
                    return clientEntity.ToDomain();
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
    }
}
