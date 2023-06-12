using Render3D.BackEnd;
using Render3D.RenderLogic.Controllers;
using RenderLogic.DataTransferObjects;
using RenderLogic.Services;

namespace RenderLogic.Controllers
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
            Log log= new Log()
            {

            }
        }
    }
}
