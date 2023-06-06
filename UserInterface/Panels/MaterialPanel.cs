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
            String materialName = txtMaterialName.Text;
            double blur = Convert.ToDouble(txtBlur.Text);
            int[] materialColors = new int[rgbLength];
            materialColors[0] = Convert.ToInt32(Math.Round(nrRedColor.Value));
            materialColors[1] = Convert.ToInt32(Math.Round(nrGreenColor.Value));
            materialColors[2] = Convert.ToInt32(Math.Round(nrBlueColor.Value));
            try
            {
                if(cmbMaterial.SelectedItem == null)
                {
                    throw new Exception("You must select a material type");
                }
                else
                {
                    if (cmbMaterial.SelectedItem.Equals("Lambertian"))
                    {
                        render.materialController.AddLambertianMaterial(render.clientName, materialName, materialColors);
                    }
                    else if (cmbMaterial.SelectedItem.Equals("Metallic"))
                    {
                        render.materialController.AddMetallicMaterial(render.clientName, materialName, materialColors, blur);
                    }
                }
                
               
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

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMaterial.SelectedItem.Equals("Lambertian")) {
                txtBlur.Enabled = false;
                lblBlur.Enabled = false;
            }else if (cmbMaterial.SelectedItem.Equals("Metallic"))
            {
                txtBlur.Enabled = true;
                lblBlur.Enabled = true;
            }
        }
    }
}
