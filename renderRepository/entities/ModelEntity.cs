using Render3D.BackEnd;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;

namespace renderRepository.entities
{
    public class ModelEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ClientEntity ClientEntity { get; set; }
        public virtual FigureEntity FigureEntity { get; set; }
        public virtual MaterialEntity MaterialEntity { get; set; }
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
            byte[] bytes;
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    model.Preview.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    bytes = stream.ToArray();
                }
            }
            catch
            {
                bytes = null;
            }
            ModelEntity modelEntity = new ModelEntity
            {
                Id = id,
                Name = model.Name,
                Preview = bytes,
                
            };
            return modelEntity;
        }

        public Model ToDomain()
        {
            Bitmap bitmap;
            try
            {
                using (MemoryStream stream = new MemoryStream(Preview))
                {
                    bitmap = new Bitmap(stream);
                }
            }
            catch
            {
                bitmap = null;
            }
           
            Model model = new Model
            {
                Id = Id.ToString(),
                Name = Name,
                Preview = bitmap
            };
            return model;
        }
    }
}
