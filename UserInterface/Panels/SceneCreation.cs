using Render3D.BackEnd;
using Render3D.BackEnd.GraphicMotorUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Panels
{
    public partial class SceneCreation : Form
    {
        public Scene scene;
        public SceneCreation()
        {
            InitializeComponent();
            scene = new Scene();
        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void NrFov_ValueChanged(object sender, EventArgs e)
        {
            scene.Camera.Fov=(int)nrFov.Value;
        }
    }
}
