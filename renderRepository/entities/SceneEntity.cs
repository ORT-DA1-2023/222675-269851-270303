using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace renderRepository.entities
{
    public class SceneEntity
    {
        [Key]
        public int Id { get; set; }
        public ClientEntity ClientEntity { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime? LastRenderizationDate { get; set; }
        public ICollection<ModelEntity> ModelEntities { get; set; }
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
            SceneEntity sceneEntity = new SceneEntity
            {
                Id = id,
                Name = scene.Name,
                ClientEntity =ClientEntity.FromDomain(scene.Client),
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
            };
            return sceneEntity;
        }
        public Scene ToDomain()
        {
            Vector3D lookFrom = new Vector3D(LookFromX,LookFromY,LookFromZ);
            Vector3D lookAt = new Vector3D(LookAtX, LookAtY, LookAtZ);
            Camera camera = new Camera(lookFrom,lookAt, Fov);
            return new Scene
            {
                Id = Id.ToString(),
                Name = Name,
                Camera = camera,
                CreationDate = CreationDate,
                LastModificationDate = LastModificationDate,
                LastRenderizationDate = LastRenderizationDate,
                Client = ClientEntity.ToDomain()
            };
        }
    }
}
