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
        private CreationMenu creation;
        private Render3DIU render;
        public ScenePanel()
        {
            InitializeComponent();
        }

        private void BtnCreateScene_Click(object sender, EventArgs e)
        {
            CreationMenu creation = (CreationMenu)this.Parent.Parent;
            Render3DIU render = (Render3DIU)creation.Parent.Parent;
            using (var scene = new SceneCreation(render.sceneController, render.clientName,null))
            {
                var result = scene.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    creation.Refresh("Scene");
                }
            }
        }

        private void VariableInitialize(object sender, EventArgs e)
        {
            creation= (CreationMenu)this.Parent.Parent;
            render = (Render3DIU)creation.Parent.Parent;
        }
    }
}
