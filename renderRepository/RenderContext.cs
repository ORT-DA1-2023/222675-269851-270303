using renderRepository.entities;
using System.Data.Entity;

namespace renderRepository
{
    public class RenderContext : DbContext
    {
        public RenderContext() :base ("name=RenderDBConnectionString")
        {

        }
        public DbSet<ClientEntity> ClientEntities { get; set; }
        public DbSet<FigureEntity> FigureEntities { get; set; }
        public DbSet<MaterialEntity> MaterialEntities { get; set; }
        public DbSet<ModelEntity> ModelEntities { get; set; }
        public DbSet<SceneEntity> SceneEntities { get; set; }
    }
}
