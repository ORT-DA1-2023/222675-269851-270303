using Render3D.BackEnd;
using System;
using System.ComponentModel.DataAnnotations;

namespace renderRepository.entities
{
    public class ClientEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public double Aperture { get; set; }
        public double LookFromX { get; set; }
        public double LookFromY { get; set; }
        public double LookFromZ { get; set; }
        public double LookAtX { get; set; }
        public double LookAtY { get; set; }
        public double LookAtZ { get; set; }
        public int Fov { get; set; }

        public static ClientEntity FromDomain(Client client)
        {
            int id;
            try
            {
                id = int.Parse(client.Id);
            }
            catch (ArgumentNullException)
            {
                id = 0;
            }
            return new ClientEntity
            {
                Id=id,
                Name = client.Name,
                Password = client.Password,
                RegisterDate = client.RegisterDate
            };
        }

        public Client ToDomain()
        {
            return new Client
            {
                Id = ""+Id,
                Name = Name,
                Password = Password,
                RegisterDate = RegisterDate,
            };
        }
    }
  
}
