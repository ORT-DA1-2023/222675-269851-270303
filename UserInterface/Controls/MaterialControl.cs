
using RenderLogic.DataTransferObjects;
using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface.Panels;

namespace Render3D.UserInterface.Controls
{
    public partial class MaterialControl : UserControl
    {
        private string _oldName;
        private MaterialDto _materialDto;
        public MaterialControl(MaterialDto material)
        {
            InitializeComponent();
            lblMaterialName.Text = material.Name;
            _oldName = material.Name;
            _materialDto = material;
            lblRedColor.Text = "Red: " + material.Red;
            lblGreenColor.Text = "Green: " + material.Green;
            lblBlueColor.Text = "Blue: " + material.Blue;
            lblErrorDeleteMaterial.Text = "";
            pBoxMaterial.BackColor = Color.FromArgb(material.Red, material.Green, material.Blue);
        }


        private void ChecksForCorrectEdit(string newName)
        {
            if (!_oldName.Equals(newName))
            {
                if (((CreationMenu)this.Parent.Parent.Parent).ChangeMaterialName(_oldName, newName))
                {
                    lblMaterialName.Text = newName;
                    _oldName = newName;
                }
            }
        }

        private void BtnDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (!((CreationMenu)this.Parent.Parent.Parent).MaterialIsPartOfModel(lblMaterialName.Text))
            {
                ((CreationMenu)this.Parent.Parent.Parent).DeleteMaterial(lblMaterialName.Text);
                ((CreationMenu)this.Parent.Parent.Parent).Refresh("Material");
            }
            else
            {
                lblErrorDeleteMaterial.Text = "A model is using this material";
            }

        }

        private void BtnEditName_Click(object sender, EventArgs e)
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
    }
}
