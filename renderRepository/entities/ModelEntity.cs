using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
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
        public ClientEntity ClientEntity { get; set; }
        public FigureEntity FigureEntity { get; set; }
        public MaterialEntity MaterialEntity { get; set; }
        public byte[] Preview {  get; set; }

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
            byte[] bytes = null;
            using (MemoryStream stream = new MemoryStream())
            {
                model.Preview.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                bytes =stream.ToArray();
            }
            ModelEntity modelEntity = new ModelEntity
            {
                Id = id,
                Name = model.Name,
                ClientEntity = ClientEntity.FromDomain(model.Client),
                FigureEntity = FigureEntity.FromDomain(model.Figure),
                MaterialEntity = MaterialEntity.FromDomain(model.Material),
                Preview = bytes,
                
            };
            return modelEntity;
        }

        public Model ToDomain()
        {
            Bitmap bitmap = null;
            using (MemoryStream stream = new MemoryStream(Preview))
            {
                bitmap= new Bitmap(stream);
            }
            Model model = new Model
            {
                Id = Id.ToString(),
                Name = Name,
                Client = ClientEntity.ToDomain(),
                Figure = FigureEntity.ToDomain(),
                Material = MaterialEntity.ToDomain(),
                Preview = bitmap
            };
            return model;
        }
    }
}
