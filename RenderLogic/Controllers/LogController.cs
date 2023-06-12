using Render3D.BackEnd;
using RenderLogic.DataTransferObjects;
using RenderLogic.Services;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Controllers
{
    public class LogController
    {
        public static LogController logController;
        public ClientController ClientController = ClientController.GetInstance();
        public LogService LogService { get; set; }

        public static LogController GetInstance()
        {
            if (logController == null)
            {
                logController = new LogController();
            }
            return logController;
        }
        public void AddLogFromScene(LogDto logDto)
        {
            
        }
        public void AddLogFromPreview(LogDto logDto)
        {
            

        }

        public List<LogDto> GetLogs()
        {
            List<LogDto > logsDtoList = new List<LogDto>();
            List<Log> logs= LogService.GetLogs();
            foreach (Log log in logs)
            {
                LogDto logDto = new LogDto()
                {
                    Id = log.Id,
                    Name = log.Name,
                    ClientId = log.Client.Id,
                    ClientName = log.Client.Name,
                    NumberElementsInScene = log.NumberElementsInScene,
                    RenderDate = log.RenderDate,
                    RenderTimeInSeconds = log.RenderTimeInSeconds,
                    SceneId = log.Scene.Id,
                    SceneName = log.Scene.Name,
                    NumberOfElements = log.Scene.PositionedModels.Count,
                    TimeWindowSinceLastRender = log.TimeWindowSinceLastRender,

                };
                logsDtoList.Add(logDto);
            }
            return logsDtoList;
        }
    }
}
