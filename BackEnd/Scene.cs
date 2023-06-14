using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using Render3D.BackEnd.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Render3D.BackEnd
{
    public class Scene
    {
        protected string _name;
        private const int _mathPowFirst = 10;
        private const int _mathPowSecond = 38;
        private const double _minDistance = 0.001;
        private const int _maxiumDepth0 = 0;


        public string Id { get; set; }
        public Client Client { get; set; }
        public Camera Camera { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                ValidateName(value);
                _name = value;
            }
        }

        public Scene()
        {
            Camera = new Camera();
            CreationDate = DateTimeProvider.Now;
            LastModificationDate = DateTimeProvider.Now;
            PositionedModels = new List<Model>();
        }
       

        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime? LastRenderizationDate { get; set; }
        public List<Model> PositionedModels { get; set; }
        public Bitmap Preview { get; set; }

        public Colour ShootRay(Ray ray, int depth)
        {
            HitRecord3D hitRecord = null;
            double moduleMax = Math.Pow(_mathPowFirst, _mathPowSecond);
            Model modelSample = new Model();
            bool itWasAHit = false;
            foreach (Model element in PositionedModels)
            {
                if (element.Figure.WasHit(ray, _minDistance, moduleMax))
                {
                    itWasAHit = true;
                    HitRecord3D hit = element.Figure.FigureHitRecord(ray, _minDistance, moduleMax, element.Material.Attenuation, element.Roughness);
                    modelSample = element;
                    hitRecord = hit;
                    moduleMax = hit.Module;
                }
            }
            return ElementAttenuation(depth, hitRecord, modelSample, ray, itWasAHit);
        }

        private Colour ElementAttenuation(int MaxiumDepth, HitRecord3D hitRecord, Model modelSample, Ray ray, bool itWasAHit)
        {
            RandomSingleton random = RandomSingleton.Instance;
            if (itWasAHit)
            {
                return GetAttenuationOfTheFigure(MaxiumDepth, hitRecord, modelSample);
            }
            else
            {
                return GetBlueSky(ray);
            }
        }

        private Colour GetAttenuationOfTheFigure(int MaxiumDepth, HitRecord3D hitRecord, Model modelSample)
        {
            if (MaxiumDepth > _maxiumDepth0)
            {
                Ray newRay = modelSample.Material.ReflectsTheLight(hitRecord);
                if(newRay == null)
                {
                    return new Colour(0, 0, 0);
                }
                
                Colour color = ShootRay(newRay, MaxiumDepth - 1);
                return new Colour(
                   hitRecord.Attenuation.PercentageRed * color.PercentageRed,
                    hitRecord.Attenuation.PercentageGreen * color.PercentageGreen,
                    hitRecord.Attenuation.PercentageBlue * color.PercentageBlue
                    );
            }

            else
            {
                return new Colour(0, 0, 0);
            }
        }

        private Colour GetBlueSky(Ray ray)
        {
            var vectorDirectionUnit = ray.Direction.GetUnit();
            var posY = 0.5 * (vectorDirectionUnit.Y + 1);
            var colorStart = new Colour(1, 1, 1);
            var colorEnd = new Colour(0.5, 0.7, 1.0);
            return colorStart.Multiply(1 - posY).Add(colorEnd.Multiply(posY));
        }


        public void UpdateLastModificationDate()
        {
            LastModificationDate = DateTimeProvider.Now;
        }
        public void UpdateLastRenderizationDate()
        {
            LastRenderizationDate = DateTimeProvider.Now;
        }
        private void ValidateName(string value)
        {
            if (HelperValidator.IsAnEmptyString(value)) throw new BackEndException("Name cant be empty");
            if (HelperValidator.IsTrimmable(value)) throw new BackEndException("Name cant start or end with blank");
        }
    }
}
