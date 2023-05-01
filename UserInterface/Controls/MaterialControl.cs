using Render3D.BackEnd.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Controls
{
    public partial class MaterialControl : UserControl
    {
        Material material;
        public MaterialControl(Material material)
        {
            this.material = material;
            InitializeComponent();
            txtMaterialName.Text = material.Name;
            lblRedColor.Text ="Red: "+ ((LambertianMaterial)material).Color[0];
            lblGreenColor.Text = "Green: " + ((LambertianMaterial)material).Color[1];
            lblBlueColor.Text = "Blue: " + ((LambertianMaterial)material).Color[2];
        }

        private void btnEditMaterialName_Click(object sender, EventArgs e)
        {

        }
    }
}
