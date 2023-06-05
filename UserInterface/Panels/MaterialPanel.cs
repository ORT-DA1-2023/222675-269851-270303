using RenderLogic.DataTransferObjects;
using System;
using System.Windows.Forms;

namespace Render3D.UserInterface.Panels
{
    public partial class MaterialPanel : Form
    {
        private readonly int rgbLength = 3;
        private CreationMenu creation;
        private Render3DIU render;
        public MaterialPanel()
        {
            InitializeComponent();

        }

        private void BtnCreateFigure_Click(object sender, EventArgs e)
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
                render.materialController.AddLambertianMaterial(materialDto);
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
            render = ((Render3DIU)creation.Parent.Parent);
            lblExceptionError.Text = "";
        }
    }
}
