using Render3D.BackEnd.GraphicMotorUtility;
using Render3D.BackEnd.Materials;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;

namespace Render3D.BackEnd
{
    public class Scene
    {
        private String _name;

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

        public Vector3D ShootRay(Ray ray, int depth, Random random)
        {
            HitRecord3D hitRecord = null;
            double moduleMax = Math.Pow(10, 38);
            Model modelSample = new Model();
            foreach (Model element in PositionedModels)
            {
                HitRecord3D hit = element.Figure.FigureHitRecord(ray, 0.001, moduleMax, element.Material.Attenuation);
                if (hit != null)
                {
                    modelSample = element;
                    hitRecord = hit;
                    moduleMax = hit.Module;
                }
            }
            return AttenuationOfBlueSkyOrFigure(depth, hitRecord, random, modelSample, ray);
        }

        private Vector3D AttenuationOfBlueSkyOrFigure(int MaxiumDepth, HitRecord3D hitRecord, Random random, Model modelSample, Ray ray)
        {
            if (hitRecord != null)
            {
                return GetAttenuationOfTheFigure(MaxiumDepth, hitRecord, random, modelSample);
            }
            else
            {
                return GetBlueSky(ray);
            }
        }

        private Vector3D GetAttenuationOfTheFigure(int MaxiumDepth, HitRecord3D hitRecord, Random random, Model modelSample)
        {
            if (MaxiumDepth > 0)
            {
                Ray newRay = modelSample.Material.ReflectsTheLight(hitRecord, random);
                Vector3D color = ShootRay(newRay, MaxiumDepth - 1, random);
                return new Vector3D(hitRecord.Attenuation.X * color.X, hitRecord.Attenuation.Y * color.Y, hitRecord.Attenuation.Z * color.Z);
            }
            else
            {
                return new Vector3D(0, 0, 0);
            }
        }

        private Vector3D GetBlueSky(Ray ray)
        {
            var vectorDirectionUnit = ray.Direction.GetUnit();
            var posY = 0.5 * (vectorDirectionUnit.Y + 1);
            var colorStart = new Vector3D(1, 1, 1);
            var colorEnd = new Vector3D(0.5, 0.7, 1.0);
            return colorStart.Multiply((1 - posY)).Add(colorEnd.Multiply(posY));
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
