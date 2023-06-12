using Render3D.RenderLogic.Controllers;
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
    }
}
