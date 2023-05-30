using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renderRepository.entities
{
    public class ModelEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ClientEntity Client { get; set; }
        public FigureEntity FigureEntity { get; set; }
        public MaterialEntity MaterialEntity { get; set; }

        internal static ModelEntity FromDomain(Model model)
        {
            return new ModelEntity
            {
                Name = model.Name,
                Client = ClientEntity.FromDomain(model.Client),
                FigureEntity = FigureEntity.FromDomain(model.Figure),
                MaterialEntity = MaterialEntity.FromDomain(model.Material)
            };
        }
    }
}
