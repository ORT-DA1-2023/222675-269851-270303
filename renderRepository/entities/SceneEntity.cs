using Render3D.BackEnd;
using Render3D.BackEnd.Figures;
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
        public ClientEntity Client { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime? LastRenderizationDate { get; set; }
        public virtual ICollection<ModelEntity> ModelEntities { get; set; }
        public byte[] Preview {get; set; }
        public double Aperture { get; set; }
        public string LookFromString { get; set; }
        public string LookAtString { get; set; }
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
                Client =ClientEntity.FromDomain(scene.Client),
                CreationDate = scene.CreationDate,
                LastModificationDate = scene.LastModificationDate,
                LastRenderizationDate = scene.LastRenderizationDate,
                LookFromString = scene.Camera.LookFrom.ToString(),
                LookAtString = scene.Camera.LookAt.ToString(),
                Fov = scene.Camera.Fov
                
            };
            return sceneEntity;
        }
        public Scene ToDomain()
        {
            Camera camera = new Camera(Vector3D.FromString(LookFromString), Vector3D.FromString(LookAtString), new Vector3D(1, 1, 1), Fov,1);
            return new Scene
            {
                Id = Id.ToString(),
                Name = Name,
                Camera = camera,
                CreationDate = CreationDate,
                LastModificationDate = LastModificationDate,
                LastRenderizationDate = LastRenderizationDate,
                Client = Client.ToDomain()
            };
        }
    }
}
