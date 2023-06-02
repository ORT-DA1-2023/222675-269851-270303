using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renderRepository.entities
{
    public class ModelEntity
    {
        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ClientId { get; set; }
        public ClientEntity Client { get; set; }
        public FigureEntity FigureEntity { get; set; }
        public MaterialEntity MaterialEntity { get; set; }
        //public Bitmap Preview {  get; set; }

        public static ModelEntity FromDomain(Model model)
        {
            ModelEntity modelEntity = new ModelEntity
            {
                Name = model.Name,
                Client = ClientEntity.FromDomain(model.Client),
                FigureEntity = FigureEntity.FromDomain(model.Figure),
                MaterialEntity = MaterialEntity.FromDomain(model.Material),
                //Preview = model.Preview
            };
            return modelEntity;
        }

        public Model ToDomain()
        {
            Model model = new Model
            {
                Name = Name,
                Client = Client.ToDomain(),
                Figure = FigureEntity.ToDomain(),
                Material = MaterialEntity.ToDomain(),
                //Preview = Preview
            };
            return model;
        }
    }
}
