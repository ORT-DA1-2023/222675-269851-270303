using Render3D.RenderLogic.Controllers;
using RenderLogic.DataTransferObjects;
using System;
using System.Collections.Generic;
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
        }

        private void GoBackLog_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
