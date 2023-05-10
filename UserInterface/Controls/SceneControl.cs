using Render3D.BackEnd;
using Render3D.UserInterface;
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

namespace Render3D.UserInterface.Controls
{
    public partial class SceneControl : UserControl
    {
        private string _oldName;
        private Scene _scene;
        public SceneControl(Scene selectedScene)
        {
            InitializeComponent();
            _scene = selectedScene;
            lblSceneName.Text = _scene.Name;
            _oldName = _scene.Name;
            lblSceneModificationDate.Text = "" + _scene.LastModificationDate.Month + "/" + _scene.LastModificationDate.Day + "/" + _scene.LastModificationDate.Year + " " + _scene.LastModificationDate.Hour + ":" + _scene.LastModificationDate.Minute;
            if(_scene.Preview != null )
            {
                pBoxPreview.Image = _scene.Preview;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!((CreationMenu)this.Parent.Parent.Parent).ModelIsPartOfScene(lblSceneName.Text))
            {
            ((CreationMenu)this.Parent.Parent.Parent).DeleteScene(lblSceneName.Text);
            ((CreationMenu)this.Parent.Parent.Parent).Refresh("Scene");
            }

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CreationMenu creation = (CreationMenu)this.Parent.Parent.Parent;
            Render3DIU render = (Render3DIU)creation.Parent.Parent;
            using (var scene = new SceneCreation(render.sceneController, render.clientName, _scene))
            {
                var result = scene.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    creation.Refresh("Scene");
                }
            }
        }
        private void ChecksForCorrectEdit(string newName)
        {

            if (!_oldName.Equals(newName))
            {

                if (((CreationMenu)this.Parent.Parent.Parent).FigureNameHasBeenChanged(_oldName, newName))
                {
                    lblSceneName.Text = newName;
                    _oldName = newName;
                }
            }
        }
    }
}
