using Render3D.BackEnd;
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
        public string Name { get; set; }

        public static LogEntity FromDomain(Log log)
        {
            int id;
            try
            {
                id = int.Parse(log.Id);
            }
            catch (ArgumentNullException)
            {
                id = 0;
            }
            return new LogEntity
            {
                Id = id,
                Name = log.Name,
                RenderDate = log.RenderDate,
                RenderTimeInSeconds = log.RenderTimeInSeconds,
                NumberElementsInScene = log.NumberElementsInScene,
                TimeWindowSinceLastRender = log.TimeWindowSinceLastRender,
            };
        }

        public Log ToDomain()
        {
            return new Log
            {
                Id = Id.ToString(),
                Name = Name,
                RenderDate = RenderDate,
                RenderTimeInSeconds = RenderTimeInSeconds,
                NumberElementsInScene = NumberElementsInScene,
                TimeWindowSinceLastRender = TimeWindowSinceLastRender,
            };
        }
    }
}
