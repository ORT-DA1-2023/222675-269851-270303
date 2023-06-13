using Render3D.BackEnd.Figures;
using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace renderRepository.entities
{
    public class FigureEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ClientEntity ClientEntity { get; set; }
        public double Radius { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

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
                X= figure.Position.X,
                Y= figure.Position.Y,
                Z = figure.Position.Z
            };
            return figureEntity;
        }
        public Figure ToDomain()
        {
            Vector3D position = new Vector3D(X, Y, Z);
            return new Sphere
            {
                Id = ""+Id,
                Name = Name,
                Radius = Radius,
                Position= position
            };
        }
    }
}