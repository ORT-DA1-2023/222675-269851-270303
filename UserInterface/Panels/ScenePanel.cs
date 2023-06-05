using System;
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
            using (var scene = new SceneCreation(render.sceneController, null))
            {
                var result = scene.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    creation.Refresh("Scene");
                }
            }
        }

    }
}
