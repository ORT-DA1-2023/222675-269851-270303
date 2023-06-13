using Render3D.RenderLogic.Controllers;
using Render3D.RenderLogic.DataTransferObjects;
using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface.Panels;

namespace Render3D.UserInterface.Controls
{
    public partial class LambertianMaterialControl : UserControl
    {
        private readonly MaterialDto _materialDto;
        private readonly ModelController modelController;
        private readonly MaterialController materialController;

        public LambertianMaterialControl(MaterialDto material)
        {
            InitializeComponent();
            lblMaterialName.Text = material.Name;
            _materialDto = material;
            modelController = ModelController.GetInstance();
            materialController = MaterialController.GetInstance();
            lblRedColor.Text = "R: " + material.Red;
            lblGreenColor.Text = "G: " + material.Green;
            lblBlueColor.Text = "B: " + material.Blue;
            lblErrorDeleteMaterial.Text = "";
            pBoxMaterial.BackColor = Color.FromArgb(material.Red, material.Green, material.Blue);
        }


        private void ChecksForCorrectEdit(string newName)
        {
            if (!_materialDto.Equals(newName))
            {
                if (((CreationMenu)this.Parent.Parent.Parent).MaterialNameHasBeenChange(_materialDto, newName))
                {
                    lblMaterialName.Text = newName;
                    _materialDto.Name = newName;
                }
                else
                {
                    lblErrorDeleteMaterial.Text = "invalid name or name already in use";
                }
            }
        }

        private void BtnDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (!modelController.CheckIfMaterialIsInAModel(_materialDto))
            {
                materialController.Delete(_materialDto);
                ((CreationMenu)this.Parent.Parent.Parent).Refresh("Material");
            }
            else
            {
                lblErrorDeleteMaterial.Text = "A model is using this material";
            }

        }

        private void BtnEditName_Click(object sender, EventArgs e)
        {
            using (var nameChanger = new NameChanger(_materialDto.Name))
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
