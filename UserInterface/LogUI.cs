using Render3D.RenderLogic.Controllers;
using RenderLogic.Controllers;
using RenderLogic.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class LogUI : Form
    {
       private readonly LogController _logController;
        public LogUI()
        {
            InitializeComponent();
            _logController = LogController.GetInstance();
            List <LogDto> logs= _logController.GetLogs();
            foreach (LogDto log in logs)
            {
                DgvLogs.Rows.Add(log.ClientName,log.RenderTimeInSeconds, log.RenderDate, log.TimeWindowSinceLastRender,log.Name,log.NumberElements);
            }
            lblMostRenderedUser.Text =_logController.ClientWithMostRenderTime();
            lblAverageTimeInSeconds.Text = _logController.GetAverageRenderTimeInSeconds().ToString();
            lblRenderTime.Text = _logController.GetAverageRenderTimeInMinutes().ToString();

        }

        private void GoBackLog_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
