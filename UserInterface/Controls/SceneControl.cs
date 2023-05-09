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

namespace UserInterface.Controls
{
    public partial class SceneControl : UserControl
    {
        string _oldName;
        public SceneControl(Scene scene)
        {
            InitializeComponent();
            lblSceneName.Text = scene.Name;
            lblSceneModificationDate.Text = "" + scene.LastModificationDate.Month + "/" + scene.LastModificationDate.Day + "/" + scene.LastModificationDate.Year + " " + scene.LastModificationDate.Hour + ":" + scene.LastModificationDate.Minute;
            if(scene.Preview != null )
            {
                pBoxPreview.Image = scene.Preview;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ((CreationMenu)this.Parent.Parent.Parent).DeleteScene(lblSceneName.Text);
            ((CreationMenu)this.Parent.Parent.Parent).Refresh("Scene");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            using (var nameChanger = new NameChanger(_oldName))
            {
                var result = nameChanger.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    string name = nameChanger.newName;
                    ChecksForCorrectEdit(name);
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
