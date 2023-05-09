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

        public Scene()
        {
            Camera = new Camera();
            RegisterDate = DateTimeProvider.Now;
            LastModificationDate = DateTimeProvider.Now;
            PositionedModels = new List<Model>();
        }


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

        public DateTime RegisterDate { get; }
        public DateTime LastModificationDate { get; private set; }
        public DateTime? LastRenderizationDate { get; set; }
        public List<Model> PositionedModels { get; set; }
        public Bitmap Preview { get; set; }

        public Colour ShootRay(Ray ray, int depth, Random random)
        {
            HitRecord3D hitRecord = null;
            double moduleMax = Math.Pow(10, 38);
            Model modelSample = new Model();
            bool itWasAHit = false;
            foreach (Model element in PositionedModels)
            {
                if (element.Figure.WasHit(ray, 0.001, moduleMax))
                {
                    itWasAHit = true;
                    HitRecord3D hit = element.Figure.FigureHitRecord(ray, 0.001, moduleMax, element.Material.Attenuation);
                    modelSample = element;
                    hitRecord = hit;
                    moduleMax = hit.Module;
                }
            }
            return ElementAttenuation(depth, hitRecord, random, modelSample, ray, itWasAHit);
        }

        private Colour ElementAttenuation(int MaxiumDepth, HitRecord3D hitRecord, Random random, Model modelSample, Ray ray, bool itWasAHit)
        {
            if (itWasAHit)
            {
                return GetAttenuationOfTheFigure(MaxiumDepth, hitRecord, random, modelSample);
            }
            else
            {
                return GetBlueSky(ray);
            }
        }

        private Colour GetAttenuationOfTheFigure(int MaxiumDepth, HitRecord3D hitRecord, Random random, Model modelSample)
        {
            if (MaxiumDepth > 0)
            {
                Ray newRay = modelSample.Material.ReflectsTheLight(hitRecord, random);
                Colour color = ShootRay(newRay, MaxiumDepth - 1, random);
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
