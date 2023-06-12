using Render3D.BackEnd;
using System;

namespace RenderLogic.DataTransferObjects
{
    public class LogDto
    {
        public string Id { get; set; }
        public string ClientName { get; set; }
        public string ClientId { get; set; }
        public int RenderTimeInSeconds { get; set; }
        public DateTime RenderDate { get; set; }
        public string TimeWindowSinceLastRender { get; set; }
        public SceneDto Scene { get; set; }
        public int NumberElementsInScene { get; set; }
        public string Name { get; set; }
    }
}
