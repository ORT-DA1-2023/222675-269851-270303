using Render3D.BackEnd.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class Log
    {
        private const int secondsPerMinute = 60;
        private const int secondsPerHour = 3600;
        private const int secondsPerDay = 86400;

        public Client Client { get;set; }
        public int RenderTimeInSeconds { get; set; }
        public DateTime RenderDate { get; set; }
        public string TimeWindowSinceLastRender { get; set; }
        public Scene Scene { get; set; }
        public int NumberElementsInScene { get; set; }

        public Log(Scene scene, DateTime startedRenderDate)
        {
            Client = scene.Client;
            RenderDate = startedRenderDate;

            TimeSpan difference = DateTimeProvider.Now - RenderDate;
            RenderTimeInSeconds = (int)difference.TotalSeconds;

            Scene = scene;
            NumberElementsInScene = scene.PositionedModels.Count;

            TimeWindowSinceLastRender = TimeWindowBetweenTwoRenders(scene.LastRenderizationDate, startedRenderDate);
        }

        public Log(Scene scene)
        {
            Client = scene.Client;
            RenderDate = DateTimeProvider.Now;
            RenderTimeInSeconds = 0;
            Scene = scene;
            NumberElementsInScene = scene.PositionedModels.Count;
            TimeWindowSinceLastRender = "First render";
        }



        private string TimeWindowBetweenTwoRenders(DateTime? lastRenderDate , DateTime currentRenderDate)
        {
            return "First render";
        }
    }
}
