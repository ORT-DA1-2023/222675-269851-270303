using Render3D.BackEnd;
using RenderLogic.RepoService;
using renderRepository.entities;

namespace renderRepository.ServiceRepoInterface
{
    public class ClientRepo : IClientRepo
    {
        public ClientRepo() { }
        public void AddClient(Client client)
        {
            using (var dbContext = new RenderContext())
            {
                var entity = ClientEntity.FromDomain(client);

                dbContext.ClientEntities.Add(entity);

                dbContext.SaveChanges();
            }
        }
    }
}
