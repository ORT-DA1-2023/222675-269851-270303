using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renderRepository.entities
{
    public class ClientEntity
    {
        [Key]
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
