using renderRepository.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
