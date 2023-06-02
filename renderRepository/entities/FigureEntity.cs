using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ClientEntity ClientEntity { get; set; }
        public double Radius { get; set; }

        public static FigureEntity FromDomain(Figure figure)
        {
            int id;
            try
            {
                id = int.Parse(figure.Id);
            }
            catch (ArgumentNullException)
            {
                id = 0;
            }
            FigureEntity figureEntity = new FigureEntity
            {
                Id = id,
                Name = figure.Name,
                Radius = ((Sphere)figure).Radius,
                ClientEntity = ClientEntity.FromDomain(figure.Client)
            };
            return figureEntity;
        }
        public Figure ToDomain()
        {
            return new Sphere
            {
                Id = ""+Id,
                Name = Name,
                Client = ClientEntity.ToDomain(),
                Radius = Radius
            };
        }
    }
}