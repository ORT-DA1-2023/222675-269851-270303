using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public ClientEntity Client { get; set; }
        public FigureEntity FigureEntity { get; set; }
        public MaterialEntity MaterialEntity { get; set; }
        public Bitmap Preview {  get; set; }

        public static ModelEntity FromDomain(Model model)
        {
            int id;
            try
            {
                id = int.Parse(model.Id);
            }
            catch (ArgumentNullException)
            {
                id = 0;
            }
            ModelEntity modelEntity = new ModelEntity
            { 
                Id =id,
                Name = model.Name,
                Client = ClientEntity.FromDomain(model.Client),
                FigureEntity = FigureEntity.FromDomain(model.Figure),
                MaterialEntity = MaterialEntity.FromDomain(model.Material),
                Preview = model.Preview
            };
            return modelEntity;
        }

        public Model ToDomain()
        {
            Model model = new Model
            {
                Id = Id.ToString(),
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
