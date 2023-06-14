using Render3D.BackEnd.Logs;
using System;
using System.ComponentModel.DataAnnotations;

namespace renderRepository.entities
{
    public class LogEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual ClientEntity ClientEntity { get; set; }
        public int RenderTimeInSeconds { get; set; }
        public DateTime RenderDate { get; set; }
        public string TimeWindowSinceLastRender { get; set; }
        public int NumberElements { get; set; }
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
                NumberElements = log.NumberElements,
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
                NumberElements = NumberElements,
                TimeWindowSinceLastRender = TimeWindowSinceLastRender,
            };
        }
    }
}
