using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace renderRepository.entities
{
    public class MaterialEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ClientEntity ClientEntity { get; set; }
        public int Red {get; set;}
        public int Green { get; set;}
        public int Blue { get; set;}  
        public int Blur { get; set;}

        public static MaterialEntity FromDomain(Material material)
        {
            int id;
            try
            {
                id = int.Parse(material.Id);
            }
            catch (ArgumentNullException)
            {
                id = 0;
            }
            MaterialEntity materialEntity = new MaterialEntity
            {
                Id = id,
                Name = material.Name,
                ClientEntity = ClientEntity.FromDomain(material.Client),
                Red = material.Attenuation.Red(),
                Green = material.Attenuation.Green(),
                Blue = material.Attenuation.Blue(),
                Blur = 0
            };
            if (material is MetallicMaterial)
            {
                //missing metallic implementation
            }
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
                    Client = ClientEntity.ToDomain()
                };
            }
            //Metallic Material
            return null;
        }

    }
}
