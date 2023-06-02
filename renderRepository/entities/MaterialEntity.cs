using Render3D.BackEnd.Materials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace renderRepository.entities
{
    public class MaterialEntity
    {
        [Key]
        [Column(Order =1)]
        public int Id { get; set; }
        public string Name { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ClientId { get; set; }
        public ClientEntity Client { get; set; }
        public int Red {get; set;}
        public int Green { get; set;}
        public int Blue { get; set;}  
        public int Blur { get; set;}

        public static MaterialEntity FromDomain(Material material)
        {
            MaterialEntity materialEntity = new MaterialEntity
            {
                Name = material.Name,
                Client = ClientEntity.FromDomain(material.Client),
                Red = material.Attenuation.Red(),
                Green = material.Attenuation.Green(),
                Blue = material.Attenuation.Blue()


            };
            if (material is MetallicMaterial)
            {
                //missing metallic implementation
            }
            return materialEntity;
        }
        public Material ToDomain() 
        {
            Material material = null;
            return material;
        }

    }
}
