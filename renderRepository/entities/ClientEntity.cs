using Render3D.BackEnd;
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

        public static ClientEntity FromDomain(Client client)
        {

            return new ClientEntity
            {
                Name = client.Name,
                Password = client.Password,
                RegisterDate = client.RegisterDate
            };
        }

        public static Client ToDomain(ClientEntity clientEntity)
        {
            return new Client
            {
                Name = clientEntity.Name,
                Password = clientEntity.Password,
                RegisterDate = clientEntity.RegisterDate,
            };
        }
    }
  
}
