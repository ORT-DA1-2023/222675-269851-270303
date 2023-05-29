using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renderRepository.entities
{
    public class FigureEntity
    {
        [Key]
        [Column(Order = 0)]
        public string Name { get; set; }
        [Key]
        [Column(Order = 1)]
        public ClientEntity Client { get; set; }
        public int Radius { get; set; }

    }
}