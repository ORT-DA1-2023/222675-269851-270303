using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
