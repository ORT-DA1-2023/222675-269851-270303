using Render3D.RenderLogic.Controllers;
using RenderLogic.DataTransferObjects;
using System;
using System.Text.RegularExpressions;
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
                Blue = Convert.ToInt32(Math.Round(nrBlueColor.Value)),
                Blur = -1,
            };
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

                         materialController.AddMaterial(materialDto);
                    }
                    else if (cmbMaterial.SelectedItem.Equals("Metallic"))
                    {
                        if (IsValidFormat(txtBlur.Text))
                        {
                            double blur = Convert.ToDouble(txtBlur.Text);
                            materialDto.Blur= blur;
                            materialController.AddMaterial(materialDto);
                        }
                        else
                        {
                            throw new Exception("Invalid blur, the format is: number,number");
                        }
                        
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

        public bool IsValidFormat(string input)
        {
            Regex vectorFormat = new Regex(@"^\d+,\d+$");
            return vectorFormat.IsMatch(input);
        }

        private void VariablesInitialize(object sender, EventArgs e)
        {
            creation = ((CreationMenu)this.Parent.Parent);
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMaterial.SelectedItem.Equals("Lambertian")) {
                txtBlur.Text = "0,0";
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
