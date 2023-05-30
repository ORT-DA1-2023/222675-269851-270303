using Render3D.BackEnd;
using System;
using System.Windows.Forms;
using UserInterface.Panels;

namespace Render3D.UserInterface.Controls
{
    public partial class ModelControl : UserControl
    {
        private string _oldName;
        public ModelControl(Model model)
        {
            InitializeComponent();
            lblModelName.Text = model.Name;
            _oldName = model.Name;
            lblModelFigure.Text = model.Figure.Name;
            lblModelMaterial.Text = model.Material.Name;
            lblErrorDeleteModel.Text = "";
            if (model.Preview != null)
            {
                pBoxPreview.Image = model.Preview;
            }
        }

        private void BtnEditModelName_Click(object sender, EventArgs e)
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
                if (((CreationMenu)this.Parent.Parent.Parent).ModelNameHasBeenChanged(_oldName, newName))
                {
                    lblModelName.Text = newName;
                    _oldName = newName;
                }
            }
        }

        private void BtnDeleteModel_Click(object sender, EventArgs e)
        {
            if (!((CreationMenu)this.Parent.Parent.Parent).ModelIsPartOfScene(lblModelName.Text))
            {

                ((CreationMenu)this.Parent.Parent.Parent).DeleteModel(lblModelName.Text);
                ((CreationMenu)this.Parent.Parent.Parent).Refresh("Model");
            }
            else
            {
                lblErrorDeleteModel.Text = "A scene is using this model";
            }

        }
    }
}
