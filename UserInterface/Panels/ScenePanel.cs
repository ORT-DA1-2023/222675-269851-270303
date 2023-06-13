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
            SceneCreation scene = new SceneCreation(null);
            creation.Refresh("Scene");
            
        }

    }
}
