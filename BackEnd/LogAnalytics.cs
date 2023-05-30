using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class LogAnalytics
    {
        private readonly int _secondsPerMinute = 60;

        public List<Log> LogsCreated { get; set; }

        public LogAnalytics(List<Log> logsCreated)
        {
            LogsCreated = logsCreated;
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

        public Client ClientWithMostRenderTime()
        {
            List<Client> clientList = GetClientListWhoRendered();
            int maxTime = 0;
            Client maxClient = null;

            foreach (Client cl in clientList)
            {
                int t = RenderTimeInSecondsOfClient(cl);
                if (t > maxTime)
                {
                    maxTime = t;
                    maxClient = cl;
                }
            }
            return maxClient;
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

