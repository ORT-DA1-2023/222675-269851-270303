using Render3D.RenderLogic.Controllers;
using RenderLogic.DataTransferObjects;
using System;
using System.Windows.Forms;

namespace Render3D.UserInterface.Panels
{
    public partial class MaterialPanel : Form
    {
        private CreationMenu creation;
        private readonly MaterialController materialController;
        public MaterialPanel()
        {
            materialController = MaterialController.GetInstance();
            InitializeComponent();
            lblExceptionError.Text = "";

        }

        private void BtnCreateMaterial_Click(object sender, EventArgs e)
        {
            MaterialDto materialDto = new MaterialDto
            {
                Name = txtMaterialName.Text,
                Red = Convert.ToInt32(Math.Round(nrRedColor.Value)),
                Green = Convert.ToInt32(Math.Round(nrGreenColor.Value)),
                Blue = Convert.ToInt32(Math.Round(nrBlueColor.Value))
            };
            try
            {
               materialController.AddLambertianMaterial(materialDto);
            }
            catch (Exception ex)
            {
                lblExceptionError.Text = ex.Message;
                return;
            }
            creation.ShowMaterialList();
            txtMaterialName.Text = "";
            nrRedColor.Value = 0;
            nrGreenColor.Value = 0;
            nrBlueColor.Value = 0;
            lblExceptionError.Text = "";
        }

        private void VariablesInitialize(object sender, EventArgs e)
        {
            creation = ((CreationMenu)this.Parent.Parent);
        }
    }
}
