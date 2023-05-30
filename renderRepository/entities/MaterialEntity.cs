using Render3D.BackEnd.Figures;
using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renderRepository.entities
{
    public class MaterialEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClientEntity Client { get; set; }
        public int Red {get; set;}
        public int Green { get; set;}
        public int Blue { get; set;}  
        public int Blur { get; set;}

        internal static MaterialEntity FromDomain(Material material)
        {
            MaterialEntity materialEntity = new MaterialEntity {
                Name = material.Name,
                Client = ClientEntity.FromDomain(material.Client),
                Red = material.Attenuation.Red(),
                Green=material.Attenuation.Green(),
                Blue=material.Attenuation.Blue()
                

            };
            if(material is MetallicMaterial)
            {
              //missing metallic implementation
            }
            return materialEntity;
        }
    }
}
