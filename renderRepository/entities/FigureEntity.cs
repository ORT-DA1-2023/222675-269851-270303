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
        public int Id { get; set; }
        public string Name { get; set; }
        public ClientEntity Client { get; set; }
        public double Radius { get; set; }

        internal static FigureEntity FromDomain(Figure figure)
        {
            return new FigureEntity
            {
                Name = figure.Name,
                Radius = ((Sphere)figure).Radius,
                Client = ClientEntity.FromDomain(figure.Client)
            };
        }
    }
}