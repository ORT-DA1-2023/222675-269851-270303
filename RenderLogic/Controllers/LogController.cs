using Render3D.BackEnd;
using Render3D.RenderLogic.DataTransferObjects;
using Render3D.RenderLogic.Services;
using System.Collections.Generic;

namespace Render3D.RenderLogic.Controllers
{
    public class LogController
    {
        public static LogController logController;
        public ClientController ClientController = ClientController.GetInstance();
        public LogService LogService { get; set; }
        public List<Log> LogsCreated;
        private readonly int _secondsPerMinute = 60;

        public static LogController GetInstance()
        {
            if (logController == null)
            {
                logController = new LogController();
            }
            return logController;
        }
        public void AddLogFromScene(Scene scene, DateTime starts)
        {
            Log log = new Log(scene,starts);
            log.Client = ClientController.Client;
            LogService.AddLog(log);
        }
        public void AddLogFromPreview(string modelName)
        {
            Log log = new Log(modelName);
            log.Client = ClientController.Client;
            LogService.AddLog(log);
        }

        public List<LogDto> GetLogs()
        {
            List<LogDto > logsDtoList = new List<LogDto>();
           LogsCreated = LogService.GetLogs();
            foreach (Log log in LogsCreated)
            {
                LogDto logDto = new LogDto()
                {
                    Id = log.Id,
                    Name = log.Name,
                    ClientId = log.Client.Id,
                    ClientName = log.Client.Name,
                    NumberElements = log.NumberElements,
                    RenderDate = log.RenderDate,
                    RenderTimeInSeconds = log.RenderTimeInSeconds,
                    TimeWindowSinceLastRender = log.TimeWindowSinceLastRender,
                };
                logsDtoList.Add(logDto);
            }
            return logsDtoList;
        }
        public int GetAverageRenderTimeInSeconds()
        {
            int totalSeconds = 0;
            int totalNumberLogs = LogsCreated.Count;

            foreach (var log in LogsCreated)
            {
                totalSeconds += log.RenderTimeInSeconds;
            }
            return totalSeconds / totalNumberLogs;
        }

        public int GetAverageRenderTimeInMinutes()
        {
            return GetAverageRenderTimeInSeconds() / _secondsPerMinute;
        }

        public string ClientWithMostRenderTime()
        {
            List<Client> clientList = GetClientListWhoRendered();
            int maxTime = 0;
            string maxClient = null;

            foreach (Client cl in clientList)
            {
                int t = RenderTimeInSecondsOfClient(cl);
                if (t > maxTime)
                {
                    maxTime = t;
                    maxClient = cl.Name;
                }
            }
            return maxClient + " : " + maxTime;
        }

        public int RenderTimeInSecondsOfClient(Client client)
        {
            int timeInSeconds = 0;
            foreach (Log l in LogsCreated)
            {
                if (l.Client.Equals(client))
                {
                    timeInSeconds += l.RenderTimeInSeconds;
                }
            }
            return timeInSeconds;
        }

        private List<Client> GetClientListWhoRendered()
        {
            List<Client> clientList = new List<Client>();
            foreach (var log in LogsCreated)
            {
                if (!clientList.Contains(log.Client))
                {
                    clientList.Add(log.Client);
                }
            }
            return clientList;
        }
    }
}
