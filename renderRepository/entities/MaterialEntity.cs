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
        [Key]
        [Column(Order = 0)]
        public string Name { get; set; }
        [Key]
        [Column(Order = 1)]
        public ClientEntity ClientEntity { get; set; }
        public int Red {get; set;}
        public int Green { get; set;}
        public int Blue { get; set;}  
        public int Blur { get; set;}
    }
}
