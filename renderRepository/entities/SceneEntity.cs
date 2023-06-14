using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Lifetime;

namespace renderRepository.entities
{
    public class SceneEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual ClientEntity ClientEntity { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime? LastRenderizationDate { get; set; }
        public virtual ICollection<ModelEntity> ModelEntities { get; set; }
        public byte[] Preview {get; set; }
        public double Aperture { get; set; }
        public double LookFromX { get; set; }
        public double LookFromY { get; set; }
        public double LookFromZ { get; set; }
        public double LookAtX { get; set; }
        public double LookAtY { get; set; }
        public double LookAtZ { get; set; }
        public int Fov { get; set; }
        public static SceneEntity FromDomain(Scene scene)
        {
            int id;
            try
            {
                id = int.Parse(scene.Id);
            }
            catch (ArgumentNullException)
            {
                id = 0;
            }
            byte[] bytes;
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    scene.Preview.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    bytes = stream.ToArray();
                }
            }
            catch
            {
                bytes = null;
            }
            SceneEntity sceneEntity = new SceneEntity
            {
                Id = id,
                Name = scene.Name,
                CreationDate = scene.CreationDate,
                LastModificationDate = scene.LastModificationDate,
                LastRenderizationDate = scene.LastRenderizationDate,
                LookFromX = scene.Camera.LookFrom.X,
                LookFromY = scene.Camera.LookFrom.Y,
                LookFromZ = scene.Camera.LookFrom.Z,
                LookAtX = scene.Camera.LookAt.X,
                LookAtY = scene.Camera.LookAt.Y,
                LookAtZ = scene.Camera.LookAt.Z,
                Fov = scene.Camera.Fov,
                Preview = bytes,
                Aperture =scene.Camera.LensRadius *2
            };
            return sceneEntity;
        }
        public Scene ToDomain()
        {
            Vector3D lookFrom = new Vector3D(LookFromX,LookFromY,LookFromZ);
            Vector3D lookAt = new Vector3D(LookAtX, LookAtY, LookAtZ);
            double lenseRadius;
            Camera camera;
            try
            {
                lenseRadius = Aperture;   
            }
            catch
            {
                lenseRadius =-1;
            }
            if (lenseRadius < 0)
            {
                camera = new Camera(lookFrom, lookAt, Fov);
            }
            else
            {
                camera = new Camera(lookFrom,lookAt,Fov,lenseRadius);
            }
            Bitmap bitmap;
            try
            {
                using (MemoryStream stream = new MemoryStream(Preview))
                {
                    bitmap = new Bitmap(stream);
                }
            }
            catch
            {
                bitmap = null;
            }
            return new Scene
            {
                Id = Id.ToString(),
                Name = Name,
                Camera = camera,
                CreationDate = CreationDate,
                LastModificationDate = LastModificationDate,
                LastRenderizationDate = LastRenderizationDate,
                Preview = bitmap,
                
            };
        }
    }
}
