using Render3D.BackEnd.Materials;
using System;
using System.ComponentModel.DataAnnotations;

namespace renderRepository.entities
{
    public class MaterialEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ClientEntity ClientEntity { get; set; }
        public int Red {get; set;}
        public int Green { get; set;}
        public int Blue { get; set;}  
        public double Blur { get; set;}

        public static MaterialEntity FromDomain(Material material)
        {
            int id;
            double blur;
            try
            {
                id = int.Parse(material.Id);

            }
            catch (ArgumentNullException)
            {
                id = 0;
            }
            try
            {
                blur = ((MetallicMaterial)material).Blur;
            }
            catch
            {
                blur = 0;
            }
            MaterialEntity materialEntity = new MaterialEntity
            {
                Id = id,
                Name = material.Name,
                Red = material.Attenuation.Red(),
                Green = material.Attenuation.Green(),
                Blue = material.Attenuation.Blue(),
                Blur = blur,
            };
            return materialEntity;
        }
        public Material ToDomain() 
        {
            if (Blur == 0)
            {
                return new LambertianMaterial
                {
                    Id = Id.ToString(),
                    Name = Name,
                    Attenuation = new Colour(Red / 255f, Green / 255f, Blue / 255f),
                };
            }
           
            return new MetallicMaterial
            {
                Id = Id.ToString(),
                Name = Name,
                Attenuation = new Colour(Red / 255f, Green / 255f, Blue / 255f),
                Blur = Blur,
            };
        }

    }
}
