using Render3D.BackEnd.Materials;
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

namespace UserInterface.Controls
{
    public partial class MaterialControl : UserControl
    {
        Material material;
        String oldName;
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
            oldName = txtMaterialName.Text;
            txtMaterialName.ReadOnly = false;
            txtMaterialName.BackColor = Color.Green;
        }


        
        private void ClientLeaves(object sender, EventArgs e)
        {
            checksForCorrectEdit();
        }

        private void clientPressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                checksForCorrectEdit();
            }
        }
        private void checksForCorrectEdit()
        {
            txtMaterialName.ReadOnly = true;
            if (!oldName.Equals(txtMaterialName.Text))
            {
                if (((CreationMenu)this.Parent.Parent.Parent).materialNameHasBeenChanged(oldName, txtMaterialName.Text))
                {
                    txtMaterialName.BackColor = Color.White;
                }
                else
                {
                    txtMaterialName.BackColor = Color.Red;
                }
            }
            else
            {
                txtMaterialName.BackColor = Color.White;
            }
        }
    }
}
