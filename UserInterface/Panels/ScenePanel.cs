using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Panels;

namespace Render3D.UserInterface.Panels
{
    public partial class ScenePanel : Form
    {
        public ScenePanel()
        {
            InitializeComponent();
        }

        private void BtnCreateScene_Click(object sender, EventArgs e)
        {
            CreationMenu creation = (CreationMenu)this.Parent.Parent;
            Render3DIU render = (Render3DIU)creation.Parent.Parent;
            SceneCreation scene =new SceneCreation(render.dataWarehouse);
            scene.Show();
        }
    }
}
