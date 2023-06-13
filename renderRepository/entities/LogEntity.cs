using System;
using System.ComponentModel.DataAnnotations;

namespace renderRepository.entities
{
    public class LogEntity
    {
        [Key]
        public int Id { get; set; }
        public ClientEntity Client { get; set; }
        public int RenderTimeInSeconds { get; set; }
        public DateTime RenderDate { get; set; }
        public string TimeWindowSinceLastRender { get; set; }
        public SceneEntity Scene { get; set; }
        public int NumberElementsInScene { get; set; }
        public string Name { get; private set; }
    }
}
