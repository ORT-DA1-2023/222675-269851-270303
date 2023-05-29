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
        [Key]
        [Column(Order = 0)]
        public string Name { get; set; }
        [Key]
        [Column(Order = 1)]
        public ClientEntity ClientEntity { get; set; }
        public FigureEntity FigureEntity { get; set; }
        public MaterialEntity MaterialEntity { get; set; }

    }
}
