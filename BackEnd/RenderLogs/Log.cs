using Render3D.BackEnd.Utilities;
using System;

namespace Render3D.BackEnd.Logs
{
    public class Log
    {
        private const int _secondsPerMinute = 60;
        private const int _secondsPerHour = 3600;
        private const int _secondsPerDay = 86400;

        public Client Client { get; set; }
        public int RenderTimeInSeconds { get; set; }
        public DateTime RenderDate { get; set; }
        public string TimeWindowSinceLastRender { get; set; }
        public Scene Scene { get; set; }
        public int NumberElementsInScene { get; set; }
        public string Name { get; private set; }

        public Log(Scene scene, DateTime startedRenderDate)
        {
            Name = scene.Name;

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
            Name = $"preview - {scene.Name}";
            Client = scene.Client;
            RenderDate = DateTimeProvider.Now;
            RenderTimeInSeconds = 0;
            Scene = scene;
            NumberElementsInScene = scene.PositionedModels.Count;
            TimeWindowSinceLastRender = null;
        }

        private string TimeWindowBetweenTwoRenders(DateTime? lastRenderDate, DateTime currentRenderDate)
        {
            if (lastRenderDate == null) return null;

            int secondsDifference = SecondsBetweenDates((DateTime)lastRenderDate, currentRenderDate);

            if (secondsDifference == 0)
            {
                return "0 second(s)";
            }
            else if (secondsDifference < _secondsPerMinute)
            {
                return $"{secondsDifference} second(s)";
            }
            else if (secondsDifference < _secondsPerHour)
            {
                int minutes = secondsDifference / _secondsPerMinute;
                return $"{minutes} minute(s)";
            }
            else if (secondsDifference < _secondsPerDay)
            {
                int hours = secondsDifference / _secondsPerHour;
                return $"{hours} hour(s)";
            }
            else
            {
                int days = secondsDifference / _secondsPerDay;
                return $"{days} day(s)";
            }

        }
        private int SecondsBetweenDates(DateTime start, DateTime end)
        {
            TimeSpan timeDifference = (TimeSpan)(end - start);

            return (int)timeDifference.TotalSeconds;
        }

    }
}
